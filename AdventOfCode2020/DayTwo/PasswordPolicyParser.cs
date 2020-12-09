using DayTwo.Model;
using System;
using System.Collections.Generic;

namespace DayTwo
{
    public class PasswordPolicyParser
    {
        private readonly string[] _input;

        public PasswordPolicyParser(string[] input)
        {
            _input = input;
        }

        public IEnumerable<PasswordPolicy> ParseInput()
        {
            var result = new List<PasswordPolicy>();

            if (_input == null)
            {
                return default;
            }

            foreach (string item in _input)
            {
                var splittedItems = item.Split(' ');
                string[] minimumMaximum = splittedItems[0].Split('-');
                int minimum = int.Parse(minimumMaximum[0]);
                int maximum = int.Parse(minimumMaximum[1]);
                char characterToCheck = Convert.ToChar(splittedItems[1].Trim(':'));
                string passWord = splittedItems[2].Trim();

                result.Add(new PasswordPolicy(
                    minimum,
                    maximum,
                    characterToCheck,
                    passWord
                    ));
            }

            return result;
        }
    }
}