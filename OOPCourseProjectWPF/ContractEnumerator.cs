using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class ContractEnumerator : IEnumerator<Contract>
    {
        private Contract[] items;
        private int current = -1;

        public Contract Current { get { return items[current]; } }

        public void Dispose() { return; }

        object System.Collections.IEnumerator.Current { get { return Current; } }

        public bool MoveNext() { return ++current < items.Length ? true : false;  }

        public void Reset() { current = -1; }

        public ContractEnumerator(IEnumerable<Contract> items) { this.items = items.ToArray(); }
    }
}
