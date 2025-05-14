namespace LinqTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temperatures = new List<double> { 30.5, 32.0, 31.5, 29.0, 28.5, 33.0, 34.5 };
            var cityNames = new List<string> { "New York", "GLos Angeles", "Chicago", "Houston", "Phoenix", "Genova", "GRoma" };
            var students = new List<Student>
            {
                new Student("Alice", 20, true),
                new Student("Bob", 22, false),
                new Student("Charlie", 21, true),
                new Student("Diana", 23, false),
                new Student("Bob", 19, true),
                new Student("Frank", 24, false),
                new Student("Bob", 22, true),
            };

            var cityTemperature = new Dictionary<string, double>()
            {
                { "New York", 30.5 },
                { "Los Angeles", 32.0 },
                { "Chicago", 31.5 },
                { "Houston", 29.0 },
                { "Phoenix", 28.5 },
                { "Genova", 33.0 },
                {"Roma", 34.5}
            };

            var nicknameStudent = new Dictionary<string, Student>()
            {
                { "pippo", new Student("Alice", 20, true) },
                { "pluto", new Student("Bob", 22, false) },
                { "paperino", new Student("Charlie", 21, true) },
                { "clarabella", new Student("Diana", 23, false) },
                { "minnie", new Student("Bob", 19, true) },
                { "mickey", new Student("Frank", 24, false) },
                { "daisy", new Student("Bob", 22, true) },
            };


            //QUERY

            //temperature > 30
            var temperatureAbove30Sql = (from temp in temperatures
                                         where temp > 30
                                         select temp).ToList();

            var temperatureAbove30 = temperatures.Where(temp => temp > 30).ToList(); //lazy quindi ToList()

            for (int i = 0; i < temperatureAbove30.Count; i++)
            {
                Console.WriteLine($"{temperatureAbove30[i]}, {temperatureAbove30Sql[i]}");
            }

            //temperature > 30 ordered

            var temperatureAbove30OrderedSql = (from temp in temperatures
                                                where temp > 30
                                                orderby temp
                                                select temp).ToList();

            var temperatureAbove30Ordered = temperatures.Where(temp => temp > 30).OrderBy(t => t).ToList(); //oppure OrderByDescending, posso invertire orderby con where

            for (int i = 0; i < temperatureAbove30.Count; i++)
            {
                Console.WriteLine($"{temperatureAbove30Ordered[i]}, {temperatureAbove30OrderedSql[i]}");
            }

            //city name that start with G, just the first two cities

            var cityNameStartWithG = cityNames.Where(city => city.StartsWith("g", StringComparison.CurrentCultureIgnoreCase)).Take(2).ToList();

            var cityNameStartWithGSql = (from city in cityNames
                                         where city.StartsWith("g", StringComparison.CurrentCultureIgnoreCase)
                                         select city).Take(2).ToList();

            for (int i = 0; i < cityNameStartWithG.Count; i++)
            {
                Console.WriteLine($"{cityNameStartWithG[i]}, {cityNameStartWithGSql[i]}");
            }

            //all students order by name otherwise by age

            var allStudentsOrdered = students.OrderBy(s => s.Name).ThenBy(s => s.Age).ToList();

            var allStudentsOrderedSql = (from student in students
                                         orderby student.Name, student.Age
                                         select student).ToList();

            for (int i = 0; i < allStudentsOrdered.Count; i++)
            {
                Console.WriteLine($"{allStudentsOrdered[i].Name} {allStudentsOrdered[i].Age}, {allStudentsOrderedSql[i].Name} {allStudentsOrderedSql[i].Age}");
            }

            //cities where temperature > 30

            var citiesWithTemperatureAbove30 = cityTemperature.Where(kv => kv.Value > 30).Select(kv => kv.Key).ToList();

            for (int i = 0; i < citiesWithTemperatureAbove30.Count; i++)
            {
                Console.WriteLine($"{citiesWithTemperatureAbove30[i]}");
            }
        }
    }
}
