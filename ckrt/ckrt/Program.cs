using System;
using System.IO;
using System.Text;

namespace ckrt
{
    class Program
    {
        private string strFilePath = @"Data.csv";
        static void Main(string[] args)
        {

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.Append(" " + ",");
            for (int i = 1; i < 11; i++)
            {
                sbOutput.Append(i * 1000 + ",");
            }
            sbOutput.AppendLine();
            File.WriteAllText(@"Data.csv", sbOutput.ToString());
            for (int i = 5; i <= 50; i += 5)
            {
                var crkt = new circuitparam(i);
                crkt.simulation();
                crkt.toData();
            }

        }
    }
}
