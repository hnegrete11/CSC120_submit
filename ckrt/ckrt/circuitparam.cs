using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ckrt
{
    class circuitparam
    {
        private double volt;
        private double[] outp;
        private int[] resist;
        private double refRest = 5000.0;
        private string strFilePath = @"Data.csv";
        public circuitparam(double volt)
        {
            this.volt = volt;
            this.outp= new double[10];

            this.resist = new int[10];
            
            
            for (int i=1;i<11;i++)
            {
                this.resist[i-1] = i*1000;
                
            }
            
        }
        public void simulation()
        {
           for(int i =0; i <10;i++)
            {
                outp[i] = this.volt *(this.resist[i] / (refRest+this.resist[i]));
            }
        }
        public void toData()
        {

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.Append(this.volt + ",");
            for (int i = 0; i < 10; i++)
            {
                sbOutput.Append(outp[i]+",");
            }
            sbOutput.AppendLine();
            File.AppendAllText(strFilePath, sbOutput.ToString());
        }
    }
}
