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
        public static char charToDisplaySafe;/*
        {
            get
            {
                lock (myLock)
                {
                    charWritten = false;
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
                    charWritten = true;
                }
            }
        }*/
        public static bool setChar(char c)
        {
            if (charWritten)
            {
                return false;                
            }
            else
            {
                charToDisplaySafe = c;
                chars[currentNrOfChars] = c;
                currentNrOfChars++;//För att sedan kunna kolla mot kön vilka siffror vi visat
                finalString = new string(chars);
                charWritten = true;
                return true;
            }
        }
        public static bool getChar(out char c)
        {
            if (charWritten)
            {
                c = charToDisplaySafe;
                charWritten = false;
                return true;
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
