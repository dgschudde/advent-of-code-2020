namespace DayTwo.Model
{
    public class PasswordPolicy
    {
        public int Minimum { get; }

        public int Maximum { get; }

        public char CharacterToCheck { get; }

        public string Password { get; }

        public PasswordPolicy(int minimum, int maximum, char characterToCheck, string passWord)
        {
            Minimum = minimum;
            Maximum = maximum;
            CharacterToCheck = characterToCheck;
            Password = passWord;
        }
    }
}