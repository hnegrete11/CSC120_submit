using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Gates.Composite;
namespace BoolAlgebra
{
    
    class identity
    {
        public bool SetInputD { get; set; }
        public bool SetInputA { get; set; }
        public bool andValidate()
        {
            var logicCircuitAND = new AND();
            logicCircuitAND.SetInputA(SetInputA);
            logicCircuitAND.SetInputB(SetInputD);
            return logicCircuitAND.Output;
        }
        public bool orValidate()
        {
            var logicCircuitOR = new OR();
            logicCircuitOR.SetInputA(SetInputA);
            logicCircuitOR.SetInputB(SetInputD);
            return logicCircuitOR.Output;
        }
        public bool notValidate()
        {
            var logicCircuitNot = new NOT();
            logicCircuitNot.SetInputA(SetInputA);
            return logicCircuitNot.Output;
        }
        public bool norValidate()
        {
            var logicCircuitOR = new OR();
            var notOut = new NOT();
            logicCircuitOR.SetInputA(SetInputA);
            logicCircuitOR.SetInputB(SetInputD);
            notOut.SetInputA(logicCircuitOR.Output);
            return notOut.Output;
        }
        public bool nandValidate()
        {
            var notOut = new NOT();
            var logicCircuitAND = new AND();
            logicCircuitAND.SetInputA(SetInputA);
            logicCircuitAND.SetInputB(SetInputD);
            notOut.SetInputA(logicCircuitAND.Output);
            return notOut.Output;
        }
        public bool xnorValidate()
        {

            var logicCircuitOR = new OR();
            var logicCircuitAND1 = new AND();
            var logicCircuitAND2 = new AND();
            var notOp = new NOT();
            logicCircuitAND1.SetInputA(SetInputA);
            logicCircuitAND1.SetInputB(SetInputD);

            
            notOp.SetInputA(SetInputA);
            logicCircuitAND2.SetInputA(notOp.Output);
            notOp.SetInputA(SetInputD);
            logicCircuitAND2.SetInputB(notOp.Output);

            logicCircuitOR.SetInputA(logicCircuitAND1.Output);
            logicCircuitOR.SetInputB(logicCircuitAND2.Output);
            return logicCircuitOR.Output;
        }
        public bool xorValidate()
        {
            var logicCircuitOR = new OR();
            var logicCircuitAND1 = new AND();
            var logicCircuitAND2 = new AND();
            var notOp = new NOT();
            notOp.SetInputA(SetInputA);
            logicCircuitAND1.SetInputA(notOp.Output);
            logicCircuitAND1.SetInputB(SetInputD);
            

            notOp.SetInputA(SetInputD);
            logicCircuitAND2.SetInputA(notOp.Output);
            logicCircuitAND2.SetInputB(SetInputA);
            logicCircuitOR.SetInputA(logicCircuitAND1.Output);
            logicCircuitOR.SetInputB(logicCircuitAND2.Output);
            return logicCircuitOR.Output;
        }
    }
}
