using STLATCh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLATCH
{
    class Program
    {
        static void Main(string[] args)
        {
           // Memory();
            //Conversion();
            var inputPutDataFile = @"C:\Data\inputdata.txt.txt";
            var truthTableInputs = Storage.ReadTruthTableData(inputPutDataFile);
            int ctr = 0;
            int stp_pos = Storage.ReadData();
            Console.WriteLine("S\tR\tQ_prev\tQ");
            if(stp_pos==0)
                Storage.SaveTT($"S\tR\tQ_prev\tQ\n",0);


            foreach (var input in truthTableInputs)
            {
                if (stp_pos > ctr)
                {
                    ctr++;
                    continue;
                }
                if (input.S && !input.R)
                {
                    Console.WriteLine($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit((true))}");
                    Storage.SaveTT($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit((true))}\n",ctr);
                }
                else if (!input.S && input.R)
                {
                    Console.WriteLine($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit(false)}");
                    Storage.SaveTT($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit(false)}\n",ctr);
                }
                else if (!input.S && !input.R)
                {
                    Console.WriteLine($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit(input.Q_prev)}");
                    Storage.SaveTT($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\t{Utility.ConvertToBit(input.Q_prev)}\n",ctr);
                }
                else
                {
                    Console.WriteLine($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\tInvalid");
                    Storage.SaveTT($"{Utility.ConvertToBit(input.S)},\t{Utility.ConvertToBit(input.R)},\t{Utility.ConvertToBit(input.Q_prev)},\tInvalid\n",ctr);
                }
                ctr++;
                Storage.SaveData(ctr);
                
               
            }
            if(ctr==8)
                Storage.SaveData(0);

         }
    
    }
}
