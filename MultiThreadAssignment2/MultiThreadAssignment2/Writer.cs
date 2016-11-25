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
        TextBox answerBox;
        TextBox displayBox;
        Button submitButton;

        string allowedChars = "abcdefghijklmnopqrstuvxyz123456789!#¤%&/()";

        Random rnd;
        public int nrOfCharacters = 3;
        public int displayTimer = 1000;

        public bool isActive;
        /// <summary>
        /// Constructor.
        /// </summary>
        public Writer(TextBox answerBox, Button submitButton, TextBox displayBox)
        {           
            rnd = new Random();
            isActive = true;
            this.displayBox = displayBox;
            this.answerBox = answerBox;
            this.submitButton = submitButton;
        }
        /// <summary>
        /// Sets the needed attribrutes for writer. 
        /// nrOfCharacters is the amount of times it should produce a new char
        /// displaytimer is the amount of time that should pass between chaning chars 
        /// </summary>
        public void SetAttributes(int nrOfCharacters, int displayTimer)
        {
            this.nrOfCharacters = nrOfCharacters;
            this.displayTimer = displayTimer;
            CharacterBuffer.SetNrOfChars(nrOfCharacters);
        }
        /// <summary>
        /// Loops the amount of time we need to change char
        /// Picks a random value that represents an index in out allowedChars-string
        /// When finished it inovkes the Form1 to enable the answer-bar
        /// </summary>
        public void StartAddingCharacters()
        {          
            while (CharacterBuffer.currentNrOfChars != nrOfCharacters)
            {
                if (!CharacterBuffer.charWritten)
                {
                    CharacterBuffer.setChar(allowedChars[rnd.Next(1, 40)]);
                    Thread.Sleep(displayTimer);
                }
            }
            displayBox.BeginInvoke((Action)delegate() { displayBox.Text = ""; });
            answerBox.BeginInvoke((Action)delegate() { answerBox.Enabled = true; });
            submitButton.BeginInvoke((Action)delegate() { submitButton.Enabled = true; });
        }
    }
}
