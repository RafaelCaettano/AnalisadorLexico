namespace AnalisadorLexico
{
    public class Compiler 
    {
        private LexicalTable _lexicalTable;
        public LexicalTable LexicalTable => _lexicalTable;

        private List<Token> _tokens;
        public IReadOnlyList<Token> Tokens => _tokens;
        
        public Compiler()
        {
            _lexicalTable = new LexicalTable();
            _tokens = new List<Token>();
        }

        public void ReadFile(string filePath) 
        {
            using var file = new StreamReader(filePath);
            string? line;

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Lexema \t\t\t Token");
            while ((line = file.ReadLine()) != null)
            {
                foreach (string word in line.Trim().Split(" "))
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        var lexitoken = IdentifyLexema(word);
                        if (lexitoken != null)
                            Console.WriteLine($"{lexitoken.Lexema.PadRight(20)} \t {lexitoken.Token.Name.PadRight(20)}");
                    }
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");


            file.Close();
        }

        public void AddToken(string name, bool isNumber = false, bool isIdent = false, bool isString = false) 
        {
            var token = GetTokenByName(name);
            if (token == null)
            {
                token = new Token() 
                {
                    Name = name,
                    IsNumber = isNumber,
                    IsIdent = isIdent,
                    IsString = isString
                };
                _tokens.Add(token);
            }
        }

        public void AddLexitoken(string lexema, int tokenIndex, bool isNumber = false) {
            Token? token = _tokens[tokenIndex];

            if (token != null) 
                _lexicalTable.AddLexitoken(lexema, token);
        }

        private Token? GetTokenByName(string name) => _tokens.Find(token => token.Name == name);
        public Lexitoken? IdentifyLexema(string lexema) => _lexicalTable.IdentifyLexema(lexema);
    }
}

