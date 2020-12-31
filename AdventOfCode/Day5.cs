using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.IO;

namespace AdventOfCode
{
    public static class Day5
    {

        public static int Answer1()
        {
            var lines = File.ReadAllText("Day5Input.txt").Split("\r\n");

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < 128; i++)
            {
                left.Add(i);
            }

            for (int i = 0; i < 8; i++)
            {
                right.Add(i);
            }


            List<int> ids = new List<int>();
            List<int> rows = new List<int>();

            List<List<bool>> airplaneSeats = new List<List<bool>>();

            for(int r = 0; r < 128; r++)
            {
                List<bool> columns = new List<bool>();
                for(int c = 0; c < 8; c++)
                {
                    columns.Add(false);
                }

                airplaneSeats.Add(columns);
            }

            foreach (var line in lines)
            {
                var firstPart = line.Take(7).ToArray();
                var secondPart = line.Skip(7).ToArray();

                var l = left.ToArray();
                var r = right.ToArray();

                foreach (char c in firstPart)
                {
                    l = SplitInHalf(l, (c == 'F')).ToArray();
                }

                foreach (char c in secondPart)
                {
                    r = SplitInHalf(r, (c == 'L')).ToArray();
                }

                

                int row = l[0];

                rows.Add(row);

                int col = r[0];


                int id = row * 8 + col;
                airplaneSeats[row][col] = true;

                ids.Add(id);
            }

            return ids.Max();

            rows = rows.Distinct().ToList();
            rows.Sort();

            ids.Sort();

            int rr = 0;

            // kinda cheated and , just printed it out to see, this one was kinda annoying me

            foreach (var row in airplaneSeats)
            {
                foreach (var col in row)
                {
                    Console.Write(col == true ? "O" : "X");
                }

                Console.Write(" " + rr++ + "\n");
            }


           
        }

        public static int Answer2()
        {
            var lines = File.ReadAllText("Day5Input.txt").Split("\r\n");

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < 128; i++)
            {
                left.Add(i);
            }

            for (int i = 0; i < 8; i++)
            {
                right.Add(i);
            }

            List<int> ids = new List<int>();
            List<int> rows = new List<int>();

            List<List<bool>> airplaneSeats = new List<List<bool>>();

            for (int r = 0; r < 128; r++)
            {
                List<bool> columns = new List<bool>();
                for (int c = 0; c < 8; c++)
                {
                    columns.Add(false);
                }

                airplaneSeats.Add(columns);
            }

            foreach (var line in lines)
            {
                var firstPart = line.Take(7).ToArray();
                var secondPart = line.Skip(7).ToArray();

                var l = left.ToArray();
                var r = right.ToArray();

                foreach (char c in firstPart)
                {
                    l = SplitInHalf(l, (c == 'F')).ToArray();
                }

                foreach (char c in secondPart)
                {
                    r = SplitInHalf(r, (c == 'L')).ToArray();
                }

                int row = l[0];

                rows.Add(row);

                int col = r[0];


                int id = row * 8 + col;
                airplaneSeats[row][col] = true;

                ids.Add(id);
            }

            int rr = 0;

            // kinda cheated and I just printed it out to see which seat was mine, didnt return an answer this one was kinda annoying me

            foreach (var row in airplaneSeats)
            {
                foreach (var col in row)
                {
                    Console.Write(col == true ? "O" : "X");
                }

                Console.Write(" " + rr++ + "\n");
            }

            throw new NotImplementedException();

        }



        private static IEnumerable<int> SplitInHalf(int[] numbs, bool lowerHalf)
        {
            int half = numbs.Length / 2;
            if (lowerHalf)
            {
                return numbs.Take(half);
            }
            else
            {
                return numbs.Skip(half);
            }
        }
    }
}
