using static System.Net.Mime.MediaTypeNames;

string[] lines = File.ReadAllLines("C:/Users/Karlo/Desktop/log20201104.txt");
DateTime start;
DateTime end;
int startLocation;
int endLocation;
Console.WriteLine("1 for filter, 2 for time range");
ConsoleKeyInfo key = Console.ReadKey();
int action = int.Parse(key.KeyChar.ToString());

switch (action)
{
    case 1:
        {
            Console.WriteLine("\n Filter by: 1 for type, 2 for vault, 3 for modul");
            key = Console.ReadKey();
            Console.WriteLine("\n Input keyword");
            int filter = int.Parse(key.KeyChar.ToString());
            string? keyword = Console.ReadLine();

            switch (filter)
            {
                case 1:
                    {
                        foreach (var line in lines)
                        {
                            startLocation = line.IndexOf("[", StringComparison.Ordinal);
                            endLocation = line.IndexOf("]", StringComparison.Ordinal);
                            printFilteredLogs(line, startLocation, endLocation, keyword.ToUpper());
                        }
                        return;
                    }
                case 2:
                    {
                        foreach (var line in lines)
                        {
                            startLocation = line.IndexOf("{", StringComparison.Ordinal);
                            endLocation = line.IndexOf("}", StringComparison.Ordinal);
                            printFilteredLogs(line, startLocation, endLocation, keyword.ToUpper());
                        }
                        return;
                    }
                case 3:
                    {
                        foreach (var line in lines)
                        {
                            startLocation = line.IndexOf("[", line.IndexOf("[") + 1);
                            endLocation = line.IndexOf("]", line.IndexOf("]") + 1);
                            printFilteredLogs(line, startLocation, endLocation, keyword);
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
                startLocation = line.IndexOf(" +", StringComparison.Ordinal);
                if (startLocation > 0)
                {
                    if (Convert.ToDateTime(line.Substring(0, startLocation)) >= start && Convert.ToDateTime(line.Substring(0, startLocation)) <= end) Console.WriteLine(line);
                }
            }
            return;
        }

        void printFilteredLogs(string line, int startLocation, int endLocation, string keyword)
        {
            if (keyword == "" || keyword == null) Console.WriteLine("Incorrect input");
            if (line.Substring(startLocation, endLocation - startLocation).Contains(keyword)) Console.WriteLine(line);
        }
}
