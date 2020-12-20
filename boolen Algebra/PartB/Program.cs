using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartB
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is the table
            var inputs = new List<IdentityInput>();
            inputs.Add(new IdentityInput() { A = false, D = false});
            inputs.Add(new IdentityInput() { A = false, D = true});
            inputs.Add(new IdentityInput() { A = true, D = false});
            inputs.Add(new IdentityInput() { A = true, D = true});

            foreach (var item in inputs)
            {
                var firstStepIdentity = new firstStepIdentity();
                firstStepIdentity.SetInputD = item.D;
                firstStepIdentity.SetInputA = item.A;
                var secondStepIdentity = new secondStepIdentity();
                secondStepIdentity.SetInputD = item.D;
                secondStepIdentity.SetInputA = item.A;

                Console.WriteLine($"X = {firstStepIdentity.SetInputA}\t" +
                        $"Y = {firstStepIdentity.SetInputD}\t" +
                        $"[ ~(x+y) = ~x.~y ] = {secondStepIdentity.Validate()}\t");
            }
            Console.WriteLine("\n");
            foreach (var item in inputs)
            {
                var thirdStepIdentity = new thirdStepIdentity();
                thirdStepIdentity.SetInputD = item.D;
                thirdStepIdentity.SetInputA = item.A;
                var fourthStepIdentity = new fourthStepIdentity();
                fourthStepIdentity.SetInputD = item.D;
                fourthStepIdentity.SetInputA = item.A;
                
                Console.WriteLine($"X = {thirdStepIdentity.SetInputA}\t" + 
                        $"Y = {thirdStepIdentity.SetInputD}\t" +
                        $"[ ~(x.y) = ~x+~y ] = {fourthStepIdentity.Validate()}\t");
            }
                Console.ReadLine();
        }
    }
}
