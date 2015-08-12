using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomCheeseFactory
    {
        private static RandomCheeseFactory factory;

        private Random random;

        private ICheeseKindFactory cheeseKindFactory;
        private ICheeseFatnessFactory cheeseFatnessFactory;
        private ICheeseCoverFactory cheeseCoverFactory;

        private RandomCheeseFactory(Random random)
        {
            this.random = random;
            cheeseKindFactory = RandomCheeseKindFactory.CreateFactory(this.random);
            cheeseFatnessFactory = RandomCheeseFatnessFactory.CreateFactory(this.random);
            cheeseCoverFactory = RandomCheeseCoverFactory.CreateFactory(this.random);
        }

        public static RandomCheeseFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomCheeseFactory(random);
            else
                factory.random = random;
            return factory;
        }

        public Cheese Create()
        {
            CheeseKind kind = cheeseKindFactory.Create();
            CheeseFatness fatness = cheeseFatnessFactory.Create();
            CheeseCover cover = cheeseCoverFactory.Create();

            return new Cheese(kind, fatness, cover)
            {
                PlannedNumber = random.Next(100),
                RealNumber = random.Next(100),
            };
        }
    }
}
