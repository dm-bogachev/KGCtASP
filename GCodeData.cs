using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace KGCtASP
{
    enum CommandType
    {
        Comment = 0,
        Motion = 1,
        Auxilary = 2,
        NAC = -1
    }

    internal class GCodeData
    {
        string originalLine;
        private CommandType type;
        private string comment;
        private int command;
        private List<string> parameters;

        public CommandType Type { get { return type; } }
        public string Comment { get { return comment; } }
        public int Command { get { return command; } }
        public List<string> Parameters { get {  return parameters; } }
        public string OriginalLine { get { return originalLine; } }
        private void parseLine(string line)
        {
            int commentIndex = line.IndexOf(';');
            string data;
            if (commentIndex > 0){ 
                comment = line.Substring(commentIndex); 
                data = line.Substring(0, commentIndex);
            }
            else { data =  line; }

            string[] lineData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            command = Int32.Parse(lineData[0].Substring(1));
            for (int i = 1; i < lineData.Length; i++)
            {
                parameters.Add(lineData[i]);
            }
        }

        private void parseGCodeLine(string line)
        {
            if (string.IsNullOrEmpty(line)) return;
            if (line.StartsWith(";"))
            {
                type = CommandType.Comment;
                comment = line;
                return;
            }
            if (line.StartsWith("M"))
            {
                type = CommandType.Auxilary;
                parseLine(line);
                return;
            }
            if (line.StartsWith("G"))
            {
                type = CommandType.Motion;
                parseLine(line);
                return;
            }
            type = CommandType.NAC;
        }
        public override string ToString()
        {
            return originalLine;
        }

        public GCodeData(string sGCodeLine)
        {
            originalLine = sGCodeLine;
            parameters = new List<string>();
            parseGCodeLine(sGCodeLine);

        }
    }
}
