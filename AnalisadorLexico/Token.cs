using System.Text.RegularExpressions;

namespace AnalisadorLexico
{
    public class Token 
    {
        public string Name { get; set; }
        public bool IsNumber { get; set; }
        public bool IsIdent { get; set; }
        public bool IsString { get; set; }
        public bool IsIncompleteString { get; set; }
        public Regex? Validator { get; set; }

        public Token() 
        {
            Name = "";
        }
    }
}

