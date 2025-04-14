using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Base
{
    public enum Chance
    {
        zero, twentyFive, fifty, sixtySix, seventyFive, hundread
    }
    public class GameUtilities
    {
        public static int ReturnNumberWithoutIt(int begin, int end, int number)
        {
            int n = Random.Range(begin, end);
            while (n == number)
            {
                n = Random.Range(begin, end);
            }
            return n;
        }

        public static List<int> ReturnNumbersWithoutIt(int begin, int end, int number)
        {
            List<int> numbers = new List<int>();
            int length = end - (begin + 1);
            while (numbers.Count != length)
            {
                int n = ReturnNumberWithoutIt(begin, end, number);
                if (!numbers.Contains(n))
                {
                    numbers.Add(n);
                }

            }


            return numbers;
        }

        public static List<int> ReturnRandomNumbers(int begin, int end)
        {
            List<int> numbers = new List<int>();
            int length = end - (begin + 1);
            while (numbers.Count != length)
            {
                int n = Random.Range(begin, end);
                if (!numbers.Contains(n))
                {
                    numbers.Add(n);
                }

            }


            return numbers;
        }

        public static List<int> ReturnRandomNumbers(int begin, int end, int size)
        {
            List<int> numbers = new List<int>();
            int length = end - (begin + 1);
            while (numbers.Count != size)
            {
                int n = Random.Range(begin, end);
                if (!numbers.Contains(n))
                {
                    numbers.Add(n);
                }

            }

            foreach (var v in numbers)
            {
                Debug.Log(v);
            }

            return numbers;
        }

        public static bool ReturnTruePercentChance(Chance chanceRate)
        {
            switch (chanceRate)
            {
                case Chance.zero:

                    return false;

                case Chance.twentyFive:

                    return Random.Range(1, 5) == 4 ? true : false;

                case Chance.fifty:

                    return Random.Range(1, 3) % 2 == 0 ? true : false;

                case Chance.sixtySix:

                    return Random.Range(2, 5) % 2 == 0 ? true : false;

                case Chance.seventyFive:

                    return Random.Range(1, 5) != 4 ? true : false;

                case Chance.hundread:

                    return true;

                default:
                    return Random.Range(1, 3) % 2 == 0 ? true : false;


            }
        }


        public static void ShuffelList<T>(ref List<T> list)
        {
            System.Random _random = new System.Random();
            int n = list.Count;
            for (int i = 0; i < (n - 1); i++)
            {
                // Use Next on random instance with an argument.
                // ... The argument is an exclusive bound.
                //     So we will not go past the end of the array.
                int r = i + _random.Next(n - i);
                T t = list[r];
                list[r] = list[i];
                list[i] = t;
            }         
        }
        
        public static string GetLastWordOfString(string text,char stringDividingSymbol='_')
        {
            string[] arr = text.Split(stringDividingSymbol);
            return arr[arr.Length - 1];
        }

        public static int GetContentIndexByName<T>(List<T> list,string contentName) where T : Object
        {
            return list.FindIndex(x => x.name == contentName);
        }
    }
}
