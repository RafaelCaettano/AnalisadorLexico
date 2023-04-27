namespace AnalisadorLexico
{
    public class LexicalTable 
    {
        private List<Lexitoken> _lexitokens;
        public IReadOnlyList<Lexitoken> Lexitokens => _lexitokens;

        public LexicalTable() 
        {
            _lexitokens = new List<Lexitoken>();
        }

        public void AddLexitoken(string lexema, Token token) 
        {
            var lexitoken = new Lexitoken() 
            {
                Lexema = lexema,
                Token = token
            };

            _lexitokens.Add(lexitoken);
        }

        public void AddLexitoken(Lexitoken lexitoken) 
        {
            _lexitokens.Add(lexitoken);
        }

        public Lexitoken? IdentifyLexema(string lexema) 
        {
            var lexitoken = new Lexitoken();
            
            lexitoken = _lexitokens.Find(x => x.Lexema == lexema);
            if (lexitoken == null && IsNumber(lexema)) 
                lexitoken = _lexitokens.Find(x => x.Token.IsNumber);
            else if (lexitoken == null && IsString(lexema)) 
                lexitoken = _lexitokens.Find(x => x.Token.IsString);
            else if (lexitoken == null)
                lexitoken = _lexitokens.Find(x => x.Token.IsIdent);
                
            if (lexitoken != null)
            {
                lexitoken.Lexema = lexema;
                AddLexitoken(lexitoken);
            }
            
            return lexitoken;
        }

        private bool IsNumber(string lexema) => float.TryParse(lexema, out _);
        private bool IsString(string lexema) 
        {
            char fisrtChar = lexema[0];
            char lastChar = lexema[lexema.Length - 1];

            return fisrtChar == '"' && lastChar == '"';
        }
    }
}