using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day4
    {
        public static int Answer()
        {
            try
            {
                string[] requiredValues = new string[]
                {
                "byr","iyr","eyr","hgt","hcl","ecl","pid"
                };

                int goodPassports = 0;
                foreach (var line in File.ReadAllText("Day4Input.txt").Split("\r\n\r\n"))
                {
                    var keys = line.Replace("\r\n", " ").Split(" ").Select(e => e.Split(":")).ToDictionary(e => e[0], e => e[1]).Keys;

                    var hasRequired = requiredValues.All(e => keys.Where(e => e != "cid").Contains(e));

                    if (hasRequired)
                        goodPassports++;
                }

                return goodPassports;
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
                string[] requiredValues = new string[]
                {
                "byr","iyr","eyr","hgt","hcl","ecl","pid"
                };

                Dictionary<string, Func<string, bool>> validators = new Dictionary<string, Func<string, bool>>();

                validators.Add("byr", (s) =>
                {
                    if (s.Length != 4) return false;
                    if (!Int32.TryParse(s, out int result)) return false;
                    if (result >= 1920 && result <= 2002) return true;
                    return false;
                });

                validators.Add("iyr", (s) =>
                {
                    if (s.Length != 4 || !Int32.TryParse(s, out int result)) return false;
                    if (result >= 2010 && result <= 2020) return true;
                    return false;
                });

                validators.Add("eyr", (s) =>
                {
                    if (s.Length != 4 || !Int32.TryParse(s, out int result)) return false;
                    if (result >= 2020 && result <= 2030) return true;
                    return false;
                });

                validators.Add("hgt", (s) =>
                {
                    if (!Int32.TryParse(String.Join("", s.Where(e => char.IsDigit(e)).ToArray()), out int number)) return false;
                    if (s.Contains("cm")) if (number < 150 || number > 193) return false;
                        else if (s.Contains("in")) if (number < 59 || number > 76) return false;
                            else return false;

                    return true;
                });

                validators.Add("hcl", (s) =>
                {
                    Match m = Regex.Match(s, @"#[0-9a-fA-F]{6}");
                    return m.Success;
                });
                validators.Add("ecl", (s) =>
                {
                    if (s.Length != 3) return false;
                    Match m = Regex.Match(s, "amb|blu|brn|gry|grn|hzl|oth");
                    return m.Success;
                    // s == "amb" || s == "blu" || s == "brn" || s == "gry" || s == "grn" || s == "hzl" || s == "oth");
                });

                validators.Add("pid", (s) =>
                {
                    if (s.Length != 9) return false;
                    if (Int32.TryParse(s, out int result)) return true;
                    return false;
                });

                validators.Add("cid", (s) => { return true; });

                int goodPassports = 0;

                foreach (var line in File.ReadAllText("Day4Input.txt").Split("\r\n\r\n"))
                {
                    var dictionary = line.Replace("\r\n", " ")
                                         .Split(" ")
                                         .Select(e => e.Split(":"))
                                         .ToDictionary(e => e[0], e => e[1]);

                    dictionary.Remove("cid");

                    string[] keys = dictionary.Keys.ToArray();

                    var hasRequired = requiredValues.All(e => keys.Contains(e));

                    if (!hasRequired) continue;

                    foreach (var key in keys)
                    {
                        if (!validators[key](dictionary[key]))
                        {
                            hasRequired = false;
                            break;
                        }
                    }

                    if (hasRequired)
                        goodPassports++;

                }

                return goodPassports;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        
    }
}
