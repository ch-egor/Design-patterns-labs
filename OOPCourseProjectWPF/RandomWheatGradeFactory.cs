using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomWheatGradeFactory : IWheatGradeFactory
    {
        private static RandomWheatGradeFactory factory;

        private Random random;

        private static Dictionary<string, WheatGrade> WheatGradesDict
            = new Dictionary<string, WheatGrade>();

        private static string[] WheatGrades = { "Нестандартный 200", "3-й 150", "4-й 100", };

        private WheatGrade CreateWheatGrade(string description)
        {
            if (WheatGradesDict.ContainsKey(description))
                return WheatGradesDict[description];
            else
            {
                string[] args = description.Split(new char[] { ' ' });
                if (args.Length != 2)
                    throw new ArgumentException();
                string name = args[0];
                decimal cost;
                if (decimal.TryParse(args[1], out cost))
                {
                    WheatGrade wheatGrade = new WheatGrade(name, cost);
                    WheatGradesDict.Add(description, wheatGrade);
                    return wheatGrade;
                }
                else
                    throw new ArgumentException();
            }
        }

        public WheatGrade Create()
        {
            string wheatGradeDescription = WheatGrades[random.Next(WheatGrades.Length)];
            return CreateWheatGrade(wheatGradeDescription);
        }

        private RandomWheatGradeFactory(Random random)
        {
            this.random = random;
        }

        public static RandomWheatGradeFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomWheatGradeFactory(random);
            else
                factory.random = random;
            return factory;
        }
    }
}
