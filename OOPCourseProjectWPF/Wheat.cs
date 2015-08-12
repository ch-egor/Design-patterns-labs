using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class Wheat : Storable
    {
        [DataMember]
        public WheatGrade Grade { get; private set; }
        
        [DataMember]
        public WheatHardness Hardness { get; private set; }

        public Wheat(WheatGrade grade, WheatHardness hardness)
            : base()
        {
            this.Grade = grade;
            this.Hardness = hardness;
            this.storeAction = new StoreWheat();
            this.costCalculator = new WheatCostCalculator(this);
        }
    }
}
