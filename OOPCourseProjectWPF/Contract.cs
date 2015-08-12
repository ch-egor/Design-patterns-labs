using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class Contract : Storable, ICollection<Storable>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Supplier { get; set; }

        [DataMember]
        public string Purchaser { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
        public string DateString
        {
            get { return Date.ToShortDateString(); }
            set
            {
                DateTime tempDate;
                if (DateTime.TryParse(value, out tempDate))
                    Date = tempDate;
            }
        }

        [DataMember]
        private List<Storable> items = new List<Storable>();

        public Contract()
        {
            this.Name = String.Empty;
            this.Supplier = String.Empty;
            this.Purchaser = String.Empty;
            this.Date = DateTime.Today;
            this.costCalculator = new ContractCostCalculator(this);
        }

        public Contract(IEnumerable<Storable> items) : this()
        {
            this.items = new List<Storable>(items);
        }

        public override int PlannedNumber
        {
            get
            {
                int plannedNumber = 0;
                foreach (Storable item in items)
                    plannedNumber += item.PlannedNumber;
                return plannedNumber;
            }
            set { }
        }

        public override int RealNumber
        {
            get
            {
                int realNumber = 0;
                foreach (Storable item in items)
                    realNumber += item.RealNumber;
                return realNumber;
            }
            set { }
        }

        public override void Store(int days = 1)
        {
            foreach (Storable item in items)
                item.Store(days);
        }

        public IEnumerator<Storable> GetEnumerator()
        {
            return new StorableEnumerator(items);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Storable item) { items.Add(item); }

        public void Clear() { items.Clear(); }

        public bool Contains(Storable item) { return items.Contains(item); }

        public void CopyTo(Storable[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (Storable item in items)
                array[i++] = item;
        }

        public int Count { get { return items.Count; } }

        public bool IsReadOnly { get { return false; } }

        public bool Remove(Storable item) { return items.Remove(item); }
    }
}
