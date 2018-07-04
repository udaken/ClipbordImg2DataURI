﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ImageProcessor;

namespace ClipbordImg2DataURI
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(
                IntPtr hWndNewViewer);

        [DllImport("user32")]
        public static extern bool ChangeClipboardChain(
                IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32")]
        public extern static int SendMessage(
                IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;
        private IntPtr nextHandle;

        public Form1()
        {
            InitializeComponent();

            ClipboardHandler += Form1_ClipboardHandler;
        }

        private Image ImageFilter(Image img, ImageFactory factory)
        {
            var size = img.Size;
            int factor = 1;
            if (scale50Percent.Checked)
            {
                factor = 2;
            }
            else if (scale25Percent.Checked)
            {
                factor = 4;
            }
            else if (scale12Percent.Checked)
            {
                factor = 8;
            }
            if (size.Width < factor) throw new InvalidOperationException();
            if (size.Height < factor) throw new InvalidOperationException();

            size = new Size(size.Width / factor, size.Height / factor);

            return factory.Load(img).Resize(size).Image.Clone() as Image;
            
        }

        private Image Source;

        private static void SaveDispose<T>(ref T obj) where T : IDisposable
        {
            if (obj != null)
            {
                obj.Dispose(); obj = default;
            }
        }

        private void Form1_ClipboardHandler(object sender, ClipboardImageEventArgs ev)
        {
            SaveDispose(ref Source);
            Source = ev.Image;
            UpdateImage(sender, ev);
            copyButton.Enabled = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            nextHandle = SetClipboardViewer(this.Handle);

            base.OnHandleCreated(e);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            // ビューアを解除
            ChangeClipboardChain(this.Handle, nextHandle);

            base.OnHandleDestroyed(e);
        }

        public event ClipboardHandler ClipboardHandler;
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (Clipboard.ContainsImage())
                    {
                        // クリップボードの内容がテキストの場合のみ
                        // クリップボードの内容を取得してハンドラを呼び出す
                        ClipboardHandler?.Invoke(this, new ClipboardImageEventArgs(Clipboard.GetImage()));
                    }
                    if (nextHandle != IntPtr.Zero)
                        SendMessage(
                            nextHandle, msg.Msg, msg.WParam, msg.LParam);
                    msg.Result = IntPtr.Zero;
                    return;
                case WM_CHANGECBCHAIN:
                    if (msg.WParam == nextHandle)
                        nextHandle = msg.LParam;
                    else if (nextHandle != IntPtr.Zero)
                        SendMessage(nextHandle, msg.Msg, msg.WParam, msg.LParam);
                    msg.Result = IntPtr.Zero;
                    return;
            }
            base.WndProc(ref msg);
        }

        private void UpdateImage(object sender, EventArgs e)
        {
            if (Source != null)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                using (var factory = new ImageFactory())
                {
                    pictureBox1.Image = ImageFilter(Source, factory);
                }
            }
        }

        private ImageProcessor.Imaging.Formats.ISupportedImageFormat MakeImageFormat()
        {
            if (outputFormatJpeg.Checked)
            {
                return new ImageProcessor.Imaging.Formats.JpegFormat
                {
                    Quality = 90
                };
            }
            else
            {
                return new ImageProcessor.Imaging.Formats.PngFormat
                {
                    IsIndexed = true
                };
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (Source == null)
                return;

            using (var factory = new ImageFactory())
            {
                var format = MakeImageFormat();
                using (var stream = new System.IO.MemoryStream())
                {
                    factory.Load(ImageFilter(Source, factory)).Format(format).Save(stream);
                    var dataUri = "data:" + format.MimeType + ";base64," + Convert.ToBase64String(stream.GetBuffer(), Base64FormattingOptions.None);
                    try
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(dataUri);

                        textBox1.Text = $"{dataUri.Length} characters copied.";
                    }
                    catch (ExternalException ex)
                    {
                        MessageBox.Show(this, "Failed to set Clipboard.\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    public delegate void ClipboardHandler(
                            object sender, ClipboardImageEventArgs ev);

    public class ClipboardImageEventArgs : EventArgs
    {
        public Image Image { get; }
        public ClipboardImageEventArgs(Image str) => this.Image = str;
    }
}