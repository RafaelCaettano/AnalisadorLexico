namespace AnalisadorLexico
{
    public class Lexitoken 
    {
        public string Lexema { get; set; }
        public Token Token { get; set; }

        public Lexitoken() 
        {
            Lexema = "";
            Token = new Token();
        }
    }
}