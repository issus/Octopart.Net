using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Octopart.Net.Utilities
{
    public static class Units
    {
        public static string ToScientific(string str)
        {
            Regex r = new Regex(@"(?<Value>[\.0-9]+)\s*(?<Units>[mkunpMG])");
            Match m = r.Match(str.Trim());
            if (m.Success)
            {
                double val = double.Parse(m.Groups["Value"].Value);
                switch (m.Groups["Units"].Value.ToString())
                {
                    case "m": val *= 1E-3; break;
                    case "k": val *= 1E3; break;
                    case "u": val *= 1E-6; break;
                    case "n": val *= 1E-9; break;
                    case "p": val *= 1E-12; break;
                    case "M": val *= 1E6; break;
                    case "G": val *= 1E9; break;
                }
                return val.ToString("E3");
            }
            r = new Regex(@"([\.0-9]+)$");
            m = r.Match(str);
            if (m.Success)
            {
                float val = float.Parse(m.Groups[1].Value.ToString());
                return val.ToString("E3");
            }
            throw new Exception("Unable to parse " + str);
        }
    }
}
