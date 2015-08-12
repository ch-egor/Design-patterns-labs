using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class CheeseBuilder
    {
        private CheeseKind kind;
        public CheeseKind Kind
        {
            get { return kind; }
            set { if (value != null) kind = value; }
        }

        private CheeseFatness fatness;
        public CheeseFatness Fatness
        {
            get { return fatness; }
            set { if (value != null) fatness = value; }
        }

        private CheeseCover cover;
        public CheeseCover Cover
        {
            get { return cover; }
            set { if (value != null) cover = value; }
        }

        private int plannedNumber = 0;
        public int PlannedNumber
        {
            get { return plannedNumber; }
            set { if (value >= 0) plannedNumber = value; }
        }

        private int realNumber = 0;
        public int RealNumber
        {
            get { return realNumber; }
            set { if (value >= 0) realNumber = value; }
        }

        public Cheese Build()
        {
            if (kind == null || fatness == null || cover == null)
                throw new NullReferenceException();
            return new Cheese(kind, fatness, cover)
            {
                PlannedNumber = plannedNumber,
                RealNumber = realNumber,
            };
        }
    }
}
