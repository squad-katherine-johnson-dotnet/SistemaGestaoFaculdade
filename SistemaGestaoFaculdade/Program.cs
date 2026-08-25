using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;
using SistemaGestaoFaculdade.Services;

SistemaFaculdade sistema = new SistemaFaculdade();

/* OPÇÃO 1 DO MENU - CADASTRAR CURSO

Console.WriteLine("\n============================");
Console.WriteLine("     Cadastro de curso      ");
Console.WriteLine("============================");

Console.Write("\nInforme o código do curso: ");
string codigoCurso = Console.ReadLine();

Console.Write("Informe o nome do curso: ");
string nomeCurso = Console.ReadLine();

Console.Write("Informe o tipo do curso (1 - Graduação | 2 - Pós Graduação): ");

string tipoDigitado = Console.ReadLine();

if (!int.TryParse(tipoDigitado, out int tipoSelecionado)) throw new ArgumentException("Tipo de curso informado é inválido.");

TipoCurso tipoCurso = (TipoCurso)tipoSelecionado;

Curso curso = new Curso(codigoCurso, nomeCurso, tipoCurso);

sistema.CadastrarCurso(curso);
*/


/* OPÇÃO 9 DO MENU - CONSULTAR CURSOS

Console.WriteLine("\n============================");
Console.WriteLine("      Consultar cursos      ");
Console.WriteLine("============================");

sistema.ConsultarCursos();

*/


