using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace AdventOfCode
{
    public static class Day2
    {

        public static int Answer()
        {
            try
            {
                List<Validator> validators = new List<Validator>();

                var lines = File.ReadAllLines("Day2Input.txt");

                foreach (var line in lines)
                {
                    var split = line.Split(' ');
                    var minmax = split[0].Split('-');
                    int min = Convert.ToInt32(minmax[0]);
                    int max = Convert.ToInt32(minmax[1]);
                    char c = split[1][0];
                    string pw = split[2];

                    validators.Add(new Validator(c, min, max, pw));
                }

                return validators.Where(e => e.Valid).ToArray().Length;
            }
            catch(Exception ex)
            {
                return -1;
            }

        }

        public static int Answer2()
        {

            try
            {
                List<Validator2> validators = new List<Validator2>();

                var lines = File.ReadAllLines("Day2Input.txt");

                foreach (var line in lines)
                {
                    var split = line.Split(' ');
                    var minmax = split[0].Split('-');
                    int min = Convert.ToInt32(minmax[0]);
                    int max = Convert.ToInt32(minmax[1]);
                    char c = split[1][0];
                    string pw = split[2];

                    validators.Add(new Validator2(c, min, max, pw));
                }

                return validators.Where(e => e.Valid).ToArray().Length;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

       class Validator
        {
            protected char _pwChar; 
            protected int _minFound;
            protected int _maxFound; 
            protected string _pw;

            public Validator(char pwChar, int minFound, int maxFound, string pw)
            {
                _pwChar = pwChar;
                _minFound = minFound;
                _maxFound = maxFound;
                _pw = pw;
            }

            public bool Valid 
            { 
                get 
                {
                    int instances = _pw.Count(e => e == _pwChar);
                    if (instances >= _minFound && instances <= _maxFound) return true;

                    return false;
                } 
            }
        }

        class Validator2 : Validator
        {
            public Validator2(char pwChar, int minFound, int maxFound, string pw) : base(pwChar, minFound, maxFound, pw)
            {

            }

            public new bool  Valid { 
                get
                {
                    char pos1 = _pw[_minFound - 1];
                    char pos2 = _pw[_maxFound - 1];

                    if (pos1 != pos2 && (pos1 == _pwChar || pos2 == _pwChar))
                        return true;
                    return false;
                }
            }
        }

    }
}
