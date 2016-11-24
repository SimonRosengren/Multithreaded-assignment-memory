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
        public void Update()
        {
            while (active)
            {
                Brush brush = new SolidBrush(Color.DarkGreen);
                panel.Invalidate();
                g.DrawString("" + CharacterBuffer.charToDisplaySafe, new Font("Arial", 16), brush, 10f, 10f);
            }
        }
    }
}
