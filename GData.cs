using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KGCtASP
{
    internal class GData
    {
        private double x, y, z, e, f;

        public double X { get => x; }
        public double Y { get => y; }
        public double Z { get => z; }
        public double E { get => e; }
        public double F { get => f; }


        public GData(List<string> parameters)
        {
            x = double.NaN;
            y = double.NaN;
            z = double.NaN;
            e = double.NaN;
            f = double.NaN;

            foreach (string p in parameters)
            {
                if (p.StartsWith("X"))
                {
                    x = Convert.ToDouble(p.Substring(1).Replace('.', ','));
                }
                if (p.StartsWith("Y"))
                {
                    y = Convert.ToDouble(p.Substring(1).Replace('.', ','));
                }
                if (p.StartsWith("Z"))
                {
                    z = Convert.ToDouble(p.Substring(1).Replace('.', ','));
                }
                if (p.StartsWith("E"))
                {
                    e = Convert.ToDouble(p.Substring(1).Replace('.', ','));
                }
                if (p.StartsWith("F"))
                {
                    f = Convert.ToDouble(p.Substring(1).Replace('.', ','));
                }
            }
        }
    }
}
