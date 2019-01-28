using System;

namespace AbstractFactory
{
    //*************** interfaces
    public interface ILampFactory
    {
        ILampType CreateLamp(); // produkt A
        ILampStand CreateStand(); // produkt B

    }

    public interface ILampStand
    {
        string LampStandInfo();
    }

    public interface ILampType
    {
        string LampInfo();
    }
    //************************
    // Implementations of factory interface


    class UppsalaFactory : ILampFactory
    {
        public ILampType CreateLamp()
        {
            return new Halogen();
        }

        public ILampStand CreateStand()
        {
            return new WoodStand();
        }
    }

    class StockholmFactory : ILampFactory
    {
        public ILampType CreateLamp()
        {
            return new Led();
        }

        public ILampStand CreateStand()
        {
            return new GoldStand();
        }
    }




    //*******************
    // product implementations

    class Halogen : ILampType
    {
        public string LampInfo()
        {
            // TODO add info of this lamp
            return "Halogen lamp";
        }
    }

    class Led : ILampType
    {
        public string LampInfo()
        {
            return "LED-light";
        }
    }

    class WoodStand : ILampStand
    {
        public string LampStandInfo()
        {
            return "This is a wood stand";
        }
    }

    class GoldStand : ILampStand
    {
        public string LampStandInfo()
        {
            return "This is a gold stand";
        }
    }

    //*************************************

    class Customer
    {
        public ILampFactory CreateProductFromFactory(string fac)
        {
            if(fac.Equals("Uppsala"))
                return new UppsalaFactory();
            if (fac.Equals("Stockholm"))
                return new StockholmFactory();

            return null;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
       
            Customer client = new Customer();
            ILampFactory lampFactory = client.CreateProductFromFactory("Stockholm");

            Console.WriteLine(lampFactory.CreateLamp().LampInfo());
            Console.WriteLine(lampFactory.CreateStand().LampStandInfo());

        }
    }
}
