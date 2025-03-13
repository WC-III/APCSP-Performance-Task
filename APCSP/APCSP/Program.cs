// See https://aka.ms/new-console-template for more information

//Counting / Toggle Variables
ushort i = 1;
ushort j = 0;

//Key Variables
ConsoleKeyInfo beginningSelection;
ConsoleKeyInfo optionsSelection;

//Arrays
string[] selections = { "", "" };
bool[] optionToggles = { false, false };

static void updateOptions(int option)
{
    
}

do
{
    Console.Clear();
    Console.WriteLine("APCSP Performance Task: Chemical Element Searching\n" +
                      "\n" +
                      "1) Begin Search\n" +
                      "2) Options\n" +
                      "3) About\n" +
                      "*) Exit");
    beginningSelection = Console.ReadKey();
    switch (beginningSelection.Key)
    {
        case ConsoleKey.D1:
            break;
        case ConsoleKey.D2:
            Console.Clear();
            do
            {
                j = 0;
                Console.WriteLine("1) Debugging Features " + selections[0] + "\n" +
                                  "2) Quiz Mode" + selections[1] + "\n" +
                                  "*) Back");
                optionsSelection = Console.ReadKey();
                switch (optionsSelection.Key)
                {
                    case ConsoleKey.D1:
                        
                        break;
                    case ConsoleKey.D2:
                        break;
                    default:
                        j = 1;
                        break;
                }
            } while (j == 0);
            break;
        case ConsoleKey.D3:
            break;
        default:
            return;
    }
}
while(i == 1);