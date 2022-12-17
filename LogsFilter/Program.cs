using static System.Net.Mime.MediaTypeNames;

string[] lines = File.ReadAllLines("C:/Users/Karlo/Desktop/log20201104.txt");
DateTime start;
DateTime end;
Console.WriteLine("1 for filter, 2 for time range");
ConsoleKeyInfo action = Console.ReadKey();
int actionSwitch = int.Parse(action.KeyChar.ToString());
int charLocation;
int charLocation2;

switch (actionSwitch)
{
    case 1:
        {
            Console.WriteLine("\n Filter by : 1 for type, 2 for vault, 3 for modul");
            ConsoleKeyInfo filter = Console.ReadKey();
            int filterSwitch = int.Parse(filter.KeyChar.ToString());
            Console.WriteLine("\n Input keyword");
            string? keyword = Console.ReadLine();
            switch (filterSwitch)
            {  
                    case 1: 
                    {
                        foreach (var line in lines)
                        {
                            charLocation = line.IndexOf("[", StringComparison.Ordinal);
                            charLocation2 = line.IndexOf("]", StringComparison.Ordinal);
                            filteringString(line, charLocation, charLocation2, keyword.ToUpper());
                        }
                        return; 
                    }
                    case 2: 
                    {
                    foreach (var line in lines)
                        {
                         charLocation = line.IndexOf("{", StringComparison.Ordinal);
                         charLocation2 = line.IndexOf("}", StringComparison.Ordinal);
                         filteringString(line, charLocation, charLocation2, keyword.ToUpper());
                        }
                        return; 
                    }
                    case 3: 
                    {
                        foreach (var line in lines)
                        {
                         charLocation = line.IndexOf("[", line.IndexOf("[")+1);
                         charLocation2 = line.IndexOf("]", line.IndexOf("]") + 1);
                         filteringString(line, charLocation, charLocation2, keyword);
                        }
                        return; 
                    }
                }
            return;
        }
    case 2: 
        {
            Console.WriteLine("\n Input start date/time (Input type: year/month/day hour:minute:second.milisecond)");
            start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\n Input end date/time (Input type:year/month/day hour:minute:second.milisecond)");
            end = Convert.ToDateTime(Console.ReadLine());
            foreach (var line in lines)
            {
                charLocation = line.IndexOf(" +", StringComparison.Ordinal);
                if (charLocation > 0)
                {
                    if (Convert.ToDateTime(line.Substring(0, charLocation)) >= start && Convert.ToDateTime(line.Substring(0, charLocation)) <= end) Console.WriteLine(line);
                }
            }
                return;
        }
void filteringString(string line, int charLocation, int charLocation2, string keyword)
        {   if (keyword == "" || keyword == null) Console.WriteLine("Incorrect input");
            if (line.Substring(charLocation, charLocation2 - charLocation + 1).Contains(keyword)) Console.WriteLine(line);
        }
}
