using System.Text.Json;
using System.Text.RegularExpressions;
namespace APCSP
{
    public class JSON
    {
        public required int id { get; set; }
        public required string PeriodNumber { get; set; }
        public required string Name { get; set; }
        public required string Symbol { get; set; }
        public required int AtomicNumber { get; set; }
        public required double AtomicWeight { get; set; }
        public required float MeltingPoint { get; set; }
        public required float BoilingPoint { get; set; }
        public required string Density { get; set; }
        public required string PaRT { get; set; }
        public required string AtomClass { get; set; }
        public required string Group { get; set; }
        public required string Uses { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //Counting / Toggle Variables
            int i = 1;

            //Storage
            string search = "";
            string[] filteredList;
            int[] idList;
            string[] classificationList;
            string[] partList;
            string[] groupList;
            
            //JSON Setup
            using StreamReader reader = new("csvjson.json");
            string JSONString = reader.ReadToEnd();
            try
            {
                JSON dsJSONString = JsonSerializer.Deserialize<JSON>(JSONString)!;
                Console.WriteLine(dsJSONString.id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            static void HaltForInput()
            {
                Console.WriteLine("---\nPress anything to continue.");
                Console.ReadKey();
            }
            
            static void FilterList(string input)
            {
                string[] list;
                string pattern = ",";
                if (Regex.IsMatch(input, pattern))
                {
                    string[] filterBy = input.Split(',');
                    //This is here to make sure the format is correct.
                    foreach (string qualifier in filterBy)
                    {
                        if (qualifier.Length != 1)
                        {
                            Console.WriteLine("Ensure the format is correct, then try again.");
                            HaltForInput();
                        }
                    }
                }
                else
                {
                    
                }
            }

            do
            {
                //Console.Clear();
                Console.WriteLine("APCSP Performance Task: Chemical Element Searching\n" +
                                  "\n" +
                                  "You can search by properties, or by the element number itself.\n" +
                                  "Refer to the table below for properties.\n" +
                                  "Something like 1,Q,A as an entry will filter by metals, that are solid at room temperature, and have no definitive group." +
                                  "\n" +
                                  "Classification || Phase at Room Temperature || Group\n" +
                                  "1) Metal || Q) Solid || A) No Definitive\n" +
                                  "2) Non-Metal || W) Liquid || S) Alkali Metals \n" +
                                  "3) Semi-Metal || E) Gas || D) Alkali Earth Metals\n" +
                                  "Below is just the Group.\n" +
                                  "F) Metalloids\n" +
                                  "G) Poor Metals\n" +
                                  "H) Transformation Metals\n" +
                                  "J) Halogens\n" +
                                  "K) Noble Gases");
                search = Console.ReadLine();
                FilterList(search);
            } while (i == 0);
        }
    }
}