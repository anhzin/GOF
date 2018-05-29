using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.RealWorld
{
    /// <summary>

    /// MainApp startup class for Real-World

    /// Abstract Factory Design Pattern.

    /// </summary>

    class MainApp

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        public static void Main()
        {
            // Create and run the African animal world

            ContinentFactory africa = new AfricaFactory();
            Ecosystem ecosystem = new Ecosystem(africa);
            ecosystem.RunFoodChain();

            // Create and run the Australia animal world

            ContinentFactory australia = new AustraliaFactory();
            ecosystem = new Ecosystem(australia);
            ecosystem.RunFoodChain();

            // Wait for user input

            Console.ReadKey();
        }
    }


    /// <summary>

    /// The 'AbstractFactory' abstract class

    /// </summary>

    abstract class ContinentFactory

    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>

    /// The 'ConcreteFactory1' class

    /// </summary>

    class AfricaFactory : ContinentFactory

    {
        public override Herbivore CreateHerbivore()
        {
            return new Zebra();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>

    /// The 'ConcreteFactory2' class

    /// </summary>

    class AustraliaFactory : ContinentFactory

    {
        public override Herbivore CreateHerbivore()
        {
            return new Kangaroo();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Dingo();
        }
    }

    /// <summary>

    /// The 'AbstractProductA' abstract class

    /// </summary>

    abstract class Herbivore

    {
    }

    /// <summary>

    /// The 'AbstractProductB' abstract class

    /// </summary>

    abstract class Carnivore

    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>

    /// The 'ProductA1' class

    /// </summary>

    class Zebra : Herbivore

    {
    }

    /// <summary>

    /// The 'ProductB1' class

    /// </summary>

    class Lion : Carnivore

    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest

            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>

    /// The 'ProductA2' class

    /// </summary>

    class Kangaroo : Herbivore

    {
    }

    /// <summary>

    /// The 'ProductB2' class

    /// </summary>

    class Dingo : Carnivore

    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison

            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>

    /// The 'Client' class 

    /// </summary>

    class Ecosystem

    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor

        public Ecosystem(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
