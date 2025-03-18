using System.Text.Json;
using System.Text.RegularExpressions;
namespace APCSP
{
    public class JSON
    {
        public required string[] id { get; set; }
        public required string[] PeriodNumber { get; set; }
        public required string[] Name { get; set; }
        public required string[] Symbol { get; set; }
        public required string[] AtomicNumber { get; set; }
        public required string[] AtomicWeight { get; set; }
        public required string[] MeltingPoint { get; set; }
        public required string[] BoilingPoint { get; set; }
        public required string[] Density { get; set; }
        public required string[] PaRT { get; set; }
        public required string[] AtomClass { get; set; }
        public required string[] Group { get; set; }
        public required string[] Uses { get; set; }
    }
    public class Program
    {
        static string[] qualifierStrings = new string[3];
        public static void Main(string[] args)
        {
            //Counting / Toggle Variables
            int i = 1;

            //Storage
            string search = "";
            string[] filteredList;
            
            /*int[] idList;
            string[] classificationList;
            string[] partList;
            string[] groupList; 
            string[] finalList;*/
            //JSON Setup
            using StreamReader reader = new("final_transformed_csvjson.json");
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

                string[] patternList = { ",", "[0-4]a[c-h][j-l][q-s][w-x]z", "[0-4]", "qwer", "asdfghjklzxc" };
                if (Regex.IsMatch(input, patternList[0]))
                {
                    string[] filterBy = input.Split(',');
                    //This is here to make sure the format is correct.
                    for (var i = 0; i < filterBy.Length; i++)
                    {
                        if (filterBy[i].Length != 1 || !Regex.IsMatch(filterBy[i], patternList[1], RegexOptions.IgnoreCase))
                        {
                            Console.WriteLine("Ensure the format is correct, then try again.");
                            HaltForInput();
                            return;
                        }

                        if (Regex.IsMatch(filterBy[i], patternList[2]))
                        {
                            qualifierStrings[i] = filterBy[i] switch
                            {
                                "1" => "Metal",
                                "2" => "Non-Metal",
                                "3" => "Semi-metal",
                                "4" => "Unknown"
                            };
                        }
                        else if (Regex.IsMatch(filterBy[i], patternList[3]))
                        {
                            qualifierStrings[i] = filterBy[i].ToLower() switch
                            {
                                "q" => "Solid",
                                "w" => "Liquid",
                                "e" => "Gas",
                                "r" => "Expected to be Solid"
                            };
                        }
                        else if (Regex.IsMatch(filterBy[i], patternList[4]))
                        {
                            qualifierStrings[i] = filterBy[i].ToLower() switch
                            {
                                "a" => "No Definitive",
                                "s" => "Alkali Metals",
                                "d" => "Alkali Earth Metals",
                                "f" => "Metalloids",
                                "g" => "Poor Metals",
                                "h" => "Transformation Metals",
                                "j" => "Rare Earth Metals",
                                "k" => "Halogens",
                                "l" => "Noble Gases",
                                "z" => "Actinide Metals",
                                "x" => "Superheavy Elements",
                                "c" => "Non-Metal"
                            };
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
                                  "4) Unknown || R) Expected Solid || F) Metalloids\n" +
                                  "Below is just the Group.\n" +
                                  "G) Poor Metals\n" +
                                  "H) Transformation Metals\n" +
                                  "J) Rare Earth Metals\n" +
                                  "K) Halogens\n" +
                                  "L) Noble Gases\n" +
                                  "Z) Actinide Metals\n" +
                                  "X) Superheavy Elements\n" +
                                  "C) Non-Metal");
                search = Console.ReadLine();
                FilterList(search);
            } while (i == 1);
        }
    }
}