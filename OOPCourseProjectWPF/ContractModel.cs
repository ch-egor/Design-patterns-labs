using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OOPCourseProjectWPF
{
    [DataContract]
    class ContractModel : ICollection<Contract>
    {
        [DataMember]
        private List<Contract> contracts = new List<Contract>();
        private ContractsMemento contractsMemento;

        private List<IObserver> observers = new List<IObserver>();

        public static ContractModel LoadState(string filename)
        {
            ContractModel contractModel;
            try
            {
                using (Stream inputStream = File.OpenRead(filename))
                {
                    DataContractSerializer serializer
                        = new DataContractSerializer(typeof(ContractModel));
                    contractModel = serializer.ReadObject(inputStream) as ContractModel;
                }
            }
            catch (FileNotFoundException) { return new ContractModel(); }
            catch (SerializationException) { return new ContractModel(); }
            return contractModel;
        }

        public void SaveState(string filename)
        {
            File.Delete(filename);
            using (Stream outputStream = File.OpenWrite(filename))
            {
                DataContractSerializer serializer
                    = new DataContractSerializer(typeof(ContractModel));
                serializer.WriteObject(outputStream, this);
            }
        }

        public Contract this[int index]
        {
            get { return contracts[index]; }
            set { contracts[index] = value; OnCollectionChanged(); }
        }

        public void Add(Contract item)
        {
            contractsMemento = new ContractsMemento(contracts);
            contracts.Add(item);
            OnCollectionChanged();
        }

        public void Clear()
        {
            contractsMemento = new ContractsMemento(contracts); 
            contracts.Clear();
            OnCollectionChanged();
        }

        public bool Contains(Contract item) { return contracts.Contains(item); }

        public void CopyTo(Contract[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (Contract item in contracts)
                array[i++] = item;
        }

        public int Count { get { return contracts.Count; } }

        public bool IsReadOnly { get { return false; } }

        public bool Remove(Contract item)
        {
            contractsMemento = new ContractsMemento(contracts);
            bool result = contracts.Remove(item);
            OnCollectionChanged();
            return result;
        }

        public IEnumerator<Contract> GetEnumerator()
        {
            return new ContractEnumerator(contracts);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Revert()
        {
            if (contractsMemento != null)
            {
                contracts = new List<Contract>(contractsMemento.State);
                OnCollectionChanged();
            }
        }

        public void Subscribe(IObserver observer)
        {
            if (observers == null)
                observers = new List<IObserver>();
            if (!observers.Contains(observer))
                observers.Add(observer);
            observer.Notify();
        }

        public void Unsubscribe(IObserver observer)
        {
            while (observers.Contains(observer))
                observers.Remove(observer);
        }

        protected void OnCollectionChanged()
        {
            foreach (IObserver observer in observers)
                observer.Notify();
        }
    }
}
