using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadAssignment2
{
    class Writer
    {
        Random rnd;
        public int nrOfCharacters = 3;
        public int displayTimer = 1000;

        public Writer()
        {
            rnd = new Random();
        }
        public Writer(int nrOfCharacters, int displayTimer)
        {
            this.nrOfCharacters = nrOfCharacters;
            this.displayTimer = displayTimer;
            rnd = new Random();
        }
        public void SetAttributes(int nrOfCharacters, int displayTimer)
        {
            this.nrOfCharacters = nrOfCharacters;
            this.displayTimer = displayTimer;
        }
        public void StartAddingCharacters()
        {
            for (int i = 0; i < nrOfCharacters; i++)
            {
                CharacterBuffer.charToDisplaySafe = rnd.Next(1, 9);
                Thread.Sleep(displayTimer);                
            }
        }
    }
}
