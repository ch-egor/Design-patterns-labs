using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class WheatHardness
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public decimal Cost { get; private set; }

        public WheatHardness(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
