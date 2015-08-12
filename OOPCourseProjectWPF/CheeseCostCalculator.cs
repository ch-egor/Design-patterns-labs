using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract(IsReference = true)]
    class CheeseCostCalculator : CostCalculator
    {
        [DataMember]
        private Cheese cheese;

        public override decimal Calculate()
        {
            decimal totalCost = 0;
            totalCost += cheese.Kind.Cost;
            totalCost += cheese.Fatness.Cost;
            totalCost += cheese.Cover.Cost;
            totalCost *= cheese.RealNumber;
            totalCost *= 1 - Discount;
            return totalCost;
        }

        public CheeseCostCalculator(Cheese cheese)
        {
            this.cheese = cheese;
        }
    }
}
