using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class CheeseFatness
    {
        [DataMember]
        public int Value { get; private set; }

        [DataMember]
        public decimal Cost { get; private set; }

        public CheeseFatness(int value, decimal cost)
        {
            this.Value = value;
            this.Cost = cost;
        }
    }
}
