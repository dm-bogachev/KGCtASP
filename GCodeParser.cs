using System;
using System.Windows.Forms;

namespace KGCtASP
{
    internal class GCodeParser
    {
        private bool disableFeederInstruction;
        private double lastX = 0.0f;
        private double lastY = 0.0f;
        private double lastZ = 0.0f;
        private double lastE = 0.0f;
        private bool ignoreComments;
        public bool IgnoreComments
        {
            get => ignoreComments;
            set { ignoreComments = value; }
        }

        private void parseAuxilaryCommand(ASData a, GCodeData m)
        {
            switch (m.Command)
            {
                case 140:
                    {
                        int temp = Convert.ToInt32(m.Parameters[0].Substring(1));
                        a.AppendLine(string.Format("CALL set.bed.temp({0})", temp));
                        break;
                    }
                case 109:
                    {
                        int temp = Convert.ToInt32(m.Parameters[0].Substring(1));
                        a.AppendLine(string.Format("CALL set.feed.temp({0})", temp));
                        break;
                    }
                case 106:
                    {
                        int speed = Convert.ToInt32(m.Parameters[0].Substring(1));
                        a.AppendLine(string.Format("CALL set.fan({0})", speed));
                        break;
                    }
                case 107:
                    {
                        int speed = 0;
                        a.AppendLine(string.Format("CALL set.fan({0})", speed));
                        break;
                    }
            }
        }

        private void parseMotionCommand(ASData a, GCodeData g)
        {
            switch (g.Command)
            {
                case 0:
                    {
                        this.g(a, g);
                        break;
                    }
                case 1:
                    {
                        this.g(a, g);
                        break;
                    }
                case 92:
                    {
                        a.AppendLine("CALL cut.feeder");
                        break;
                    }
                case 28:
                    {
                        a.AppendLine("SPEED 250 MM/S ALWAYS");
                        a.AppendLine("DRAW 0, 0, 100");
                        a.AppendLine("HOME");
                        break;
                    }
                default:
                    {
                        a.AppendLine(";" + g.OriginalLine);
                        break;
                    }
            }
        }

        public delegate void F(ProgressBar pb, int x);
        public ASData[] Parse(GCodeData[] data, F f = null, ProgressBar pb = null, bool dfi = false)
        {
            disableFeederInstruction = dfi;
            ASData[] ASCode = new ASData[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                ASData asData = new ASData();
                GCodeData gCodeData = data[i];

                switch (gCodeData.Type)
                {
                    case CommandType.Comment:
                        {
                            asData.AppendLine(gCodeData.Comment);
                            break;
                        }
                    case CommandType.Auxilary:
                        {
                            parseAuxilaryCommand(asData, gCodeData);
                            break;
                        }
                    case CommandType.Motion:
                        {
                            parseMotionCommand(asData, gCodeData);
                            break;
                        }
                    case CommandType.NAC:
                        {
                            asData.AppendLine(";");
                            break;
                        }
                }
                ASCode[i] = asData;

                if (i % 500 == 0) { f(pb, Convert.ToInt32(i * 100 / data.Length)); }
            }
            return ASCode;
        }

        private void g(ASData a, GCodeData g)
        {
            GData data = new GData(g.Parameters);
            string line;

            if (!Double.IsNaN(data.F))
            {
                line = string.Format("SPEED {0} MM/S ALWAYS", data.F/100);
                line = line.Replace(',', '.').Replace('@', ',');
                a.AppendLine(line);
            }
            if (!disableFeederInstruction)
            {
                if (!Double.IsNaN(data.E))
                {
                    line = string.Format("CALL set.feeder({0})", data.E);
                    line = line.Replace(',', '.').Replace('@', ',');
                    a.AppendLine(line);
                }
                else
                {
                    a.AppendLine("CALL set.feeder(0)");
                }
            }
            if (!Double.IsNaN(data.X))
            {
                lastX = data.X;
            }
            if (!Double.IsNaN(data.Y))
            {
                lastY = data.Y;
            }
            if (!Double.IsNaN(data.Z))
            {
                lastZ = data.Z;
            }

            line = string.Format("LMOVE f + TRANS({0}@ {1}@ {2})", lastX, lastY, lastZ);
            line = line.Replace(',', '.').Replace('@', ',');
            a.AppendLine(line);
        }

    }
}

