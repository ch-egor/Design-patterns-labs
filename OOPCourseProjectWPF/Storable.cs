using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    [DataContract]
    [KnownType(typeof(Cheese))]
    [KnownType(typeof(Wheat))]
    [KnownType(typeof(Contract))]
    abstract class Storable
    {
        [DataMember]
        private int realNumber = 0;
        public virtual int RealNumber
        {
            get { return realNumber; }
            set { if (value >= 0) realNumber = value; }
        }

        [DataMember]
        private int plannedNumber = 0;
        public virtual int PlannedNumber
        {
            get { return plannedNumber; }
            set { if (value >= 0) plannedNumber = value; }
        }

        [DataMember]
        private decimal cost = 0;
        public decimal Cost
        {
            get { return costCalculator.Calculate(); }
        }

        [DataMember]
        public double Staleness { get; private set; }

        [DataMember]
        protected StoreAction storeAction;

        [DataMember]
        protected CostCalculator costCalculator;

        public virtual void Store(int days = 1)
        {
            if (storeAction != null)
                Staleness += storeAction.Store(days);
        }

        public Storable()
        {
            this.Staleness = 0;
            this.PlannedNumber = 0;
            this.RealNumber = 0;
        }
    }
}
