using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // tips 

           /* Dictionary<string, IStrategy> strategies = new Dictionary<string, IStrategy>() {
                { "st1", new ConcreteStrategyA() },
                { "st2", new ConcreteStrategyB() }
            };*/

            CalculateArea calculateArea = new CalculateArea();
            IStrategy s = new SquareStrategy();

            calculateArea.Strategy = s; // inject strategy

            calculateArea.Calculate(2,5);



        }
    }

    public class CalculateArea
    {
        public IStrategy Strategy { get; set; }

        public CalculateArea()
        {
            Strategy = new RectangleStrategy();
        }

        public void Calculate(float a, float b)
        {
            Console.WriteLine("Area is: " + Strategy.Algorithm(a,b));
        }



    }

    public interface IStrategy
    {
        float Algorithm(float a, float b);
    }

    public class SquareStrategy : IStrategy
    {
        public float Algorithm(float a, float b)
        {
            return a * a;
        }
    }

    public class RectangleStrategy : IStrategy
    {
        public float Algorithm(float a, float b)
        {
            return a * b;
        }
    }



}

// uppgift - grupp 
// Ni skall implementera ett strategy-pattern som kan följa denna mall
// https://www.dotnettricks.com/learn/designpatterns/strategy-design-pattern-c-sharp
// Ni skall också ändra algoritmen att ta emot två floatvärden 'width' och 'height'
// Målet är att skapa en klass som kan räkna ut arean på en kvadrat och en rektangel
// När användaren vill räkna ut arean på en kvadrat kommer denna bara föra en värdet för width och sätta värdet 0 på height

// Vidare kan ni försöka sortera en vanlig list (List<>) genom två olika strategier, t.ex quicksort och mergesort.
// Algoritmerna för dessa finns längre ner.


//-----------------------------
// Strategy interface


//-----------------------------
// Strategy implementation






// copy n paste!
/*
 *
 *       static List<int> quicksort(List<int> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            int pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);
            List<int> smaller = new List<int>();
            List<int> greater = new List<int>();
            foreach (int item in list)
            {
                if (item < pivotValue)
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            List<int> sorted = quicksort(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(quicksort(greater));
            return sorted;
        }
 */

/*
 * private static List<int> MergeSort(List<int> unsorted)
    {
        if (unsorted.Count <= 1)
            return unsorted;

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int middle = unsorted.Count / 2;
        for (int i = 0; i < middle;i++)  //Dividing the unsorted list
        {
            left.Add(unsorted[i]);
        }
        for (int i = middle; i < unsorted.Count; i++)
        {
            right.Add(unsorted[i]);
        }

        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();

        while(left.Count > 0 || right.Count>0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                {
                    result.Add(left.First());
                    left.Remove(left.First());      //Rest of the list minus the first element
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            else if(left.Count>0)
            {
                result.Add(left.First());
                left.Remove(left.First());
            }
            else if (right.Count > 0)
            {
                result.Add(right.First());

                right.Remove(right.First());    
            }    
        }
        return result;
    }
 */
