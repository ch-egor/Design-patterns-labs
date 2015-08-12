using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract(IsReference = true)]
    class ContractCostCalculator : CostCalculator
    {
        [DataMember]
        Contract contract;

        public override decimal Calculate()
        {
            decimal totalCost = 0;
            foreach (Storable item in contract)
                totalCost += item.Cost;
            return totalCost;
        }

        public ContractCostCalculator(Contract contract)
        {
            this.contract = contract;
        }
    }
}
