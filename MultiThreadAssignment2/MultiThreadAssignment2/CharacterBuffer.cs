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

        public static char[] chars;
        public static int currentNrOfChars = 0;
        public static string finalString;

        /// <summary>
        /// Locks the process of wrtining and reading to the buffer
        /// </summary>
        public static char charToDisplay;
        public static char charToDisplaySafe
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
                    chars[currentNrOfChars] = value;
                    currentNrOfChars++;//För att sedan kunna kolla mot kön vilka siffror vi visat
                    finalString = new string(chars);
                }
            }
        }
        /// <summary>
        /// So that the string does not get too long, resulting in empty spots that would later have been filled with /0
        /// </summary>
        public static void SetNrOfChars(int size)
        {
            chars = new char[size];
        }
    }
}
