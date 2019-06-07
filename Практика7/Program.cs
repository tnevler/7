using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика7
{
    public class Program
    {
        public static bool IsPowerOfTwo(int val)
        {
            return val != 0 && (val & (val - 1)) == 0;
        }

        public static void Show(int[] mas)
        {
            foreach (int x in mas)
            {
                Console.Write(x);
            }
        }

        public static string CurrectEntry()
        {
            string s = null;
            bool ok = false;
            do
            {
                Console.WriteLine("Введите строку, состоящую из 0 и 1");
                s = Console.ReadLine();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0' || s[i] == '1') ok = true;
                    else
                    {
                        ok = false;
                        break;
                    }
                }
            } while (!ok);
            return s;
        }

        public static int[] FindMistake(string s)
        {
            int[] arr = new int[s.Length];
            bool[] check = new bool[arr.Length];
            for (int i = 0; i < check.Length; i++)
            {
                check[i] = true;
            }
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = s[i] - 48;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPowerOfTwo(i + 1))
                {
                    int result = 0;
                    int shag = i + 1;
                    for (int j = i; j < arr.Length; j += shag + 1)
                    {
                        int k = 0;
                        for (int z = j; z < arr.Length; z++)
                        {
                            k++;
                            result += arr[z];
                            if (k == shag)
                            {
                                j = z;
                                break;
                            }

                        }
                    }
                    if (result % 2 != 0) check[i] = false;
                }
            }

            bool alltrue = true;
            foreach (bool x in check)
            {
                if (x == false) alltrue = false;
            }
            if (alltrue)
            {
                Console.WriteLine("Ошибок нет");
                return arr;
            }
            else
            {
                int faultindex = 0;
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] == false)
                    {
                        faultindex += i + 1;
                    }
                }
                if (faultindex < arr.Length)
                {
                    Console.WriteLine("Ошибка в позиции {0}", faultindex);
                    if (arr[faultindex - 1] == 0) arr[faultindex - 1] = 1;
                    else arr[faultindex - 1] = 0;
                    return arr;
                }
                else
                {
                    Console.WriteLine("Несколько ошибок, исправить нельзя");
                    return arr;
                }
            }
        }
        static void Main(string[] args)
        {
            string s = CurrectEntry();
            int[] arr = FindMistake(s);
            Show(arr);
            Console.ReadKey();
        }
    }
}
