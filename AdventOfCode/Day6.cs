using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day6
    {
        public static int Answer1()
        {
            int count = 0;

            var groups = File.ReadAllText("Day6Input.txt").Split("\r\n\r\n");
            foreach (var group in groups)
            {
                var individuals = group.Split("\r\n");
                Dictionary<char, bool> distinctAnswers = new Dictionary<char, bool>();
                foreach (var individual in individuals)
                {
                    char[] letters = individual.ToCharArray();
                    foreach (var letter in letters)
                    {
                        distinctAnswers[letter] = true;
                    }
                }

                count += distinctAnswers.Count;

            }


            return count;
        }

        public static int Answer2()
        {
            int count = 0;

            var groups = File.ReadAllText("Day6Input.txt").Split("\r\n\r\n");
           
            foreach (var group in groups)
            {

                var individuals = group.Split("\r\n");
                List<char> remainingLetters = String.Join("", individuals).ToCharArray().Distinct().ToList();

                foreach (var individual in individuals)
                {
                    char[] indiLetters = individual.ToCharArray();
                    List<char> toRemove = new List<char>();
                    foreach (char c in remainingLetters)
                    {
                        if (!indiLetters.Contains(c))
                            toRemove.Add(c);
                    }

                    remainingLetters = remainingLetters.Where(e => !toRemove.Contains(e)).ToList();
                }

                count += remainingLetters.Count;
            }

            return count;
        }
    }
}
