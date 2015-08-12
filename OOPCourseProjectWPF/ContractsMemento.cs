using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class ContractsMemento
    {
        public readonly Contract[] State;

        public ContractsMemento(IEnumerable<Contract> state)
        {
            this.State = state.ToArray();
        }
    }
}
