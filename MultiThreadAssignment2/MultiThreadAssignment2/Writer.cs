using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MultiThreadAssignment2
{
    class Writer
    {
        Panel panel; //To fix blinking text problem by only updating the panel when new number is presented
        TextBox answerBox;
        Button submitButton;

        string allowedChars = "abcdefghijklmnopqrstuvxyz123456789!#¤%&/()";

        Random rnd;
        public int nrOfCharacters = 3;
        public int displayTimer = 1000;

        public bool isActive;

        public Writer(Panel panel, TextBox answerBox, Button submitButton)
        {
            this.panel = panel;
            rnd = new Random();
            isActive = true;
            this.answerBox = answerBox;
            this.submitButton = submitButton;
        }
        public void SetAttributes(int nrOfCharacters, int displayTimer)
        {
            this.nrOfCharacters = nrOfCharacters;
            this.displayTimer = displayTimer;
            CharacterBuffer.SetNrOfChars(nrOfCharacters);
        }
        public void StartAddingCharacters()
        {          
            for (int i = 0; i < nrOfCharacters; i++)
            {
                CharacterBuffer.charToDisplaySafe = allowedChars[rnd.Next(1, 40)];
                Thread.Sleep(displayTimer);
                panel.BeginInvoke((Action)delegate() { panel.Invalidate(); }); //Funkar bara ibland?
            }
            answerBox.BeginInvoke((Action)delegate() { answerBox.Enabled = true; });
            submitButton.BeginInvoke((Action)delegate() { submitButton.Enabled = true; });
            panel.BeginInvoke((Action)delegate() { panel.Invalidate(); });
        }
    }
}
