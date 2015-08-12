using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomCheeseKindFactory : ICheeseKindFactory
    {
        private static RandomCheeseKindFactory factory;
        
        private Random random;

        private static Dictionary<string, CheeseKind> CheeseKindsDict
            = new Dictionary<string, CheeseKind>();

        private static string[] cheeseKinds = { "Алтайский 150", "Радонежский 80", "Голландский 120", };

        private CheeseKind CreateCheeseKind(string description)
        {
            if (CheeseKindsDict.ContainsKey(description))
                return CheeseKindsDict[description];
            else
            {
                string[] args = description.Split(new char[] { ' ' });
                if (args.Length != 2)
                    throw new ArgumentException();
                string name = args[0];
                decimal cost;
                if (decimal.TryParse(args[1], out cost))
                {
                    CheeseKind cheeseKind = new CheeseKind(name, cost);
                    CheeseKindsDict.Add(description, cheeseKind);
                    return cheeseKind;
                }
                else
                    throw new ArgumentException();
            }
        }

        public CheeseKind Create()
        {
            string cheeseKindDescription = cheeseKinds[random.Next(cheeseKinds.Length)];
            return CreateCheeseKind(cheeseKindDescription);
        }

        private RandomCheeseKindFactory(Random random)
        {
            this.random = random;
        }

        public static RandomCheeseKindFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomCheeseKindFactory(random);
            else
                factory.random = random;
            return factory;
        }
    }
}
