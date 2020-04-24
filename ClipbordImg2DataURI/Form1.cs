using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private Image Source;

        public event ClipboardHandler ClipboardHandler;

        public Form1()
        {
            InitializeComponent();

            ClipboardHandler += Form1_ClipboardHandler;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                copyButton_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private Image ImageFilter(Image img, ImageFactory factory)
        {
            var size = img.Size;
            var factor =
                scale12Percent.Checked ? 8 :
                scale25Percent.Checked ? 4 :
                scale50Percent.Checked ? 2 :
                1;

            if (size.Width < factor)
                throw new InvalidOperationException();
            if (size.Height < factor)
                throw new InvalidOperationException();

            size = new Size(size.Width / factor, size.Height / factor);

            return factory.Load(img).Resize(size).Image.Clone() as Image;
        }

        private static void SaveDispose<T>(ref T obj) where T : IDisposable
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = default;
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

            using (var factory = new ImageFactory(false))
            {
                byte[] buf;
                var format = MakeImageFormat();
                var imageFactory = factory.Load(ImageFilter(Source, factory)).Format(format);
                if (outputFormatPng8.Checked && checkBox2.Checked)
                {
                    var tempPathIn = Path.GetTempFileName() + ".png";
                    _ = imageFactory.Save(tempPathIn);
                    var tempPathOut = Path.GetTempFileName() + ".png";
                    File.Delete(tempPathOut);
                    using (var p = Process.Start(
                        new ProcessStartInfo(@"optipng-0.7.7-win32\optipng.exe",
                        $"-o3 --out=\"{tempPathOut}\" \"{tempPathIn}\"")
                        { 
                            RedirectStandardError = true,
                            RedirectStandardOutput= true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        }))
                    {
                        p.WaitForExit();
                        Debug.Write(p.StandardOutput.ReadToEnd());
                        if(p.ExitCode != 0)
                        {
                            MessageBox.Show(this, p.StandardError.ReadToEnd(), "optipng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    buf = File.ReadAllBytes(tempPathOut);
                    File.Delete(tempPathIn);
                    File.Delete(tempPathOut);
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        _ = imageFactory.Save(stream);
                        buf = stream.GetBuffer();
                    }

                }
                var dataUri = "data:" + format.MimeType + ";base64," + Convert.ToBase64String(buf, Base64FormattingOptions.None);
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
    public delegate void ClipboardHandler(
                            object sender, ClipboardImageEventArgs ev);

    public class ClipboardImageEventArgs : EventArgs
    {
        public Image Image { get; }
        public ClipboardImageEventArgs(Image str) => this.Image = str;
    }
}
