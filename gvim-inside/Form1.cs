using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace gvim_inside
{
    public partial class Form1 : Form
    {
        protected Process gvim;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr h = Handle;
            Text += " (HWND " + h.ToString() + " / x" + h.ToString("X") + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            this.Focus();
            gvim = Process.Start("gvim.exe", "--windowid 0x" + Handle.ToString("X"));
            timer1.Start();
        }


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowEx(IntPtr hParent, IntPtr hChild, string szClass, string szWindow);

        private void Form1_Resize(object sender, EventArgs e)
        {
            if ((gvim != null) && !gvim.HasExited)
            {
                IntPtr hGVim = FindWindowEx(Handle, (IntPtr)0, null, null);
                if (hGVim != (IntPtr)0)
                {
                    MoveWindow(hGVim, 0, 0, ClientSize.Width, ClientSize.Height, true);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((gvim != null) && gvim.HasExited)
            {
                timer1.Stop();
                gvim = null;
                button1.Show();
                button1.Focus();
            }
        }
    }
}
