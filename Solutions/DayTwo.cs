using System;
using System.IO;

namespace Solutions
{
    class DayTwo
    {
        public static void Solution()
        {
            string[] text = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Solutions\\Inputs\\DayTwo.txt")).Split("\n");
            int count = 0;
            int valid = 0;

            foreach (string s in text)
            {
                string[] split = s.Split(":");
                string[] indexes = split[0].Trim().Split("\n");
                string[] values = split[1].Trim().Split("\n");

                for (int i = 0; i < indexes.Length; i++)
                {
                    string current = indexes[i];
                    string range = current.Substring(0, current.LastIndexOf(" "));
                    string[] slice = range.Split("-");

                    int min = Convert.ToInt32(slice[0]);
                    int max = Convert.ToInt32(slice[1]);

                    bool passed = false;

                    for (int j = 0; j < values.Length; j++)
                    {
                        char letter = current[current.Length - 1];
                        string value = values[j];
                        int seen = 0;

                        for (int k = 0; k < value.Length; k++)
                        {
                            
                            
                            if (value[k] == letter)
                            {
                                seen++;

                                if (min - 1 == k || max - 1 == k)
                                {
                                    if (passed)
                                    {
                                        passed = false;
                                    } else
                                    {
                                        passed = true;
                                    }
                                }
                            }
                        }

                        if (seen >= min && seen <= max)
                        {
                            count++;
                        }
                    }

                    if (passed)
                    {
                        valid++;
                    }
                }
            }

            Console.WriteLine($"Part one solution: {count}, Part two solution: {valid}");
        }
    }
}
