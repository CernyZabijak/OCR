using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class MouseHookEventArgs : EventArgs
    {
        public MouseHook.POINT Location { get; }

        public MouseHookEventArgs(MouseHook.POINT location)
        {
            Location = location;
        }
    }
}
