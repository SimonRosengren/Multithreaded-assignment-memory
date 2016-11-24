using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadAssignment2
{
    public static class CharacterBuffer
    {
        static Object myLock = new Object();
        public static Queue<int> characters = new Queue<int>();

        public static int charToDisplay;
        public static int charToDisplaySafe
        {
            get
            {
                lock (myLock)
                {
                    return charToDisplay;
                }
            }
            set
            {
                lock (myLock)
                {
                    charToDisplay = value;
                    characters.Enqueue(value); //För att sedan kunna kolla mot kön vilka siffror vi visat
                }
            }
        }
    }
}
