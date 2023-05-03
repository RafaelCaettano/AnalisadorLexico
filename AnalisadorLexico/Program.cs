using AnalisadorLexico;
using System.Text.RegularExpressions;

var compiler = new Compiler();

compiler.AddToken("OP_ATRIBUICAO", new Regex(@"="));
compiler.AddToken("OP_DECISAO", new Regex(@"if"));
compiler.AddToken("OP_DECISAO_FUGA", new Regex(@"else"));
compiler.AddToken("MENOR_QUE", new Regex(@"<"));
compiler.AddToken("OP_BLOCO", new Regex(@":"));
compiler.AddToken("PARENTESES_ABERTO", new Regex(@"\("));
compiler.AddToken("PARENTESES_FECHADO", new Regex(@"\)"));
compiler.AddToken("NUMBER", new Regex(@"\d+"), isNumber:true);
compiler.AddToken("STRING", new Regex("\"((\\\\\")|[^\"])*\""), isString:true);
compiler.AddToken("STRING_INCOMPLETA", new Regex("\"[^\"\n]*$"), isIncompleteString:true);
compiler.AddToken("IDENTIFICADOR", new Regex(@"[a-zA-Z]+"), isIdent:true);
compiler.AddToken("MAIOR_QUE", new Regex(@">"));

compiler.Tokenize("C:/Users/rafaC/Downloads/atividade002E.cop");

Console.WriteLine("Código válido: " + compiler.LexicalAnalysis());

Console.WriteLine($"\n{("Lexema").PadRight(20)} \t {("Token").PadRight(20)}");
foreach (var lexitoken in compiler.LexicalTable.Lexitokens)
    Console.WriteLine($"{lexitoken.Lexema.PadRight(20)} \t {lexitoken.Token.Name.PadRight(20)}");