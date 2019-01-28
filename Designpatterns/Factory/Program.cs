using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory

{
    public interface ICarSupplier
    {
        string CarColor { get; }
        void GetCarModel();
    }

    class BMW : ICarSupplier
    {
        public string CarColor => "Black";

        public void GetCarModel()
        {
            Console.WriteLine("This is a model M5");
        }
    }

    class Volvo : ICarSupplier
    {
        public string CarColor => "Red";

        public void GetCarModel()
        {
            Console.WriteLine("This is a model 740");
        }
    }

    class Audi : ICarSupplier
    {
        public string CarColor => "White";

        public void GetCarModel()
        {
            Console.WriteLine("This is a model R8");
        }
    }

    class CarFactory
    {
        public static ICarSupplier GetCarInstance(int id)
        {
            switch (id)
            {
                case 0:
                    return new Audi();
                case 1:
                    return new BMW();
                case 2:
                    return new Volvo();
                default: return null;
            }
        }
    }


    class Showcase
    {
        private enum Carmodels
        {
            Audi,
            Bmw,
            Volvo
        };

        public void BeginShowCase()
        {
            ICarSupplier objCarSupplier = CarFactory.GetCarInstance((int)Carmodels.Audi);
            objCarSupplier.GetCarModel();
            Console.WriteLine("And the color is " + objCarSupplier.CarColor);

            objCarSupplier = CarFactory.GetCarInstance((int)Carmodels.Bmw);
            objCarSupplier.GetCarModel();
            Console.WriteLine("And the color is " + objCarSupplier.CarColor);

            Console.ReadLine();

        }

        static void Main(string[] args)
        {
            Showcase show = new Showcase();
            show.BeginShowCase();

        }
    }
}