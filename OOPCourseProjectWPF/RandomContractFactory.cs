using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourseProjectWPF
{
    class RandomContractFactory : IContractFactory
    {
        private static RandomContractFactory factory;

        private Random random;

        //private RandomCheeseFactory randomCheeseFactory;
        //private RandomWheatFactory randomWheatFactory;

        private CheeseBuilder cheeseBuilder = new CheeseBuilder();
        private WheatBuilder wheatBuilder = new WheatBuilder();

        private ICheeseKindFactory cheeseKindFactory;
        private ICheeseFatnessFactory cheeseFatnessFactory;
        private ICheeseCoverFactory cheeseCoverFactory;

        private IWheatGradeFactory wheatGradeFactory;
        private IWheatHardnessFactory wheatHardnessFactory;

        private RandomContractFactory(Random random)
        {
            this.random = random;

            cheeseKindFactory = RandomCheeseKindFactory.CreateFactory(this.random);
            cheeseFatnessFactory = RandomCheeseFatnessFactory.CreateFactory(this.random);
            cheeseCoverFactory = RandomCheeseCoverFactory.CreateFactory(this.random);

            wheatGradeFactory = RandomWheatGradeFactory.CreateFactory(this.random);
            wheatHardnessFactory = RandomWheatHardnessFactory.CreateFactory(this.random);
        }

        public static RandomContractFactory CreateFactory(Random random)
        {
            if (factory == null)
                factory = new RandomContractFactory(random);
            else
                factory.random = random;
            //factory.randomCheeseFactory = RandomCheeseFactory.CreateFactory(random);
            //factory.randomWheatFactory = RandomWheatFactory.CreateFactory(random);
            return factory;
        }

        private string GenerateRandomString()
        {
            string randomString = String.Empty;
            int length = random.Next(3, 10);
            for (int i = 0; i < length; i++)
                randomString += (char)('A' + random.Next('Z' - 'A' + 1));
            return randomString;
        }

        private Storable RandomStorableFactory()
        {
            switch (random.Next(3))
            {
                case 0:
                    cheeseBuilder.Kind = cheeseKindFactory.Create();
                    cheeseBuilder.Fatness = cheeseFatnessFactory.Create();
                    cheeseBuilder.Cover = cheeseCoverFactory.Create();
                    cheeseBuilder.PlannedNumber = random.Next(100);
                    cheeseBuilder.RealNumber = random.Next(100);
                    return cheeseBuilder.Build();
                    //return randomCheeseFactory.Create();
                case 1:
                    wheatBuilder.Grade = wheatGradeFactory.Create();
                    wheatBuilder.Hardness = wheatHardnessFactory.Create();
                    wheatBuilder.PlannedNumber = random.Next(100);
                    wheatBuilder.RealNumber = random.Next(100);
                    return wheatBuilder.Build();
                    //return randomWheatFactory.Create();
                default:
                    return this.Create();
            }
        }

        public Contract Create()
        {
            Contract newContract = new Contract
            {
                Name = GenerateRandomString(),
                Supplier = GenerateRandomString(),
                Purchaser = GenerateRandomString(),
            };
            int maxItems = random.Next(1, 5);
            for (int i = 0; i < maxItems; i++)
                newContract.Add(RandomStorableFactory());
            return newContract;
        }
    }
}
