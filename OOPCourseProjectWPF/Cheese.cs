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
    class Cheese : Storable
    {
        [DataMember]
        public CheeseKind Kind { get; private set; }

        [DataMember]
        public CheeseFatness Fatness { get; private set; }

        [DataMember]
        public CheeseCover Cover { get; private set; }

        public Cheese(CheeseKind kind, CheeseFatness fatness, CheeseCover cover)
            : base()
        {
            this.Kind = kind;
            this.Fatness = fatness;
            this.Cover = cover;
            this.storeAction = new StoreCheese();
            this.costCalculator = new CheeseCostCalculator(this);
        }
    }
}
