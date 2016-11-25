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

        public static bool charWritten = false;

        public static char[] chars;
        public static int currentNrOfChars = 0;
        public static string finalString;

        /// <summary>
        /// Locks the process of wrtining and reading to the buffer
        /// </summary>
        public static char charToDisplay;
        public static char charToDisplaySafe;
        /// <summary>
        /// Sets the char to value if it is not already set or if it is already read
        /// </summary>
        public static bool setChar(char c)
        {
            bool b = false;
            if (!charWritten)
            {
                lock (myLock)
                {
                    charToDisplaySafe = c;
                    chars[currentNrOfChars] = c;
                    currentNrOfChars++;//För att sedan kunna kolla mot kön vilka siffror vi visat
                    finalString = new string(chars);
                    charWritten = true;
                    b = true;
                }
            }
            return b;
        }
        /// <summary>
        /// Returns the value of char if it is not already read
        /// </summary>
        public static bool getChar(out char c)
        {
            if (charWritten)
            {
                lock (myLock)
                {
                    c = charToDisplaySafe;
                    charWritten = false;
                    return true;                    
                }
            }
            c = '0';
            return false;
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
