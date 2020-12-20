using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day3
    {
        public static int Answer()
        {
            try
            {
                return FindMeThoseTreesDamnit();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int Answer2()
        {
            try
            {
                int one = FindMeThoseTreesDamnit(1, 1);
                int two = FindMeThoseTreesDamnit(3, 1);
                int three = FindMeThoseTreesDamnit(5, 1);
                int four = FindMeThoseTreesDamnit(7, 1);
                int five = FindMeThoseTreesDamnit(1, 2);

                return one * two * three * four * five;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int FindMeThoseTreesDamnit(int right = 3, int down = 1)
        {
            List<List<char>> forest = new List<List<char>>();

            var lines = File.ReadAllLines("Day3Input.txt");
            int width = lines[0].Length;
            int height = lines.Length;

            double multiplier = Math.Ceiling((double)height / width) * right;

            foreach (var line in lines)
            {
                List<char> treeline = new List<char>();
                for (int i = 0; i < multiplier; i++)
                {
                    treeline.AddRange(line);
                }

                forest.Add(treeline);
            }

            width = forest[0].Count;
            height = forest.Count;

            Point p = new Point(0, 0);
            int trees = 0;

            do
            {
                if (forest[p.Y][p.X] == '#') trees++;

                p.X += right;
                p.Y += down;

            } while (p.X < width && p.Y < height);


            return trees;
        }

    }
}

