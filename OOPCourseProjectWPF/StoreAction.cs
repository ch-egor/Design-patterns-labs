using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract]
    [KnownType(typeof(StoreCheese))]
    [KnownType(typeof(StoreWheat))]
    abstract class StoreAction
    {
        public abstract double Store(int days);
    }
}
