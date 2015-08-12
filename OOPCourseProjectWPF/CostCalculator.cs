using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CheeseCostCalculator))]
    [KnownType(typeof(WheatCostCalculator))]
    [KnownType(typeof(ContractCostCalculator))]
    abstract class CostCalculator
    {
        private decimal discount;
        public decimal Discount
        {
            get { return discount; }
            set { if (value >= 0 && value <= 1) discount = value; }
        }

        public abstract decimal Calculate();

        public CostCalculator()
        {
            discount = 0;
        }
    }
}
