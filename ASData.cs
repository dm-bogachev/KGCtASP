using System;
using System.Collections.Generic;

namespace KGCtASP
{
    internal class ASData
    {
        private List<string> sASLines;

        public List<string> Lines { get => sASLines;}

        public ASData()
        {
            sASLines = new List<string>();
        }

        public void AppendLine(string line)
        {
            sASLines.Add(line);
        }

        public override string ToString()
        {
            string returnString = "";

            foreach (string s in sASLines)
            {
                returnString = returnString + s + Environment.NewLine;
            }
            return returnString;
        }
    }
}
