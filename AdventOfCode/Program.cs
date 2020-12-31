using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1, answer 1");
            int day1Answer = Day1.Answer();
            Console.WriteLine(day1Answer == -1 ? "Unable to solve" : day1Answer.ToString());

            Console.WriteLine("Day 1, answer 2");
            int day1Answer2 = Day1.Answer2();
            Console.WriteLine(day1Answer2 == -1 ? "Unable to solve" : day1Answer2.ToString());

            Console.WriteLine("Day 2, answer 1");
            int day2Answer = Day2.Answer();
            Console.WriteLine(day2Answer == -1 ? "Unable to solve" : day2Answer.ToString());

            Console.WriteLine("Day 2, answer 2");
            int day2Answer2 = Day2.Answer2();
            Console.WriteLine(day2Answer2 == -1 ? "Unable to solve" : day2Answer2.ToString());

            Console.WriteLine("Day 3, answer 1");
            int day3Answer = Day3.Answer();
            Console.WriteLine(day3Answer == -1 ? "Unable to solve" : day3Answer.ToString());

            Console.WriteLine("Day 3, answer 2");
            int day3Answer2 = Day3.Answer2();
            Console.WriteLine(day3Answer2 == -1 ? "Unable to solve" : day3Answer2.ToString());

            Console.WriteLine("Day 4, answer 1");
            int day4Answer1 = Day4.Answer();
            Console.WriteLine(day4Answer1 == -1 ? "Unable to solve" : day4Answer1.ToString());

            // this is wrong answer
            Console.WriteLine("Day 4, answer 2");
            int day4Answer2 = Day4.Answer2();
            Console.WriteLine(day4Answer2 == -1 ? "Unable to solve" : day4Answer2.ToString());



            Console.WriteLine("Day 5, answer 1");
            int day5Answer1 = Day5.Answer1();
            Console.WriteLine(day5Answer1 == -1 ? "Unable to solve" : day5Answer1.ToString());

           // Console.WriteLine("Day 5, answer 2");
           // int day5Answer2 = Day5.Answer2();
            //Console.WriteLine(day5Answer2 == -1 ? "Unable to solve" : day5Answer2.ToString());

            Console.WriteLine("Day 6, answer 1");
            int day6Answer1 = Day6.Answer1();
            Console.WriteLine(day6Answer1 == -1 ? "Unable to solve" : day6Answer1.ToString());

            Console.WriteLine("Day 6, answer 2");
            int day6Answer2 = Day6.Answer2();
            Console.WriteLine(day6Answer2 == -1 ? "Unable to solve" : day6Answer2.ToString());

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }

    }
}
