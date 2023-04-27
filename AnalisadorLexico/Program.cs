using AnalisadorLexico;

var compiler = new Compiler();

compiler.AddToken("OP_ATRIBUICAO");
compiler.AddToken("OP_DECISAO");
compiler.AddToken("OP_DECISAO_FUGA");
compiler.AddToken("MENOR_QUE");
compiler.AddToken("OP_BLOCO");
compiler.AddToken("PARENTESES_ABERTO");
compiler.AddToken("PARENTESES_FECHADO");
compiler.AddToken("NUMBER", isNumber:true);
compiler.AddToken("STRING", isString:true);
compiler.AddToken("IDENTIFICADOR", isIdent:true);
compiler.AddToken("MAIOR_QUE");

compiler.AddLexitoken("=", 0);
compiler.AddLexitoken("if", 1);
compiler.AddLexitoken("else", 2);
compiler.AddLexitoken("<", 3);
compiler.AddLexitoken(":", 4);
compiler.AddLexitoken("(", 5);
compiler.AddLexitoken(")", 6);
compiler.AddLexitoken("NUMBER", 7);
compiler.AddLexitoken("STRING", 8);
compiler.AddLexitoken("IDENTIFICADOR", 9);

compiler.ReadFile("C:/Users/rafaC/Downloads/atividade001.cop");