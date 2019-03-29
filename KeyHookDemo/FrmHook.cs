using EventHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyHookDemo
{
    public partial class FrmHook : Form
    {
        public FrmHook()
        {
            InitializeComponent();
        }
        private void FrmHook_Load(object sender, EventArgs e)
        {
            KeyboardWatcher.Start();
            KeyboardWatcher.OnKeyInput += KeyboardWatcher_OnKeyInput;
        }

        private void KeyboardWatcher_OnKeyInput(object sender, KeyInputEventArgs e)
        {
            Console.WriteLine($"按键==>{e.KeyData.Keyname}:{e.KeyData.EventType}");
            if (new List<string> { "F11", "F12" }.Contains(e.KeyData.Keyname) && e.KeyData.EventType == KeyEvent.up)
            {
                Console.WriteLine($"按键抬起{e.KeyData.Keyname}:{e.KeyData.EventType}");
            }
        }

        private void FrmHook_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardWatcher.OnKeyInput -= KeyboardWatcher_OnKeyInput;
            KeyboardWatcher.Stop();
        }
    }
}
