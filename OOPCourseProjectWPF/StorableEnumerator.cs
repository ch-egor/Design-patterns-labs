using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPCourseProjectWPF
{
    class StorableEnumerator : IEnumerator<Storable>
    {
        private Storable[] items;
        private int current = -1;

        public Storable Current { get { return items[current]; } }

        public void Dispose() { return; }

        object System.Collections.IEnumerator.Current { get { return Current; } }

        public bool MoveNext() { return ++current < items.Length ? true : false;  }

        public void Reset() { current = -1; }

        public StorableEnumerator(IEnumerable<Storable> items) { this.items = items.ToArray(); }
    }
}
