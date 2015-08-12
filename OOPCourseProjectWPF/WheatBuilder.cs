using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class WheatBuilder
    {
        private WheatGrade grade;
        public WheatGrade Grade
        {
            get { return grade; }
            set { if (value != null) grade = value; }
        }

        private WheatHardness hardness;
        public WheatHardness Hardness
        {
            get { return hardness; }
            set { if (value != null) hardness = value; }
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

        public Wheat Build()
        {
            if (grade == null || hardness == null)
                throw new NullReferenceException();
            return new Wheat(grade, hardness)
            {
                PlannedNumber = plannedNumber,
                RealNumber = realNumber,
            };
        }
    }
}
