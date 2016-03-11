using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XInputDotNetPure;


namespace XIn2KB
{
    class Rule
    {
        private bool invoked_Val;
        private int inputVal;
        private byte outputVal;
        public int input
        {
            get
            {
                return inputVal;
            }
            protected set
            {
                inputVal = value;
            }
        }
        public byte output
        {
            get
            {
                return outputVal;
            }
            protected set
            {
                outputVal = value;
            }
        }
        public bool invoked
        {
            get
            {
                return invoked_Val;
            }
            protected set
            {
                invoked_Val = value;
            }
        }
        public Rule(int input, byte output)
        {              
            this.input = input;
            this.output = output;
        }

        
        public void invoke()             
        {
            //System.Windows.Forms.SendKeys.SendWait(output);
            keybd_event(output, 0, 0x0001 | 0, 0);
            invoked = true;
            Console.WriteLine(System.DateTime.Now.TimeOfDay + ": Pressing \"" + output.ToString("X")+"\"");
        }

        public void devoke()
        {
            keybd_event(output, 0, 0x0001 | 0x0002, 0);
            invoked = false;
            Console.WriteLine(System.DateTime.Now.TimeOfDay + ": Released \"" + output.ToString("X") + "\"");
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
    }
}
