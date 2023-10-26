using Newtonsoft;
using Newtonsoft.Json;

namespace SortAndCompareDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nu ska vi titta på hur String.Compare jämför saker");
            string item1 = "teststräng";
            string item2 = "teststräng";
            string item3 = item2;
            var result0 = string.Compare(item1, item3);
            var result2 = string.Compare(item2, item3);
            var result3 = string.Compare(item1, item2);
            Console.WriteLine($"And the results are: {result0} and {result2} and {result3}");
            Console.WriteLine("Vad betyder det? Tryck knapp för att gå vidare.");
            Console.ReadKey();
            CompareInLists();
        }

        public static void CompareInLists()
        {
            List<string> list = new List<string>();
            list.Add("Hej");
            list.Add("lista");
            list.Add("Hej");
            list.Add("listan");
            list.Sort(); // kolla i denna

            List<Person> personList = new List<Person>();
            int i = 0;
            while (i < 20)
            {
                personList.Add(new Person((char)(i+65)));
                i++;
            } // This looks a little bit like a???
            personList.ForEach(person => { Console.WriteLine(JsonConvert.SerializeObject(person)); }) ;
            personList.Sort(new MyComparer()); //Ohh well, lets try a better version.
            Console.WriteLine("After sort");
            personList.ForEach(person => { Console.WriteLine(JsonConvert.SerializeObject(person)); ; });
        }

        private class Person 
        {

            public Person(char aChar) 
            { 
                FirstName = aChar + random.Next(0, 28).ToString();
                LastName = string.Concat(RandomLetter(), aChar, RandomLetter());
                Title = random.Next(0, 28).ToString();
            }
            Random random = new Random();
            private char RandomLetter()
            {
                int aletter = random.Next(65, 90) ;
                return (char)aletter;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }

        }
        private class MyComparer : IComparer<Person>
        {
            public int Compare(Person? x, Person? y)
            {
                int compareLastName = x.LastName.CompareTo(y.LastName);
                if (compareLastName == 0)
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
                return compareLastName;
            }
        }

    }
}