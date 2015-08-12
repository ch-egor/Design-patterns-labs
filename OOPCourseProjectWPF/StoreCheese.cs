using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class StoreCheese : StoreAction
    {
        [DataMember]
        private int storageLifeInDays = 90;

        public override double Store(int days = 1)
        {
            return (double)days / storageLifeInDays;
        }
    }
}
