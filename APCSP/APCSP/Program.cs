/*
Long-winded comment, but it's here for a reason.

This was written in C#, with JetBrains Rider Non-Commercial.

It's long, and probably drawn out, however I don't doubt that most of this code is required.

CITATIONS:
    I will admit to using AI; but for no program code itself.
    I'm not the greatest with regular expressions, so I enlisted ChatGPT (model 4o) to help.
    It created the expression "[^0-9]" in patternsList[5], and it confirmed patternsList[1] as being correct.
    
    I also used AI for debugging, which it gave me the insight to use a List instead of an Array for filteredList.
    
    More on AI, I used it to reformat the .json.
    The .json originates from the Periodic Table of Elements Dataset from code.org, which I exported as a .csv.
    I used CSVJSON (a website) to convert from .csv -> .json, but it wasn't parsing correctly, so ChatGPT converted the elements to how I needed it.
    The original .json is still in this project, but is only there for archival purposes.
    
    Regular expression information came from the Microsoft Learn Documentation surrounding System.Text.RegularExpressions, Regex.IsMatch, and anything else regex related.
END CITATIONS
*/
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
        static string[] qualifierStrings;
        static StreamReader reader = new("final_transformed_csvjson.json");
        static string JSONString = reader.ReadToEnd(); 
        static JSON dsJSONString = JsonSerializer.Deserialize<JSON>(JSONString)!; 
        static List<int> filteredList;
        public static void Main(string[] args)
        {
            int i = 1;
            string search = "";
            static void HaltForInput()
            {
                Console.WriteLine("\n---\nPress anything to continue.");
                Console.ReadKey();
            }
            
            static void BeginFilterList(string input)
            {

                string[] patternList = { ",", "[0-4]a[c-h][j-l][q-s][w-x]z", "[0-4]", "qwer", "asdfghjklzxc", "[^0-9]" };
                if (Regex.IsMatch(input, patternList[0]))
                {
                    string[] filterBy = input.Split(',');
                    for (var i = 0; i < filterBy.Length; i++)
                    {
                        if (filterBy[i].Length != 1 || !Regex.IsMatch(filterBy[i], patternList[1], RegexOptions.IgnoreCase) || filterBy.Length != 3)
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
                    CrossCompare();
                }
                else
                {
                    if (Regex.IsMatch(input, patternList[5]))
                    {
                        Console.WriteLine("Ensure the format is correct, then try again.");
                        HaltForInput();
                        return;
                    }
                    for (var i = 0; i < dsJSONString.id.Length; i++)
                    {
                        if (dsJSONString.id[i] == input)
                        {
                            filteredList.Add(i);
                            return;
                        }
                    }
                }
            }

            static void CrossCompare()
            {
                
            }

            static void DisplayInfo(int[] idStrings)
            {
                if (idStrings.Length > 1)
                {
                    
                }
                else
                {
                    int index = idStrings[0];
                    Console.WriteLine(dsJSONString.Name[index]);
                    HaltForInput();
                }
            }

            do
            {
                Console.Clear();
                Console.WriteLine("APCSP Performance Task: Chemical Element Searching\n" +
                                  "\n" +
                                  "You can search by properties, or by the element number itself. The element number should be entered as-is, for example, 103.\n" +
                                  "Refer to the table below for properties.\n" +
                                  "Something like 1,Q,A as an entry will filter by metals, that are solid at room temperature, and have no definitive group.\n" +
                                  "All search options must be separated by commas, and you must use all 3.\n" +
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
                search = Console.ReadLine()!;
                BeginFilterList(search);
                DisplayInfo(filteredList.ToArray());
            } while (i == 1);
        }
    }
}