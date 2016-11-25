using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;


namespace MultiThreadAssignment2
{
    class Reader
    {
        
        TextBox tb;


        bool active = true;

        public Reader(TextBox tb)
        {
            this.tb = tb;
        }
        /// <summary>
        /// Reads and draws the char that writer has written to the common Buffer
        /// </summary>
        public void Update()
        {            
            while (active)
            {
                char c;
                if (CharacterBuffer.getChar(out c))
                {
                    tb.BeginInvoke((Action)delegate() { tb.Text = "" + c; });
                }
            }
        }
    }
}
