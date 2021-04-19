using System.Linq;
using System.Text.RegularExpressions;
using PC.Example.Domain.Interfaces.Services;

namespace PC.Example.Domain
{
    public class PasswordService : IPasswordService
    {
        private const string PatternNumber = @"[0-9]+";
        private const string PatternUpperChar = @"[A-Z]+";
        private const string PatternLowerChar = @"[A-Z]+";
        private const string PatternMinimumNineChars = @".{9,}";
        private const string PatternSpecialChar = @"[!@#$%^&*()-+]+";
        
        public bool Validate(string password)
        {
            return Regex.IsMatch(password, PatternNumber)
                   && Regex.IsMatch(password, PatternUpperChar)
                   && Regex.IsMatch(password, PatternLowerChar)
                   && Regex.IsMatch(password, PatternMinimumNineChars)
                   && Regex.IsMatch(password, PatternSpecialChar)
                   && password.Distinct().Count() == password.Length;
        }
    }
}