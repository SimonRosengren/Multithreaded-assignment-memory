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
        Panel panel;
        Graphics g;


        bool active = true;

        public Reader(Panel panel)
        {
            this.panel = panel;
            g = panel.CreateGraphics();
        }
        /// <summary>
        /// Reads and draws the char that writer has written to the common Buffer
        /// </summary>
        public void Update()
        {            
            while (active)
            {
                Brush brush = new SolidBrush(Color.DarkGreen);
                char c;
                if (CharacterBuffer.getChar(out c))
                {
                    g.DrawString("" + c, new Font("Arial", 16), brush, 10f, 10f);
                }
            }
        }
    }
}
