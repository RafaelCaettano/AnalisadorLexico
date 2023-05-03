using System.Text.RegularExpressions;

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

        public IEnumerable<string> ReadFile(string filePath) 
        {
            using var file = new StreamReader(filePath);
            string? line;

            while ((line = file.ReadLine()) != null)
                yield return line;

            file.Close();
        }

        public void Tokenize(string filePath)
        {
            foreach (var line in ReadFile(filePath))
            {
                foreach (var lexeme in SplitLexemas(line.Trim()))
                {
                    var matchedToken = _tokens.FirstOrDefault(t => t.Validator?.Match(lexeme).Success ?? false);
                    if (matchedToken != null)
                    {
                        var tokenIndex = _tokens.IndexOf(matchedToken);
                        AddLexitoken(lexeme, tokenIndex);
                    }
                }
            }
        }

        public bool LexicalAnalysis()
        {
            var incompleteString = LexicalTable.Lexitokens.FirstOrDefault(lt => lt.Token.IsIncompleteString);
            if (incompleteString == null)
            {
                var previousLexitoken = new Lexitoken();
                foreach (var lexitoken in LexicalTable.Lexitokens)
                {
                    if (previousLexitoken.Token.IsIdent && lexitoken.Token.IsIdent)
                        return false;

                    previousLexitoken = lexitoken;
                }
            }
            else 
                return false;

            return true;
        }

        public string IdentifyString(string line, out string subLine) 
        {
            subLine = line;
            var regexString = new Regex("\"((\\\\\")|[^\"])*\"");
            var match = regexString.Match(line);

            if (match.Success)
                subLine = line.Replace(match.Value, "");
                
            return match.Value;
        }

        public IEnumerable<string> SplitLexemas(string line)
        {
            string stringInLine = IdentifyString(line, out line);
            var lineSplited = line.Split(" ").ToList();
    
            if (!String.IsNullOrWhiteSpace(stringInLine))
                lineSplited.Add(stringInLine);

            foreach (string lexema in lineSplited)
                yield return lexema;
        }

        public void AddToken(string name, Regex? validator = null, bool isNumber = false, bool isIdent = false, bool isString = false, bool isIncompleteString = false) 
        {
            var token = GetTokenByName(name);
            if (token == null)
            {
                token = new Token() 
                {
                    Name = name,
                    IsNumber = isNumber,
                    IsIdent = isIdent,
                    IsString = isString,
                    IsIncompleteString = isIncompleteString,
                    Validator = validator
                };
                _tokens.Add(token);
            }
        }

        public void AddLexitoken(string lexema, int tokenIndex, Regex? validator = null) {
            Token? token = _tokens[tokenIndex];
            if (token.Validator == null && validator != null) 
                token.Validator = validator;

            if (token != null) 
                _lexicalTable.AddLexitoken(lexema, token);
        }

        private Token? GetTokenByName(string name) => _tokens.Find(token => token.Name == name);
    }
}

