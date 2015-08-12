using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomCheeseFatnessFactory : ICheeseFatnessFactory
    {
        private static RandomCheeseFatnessFactory factory;

        private Random random;

        private static Dictionary<string, CheeseFatness> CheeseFatnessesDict
            = new Dictionary<string, CheeseFatness>();

        private static string[] cheeseFatnesses = { "30 5", "40 10", "50 15", };

        private CheeseFatness CreateCheeseFatness(string description)
        {
            if (CheeseFatnessesDict.ContainsKey(description))
                return CheeseFatnessesDict[description];
            else
            {
                string[] args = description.Split(new char[] { ' ' });
                if (args.Length != 2)
                    throw new ArgumentException();
                int value;
                decimal cost;
                if (int.TryParse(args[0], out value) && decimal.TryParse(args[1], out cost))
                {
                    CheeseFatness cheeseFatness = new CheeseFatness(value, cost);
                    CheeseFatnessesDict.Add(description, cheeseFatness);
                    return cheeseFatness;
                }
                else
                    throw new ArgumentException();
            }
        }

        public CheeseFatness Create()
        {
            string cheeseFatnessDescription = cheeseFatnesses[random.Next(cheeseFatnesses.Length)];
            return CreateCheeseFatness(cheeseFatnessDescription);
        }

        private RandomCheeseFatnessFactory(Random random)
        {
            this.random = random;
        }

        public static RandomCheeseFatnessFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomCheeseFatnessFactory(random);
            else
                factory.random = random;
            return factory;
        }
    }
}
