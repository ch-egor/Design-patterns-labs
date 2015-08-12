using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomCheeseCoverFactory : ICheeseCoverFactory
    {
        private static RandomCheeseCoverFactory factory;

        private Random random;

        private static Dictionary<string, CheeseCover> CheeseCoversDict
            = new Dictionary<string, CheeseCover>();

        private static string[] cheeseCovers = { "Плёнка 40", "Парафин 20", };

        private CheeseCover CreateCheeseCover(string description)
        {
            if (CheeseCoversDict.ContainsKey(description))
                return CheeseCoversDict[description];
            else
            {
                string[] args = description.Split(new char[] { ' ' });
                if (args.Length != 2)
                    throw new ArgumentException();
                string name = args[0];
                decimal cost;
                if (decimal.TryParse(args[1], out cost))
                {
                    CheeseCover cheeseCover = new CheeseCover(name, cost);
                    CheeseCoversDict.Add(description, cheeseCover);
                    return cheeseCover;
                }
                else
                    throw new ArgumentException();
            }
        }

        public CheeseCover Create()
        {
            string cheeseCoverDescription = cheeseCovers[random.Next(cheeseCovers.Length)];
            return CreateCheeseCover(cheeseCoverDescription);
        }

        private RandomCheeseCoverFactory(Random random)
        {
            this.random = random;
        }

        public static RandomCheeseCoverFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomCheeseCoverFactory(random);
            else
                factory.random = random;
            return factory;
        }
    }
}
