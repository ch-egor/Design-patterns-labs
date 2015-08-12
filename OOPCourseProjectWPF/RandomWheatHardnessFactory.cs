using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomWheatHardnessFactory : IWheatHardnessFactory
    {
        private static RandomWheatHardnessFactory factory;

        private Random random;

        private static Dictionary<string, WheatHardness> WheatHardnessesDict
            = new Dictionary<string, WheatHardness>();

        private static string[] WheatHardnesses = { "Твёрдая 25", "Мягкая 50", };

        private WheatHardness CreateWheatHardness(string description)
        {
            if (WheatHardnessesDict.ContainsKey(description))
                return WheatHardnessesDict[description];
            else
            {
                string[] args = description.Split(new char[] { ' ' });
                if (args.Length != 2)
                    throw new ArgumentException();
                string name = args[0];
                decimal cost;
                if (decimal.TryParse(args[1], out cost))
                {
                    WheatHardness wheatHardness = new WheatHardness(name, cost);
                    WheatHardnessesDict.Add(description, wheatHardness);
                    return wheatHardness;
                }
                else
                    throw new ArgumentException();
            }
        }

        public WheatHardness Create()
        {
            string wheatHardnessDescription = WheatHardnesses[random.Next(WheatHardnesses.Length)];
            return CreateWheatHardness(wheatHardnessDescription);
        }

        private RandomWheatHardnessFactory(Random random)
        {
            this.random = random;
        }

        public static RandomWheatHardnessFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomWheatHardnessFactory(random);
            else
                factory.random = random;
            return factory;
        }
    }
}
