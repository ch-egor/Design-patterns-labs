using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract(IsReference = true)]
    class WheatCostCalculator : CostCalculator
    {
        [DataMember]
        private Wheat wheat;

        public override decimal Calculate()
        {
            decimal totalCost = 0;
            totalCost += wheat.Grade.Cost;
            totalCost += wheat.Hardness.Cost;
            totalCost *= wheat.RealNumber;
            totalCost *= 1 - Discount;
            return totalCost;
        }

        public WheatCostCalculator(Wheat wheat)
        {
            this.wheat = wheat;
        }
    }
}
