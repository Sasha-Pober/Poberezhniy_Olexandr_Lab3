using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LAb3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuisine[] meals = new Cuisine[4];
            meals[0] = new Mexican("taco", 1);
            meals[1] = new Ukrainian("varenyky", 2);
            meals[2] = new Japanese("sushi", 3);
            meals[3] = new Italian("pizza", 3);
            List<string> mealList = new List<string>();
            List<int> amount = new List<int>();
            for (int i = 0; i < meals.Length; i++)
            {
                mealList.Add(meals[i].Name);
                amount.Add(meals[i].amount);
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < meals.Length; i++)
            {
                dictionary.Add(mealList[i], amount[i]);
            }

            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
            foreach (var i in mealList)
            {
                foreach (var j in dictionary)
                {
                    if(dictionary[i] == j.Value && i != j.Key && dictionary1.ContainsKey(i) == false)
                    {

                        dictionary1.Add(i, dictionary[i]);
                        dictionary1.Add(j.Key, j.Value);

                    }
                }
            }

            foreach(var i in dictionary.Select(n => n).Reverse())
            {
                if (dictionary1.ContainsKey(i.Key) == false)
                {
                    dictionary1.Add(i.Key, i.Value);
                }
            }

            dictionary = dictionary1;
            foreach (var i in dictionary)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }

            string jsonStr = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText("data.json", jsonStr);
            Console.WriteLine("Dictionary has succesfully added to data.json");

            Console.ReadKey();
        }
    }
}

