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
    }
}

