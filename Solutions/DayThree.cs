using System;
using System.IO;

namespace Solutions
{
    class DayThree
    {
        public static void Solution()
        {
            string[] map = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Solutions\\Inputs\\DayThree.txt")).Split("\n");

            Console.WriteLine($"Part one solution: {Solve(map)}");
            Console.WriteLine($"Part one solution: {Solve(map, 1, 1) * Solve(map) * Solve(map, 5, 1) * Solve(map, 7, 1) * Solve(map, 1, 2)}");
        }

        private static int Solve(string[] map, int across = 3, int down = 1)
        {
            int trees = 0;
            int row = 0;
            int index = 0;

            for (int i = 0; i < map.Length - down; i += down)
            {
                row += down;

                if (index + across < map[row].Length) index += across;
                else index = (index + across - map[row].Length);

                if (map[row][index] == '#') trees++;
            }

            return trees;
        }
    }
}
