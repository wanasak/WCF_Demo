using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in both code and config file together.
    public class CalculatorService : ICalculatorService
    {
        public int Devide(int numerator, int denominator)
        {
            //.NET exception
            //if (denominator == 0) throw new DivideByZeroException();
            // WCF exception
            //if (denominator == 0) throw new FaultException("Denomintor cannot be ZERO", new FaultCode("DivideByZeroException"));
            try
            {
                return numerator / denominator;
            }
            catch (DivideByZeroException ex)
            {
                DivideByZeroFault fault = new DivideByZeroFault();
                fault.Error = ex.Message;
                fault.Details = "Denominator cannot be ZERO";
                throw new FaultException<DivideByZeroFault>(fault);
            }
        }
    }
}
