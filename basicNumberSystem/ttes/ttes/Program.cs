using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number for convervesion: ");
            int inp = Convert.ToInt32(Console.ReadLine());
            int q, rem=0, newNo=0;
            int pw = 0;
            while (true)
            {
                int v = (int)Math.Pow(8, pw);
                int t = v;
                if (t > inp)
                {
                    pw -= 1;
                    break;
                }
                pw += 1;
            }
            for(int i=pw;i>0;i--)
            {
                rem = inp % (int)Math.Pow(8, i);
                q = inp / (int)Math.Pow(8, i);
                newNo = newNo * 10 + q;
                inp = rem;
            }
            newNo = newNo * 10 + rem;
            Console.WriteLine("Converted number: " + newNo.ToString());
            Console.ReadLine();
        }
    }
}
