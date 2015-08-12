using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomWheatFactory
    {
        private static RandomWheatFactory factory;

        private Random random;

        private IWheatGradeFactory wheatGradeFactory;
        private IWheatHardnessFactory wheatHardnessFactory;

        private RandomWheatFactory(Random random)
        {
            this.random = random;
            wheatGradeFactory = RandomWheatGradeFactory.CreateFactory(this.random);
            wheatHardnessFactory = RandomWheatHardnessFactory.CreateFactory(this.random);
        }

        public static RandomWheatFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomWheatFactory(random);
            else
                factory.random = random;
            return factory;
        }

        public Wheat Create()
        {
            WheatGrade grade = wheatGradeFactory.Create();
            WheatHardness hardness = wheatHardnessFactory.Create();

            return new Wheat(grade, hardness)
            {
                PlannedNumber = random.Next(100),
                RealNumber = random.Next(100),
            };
        }
    }
}
