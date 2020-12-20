using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicCircuit.Gates.Simple;

namespace BoolAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new List<IdentityInput>();
            inputs.Add(new IdentityInput() { A = false, D = false });
            inputs.Add(new IdentityInput() { A = false, D = true });
            inputs.Add(new IdentityInput() { A = true, D = false });
            inputs.Add(new IdentityInput() { A = true, D = true });
            foreach (var item in inputs)
            {
                var andIdentity = new identity();
                andIdentity.SetInputD = item.D;
                andIdentity.SetInputA = item.A;

                var orIdentity = new identity();
                orIdentity.SetInputD = item.D;
                orIdentity.SetInputA = item.A;

                var notIdentity = new identity();
                notIdentity.SetInputA = item.A;

                var norIdentity = new identity();
                norIdentity.SetInputD = item.D;
                norIdentity.SetInputA = item.A;

                var NANDIdentity = new identity();
                NANDIdentity.SetInputD = item.D;
                NANDIdentity.SetInputA = item.A;

                var XorIdentity = new identity();
                XorIdentity.SetInputD = item.D;
                XorIdentity.SetInputA = item.A;

                var XnorIdentity = new identity();
                XnorIdentity.SetInputD = item.D;
                XnorIdentity.SetInputA = item.A;

                Console.WriteLine($"X = {andIdentity.SetInputA}\t" +
                        $"Y = {andIdentity.SetInputD}\t" +
                        $"[ x+y ] = {orIdentity.orValidate()}\t"+
                        $"[ x*y ] = {orIdentity.andValidate()}\t" +
                        $"[ ~x ] = {notIdentity.notValidate()}\t"+
                        $"[ NAND(X,y) ] = {NANDIdentity.nandValidate()}\t" +
                        $"[ NOR(X,Y)] = {norIdentity.norValidate()}\t" +
                        $"[XOR(X,Y) ] = {XorIdentity.xorValidate()}\t" +
                        $"[ XNOR(X,Y) ] = {XnorIdentity.xnorValidate()}\t");
            }

            Console.ReadLine();
        }
    }
}
