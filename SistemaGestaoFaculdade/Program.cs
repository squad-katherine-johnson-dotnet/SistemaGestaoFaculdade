using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;
using SistemaGestaoFaculdade.Services;

SistemaFaculdade sistema = new SistemaFaculdade();

List<Aluno> alunos = new List<Aluno>();
List<Professor> professores = new List<Professor>();

bool continuar = true;

while (continuar) {

    Console.WriteLine("\n====================================");
    Console.WriteLine("         GESTÃO DA FACULDADE        ");
    Console.WriteLine("====================================");
    Console.WriteLine("1  - Cadastrar curso");
    Console.WriteLine("2  - Cadastrar professor");
    Console.WriteLine("3  - Cadastrar aluno");
    Console.WriteLine("4  - Cadastrar disciplina");
    Console.WriteLine("5  - Vincular disciplina a um curso");
    Console.WriteLine("6  - Matricular aluno em curso");
    Console.WriteLine("7  - Lançar nota");
    Console.WriteLine("8  - Consultar pessoas");
    Console.WriteLine("9  - Consultar cursos");
    Console.WriteLine("10 - Consultar matrículas");
    Console.WriteLine("11 - Consultar boletim");
    Console.WriteLine("12 - Enviar notificação");
    Console.WriteLine("0  - Sair");
    Console.WriteLine("====================================");

    Console.Write("Digite uma opção: ");

    if (!int.TryParse(Console.ReadLine(), out int opcao)) {
        Console.WriteLine("Digite uma opção válida!");
        continue;
    }

    switch (opcao) {
        case 1:
            CadastrarCurso();
            break;
        case 2:
            CadastrarProfessor();
            break;
        case 3:
            CadastrarAluno();
            break;
        case 4:

            // YASMIN

            break;
        case 5:

            // YASMIN

            break;
        case 6:

            // DANIELLA

            break;
        case 7:

            // MARIANA

            break;
        case 8:
            ConsultarPessoas();
            break;
        case 9:
            ConsultarCursos();
            break;
        case 10:

            // DANIELLA

            break;
        case 11:

            // MARIANA

            break;
        case 12:

            // GRUPO

            break;
        case 0:
            Console.WriteLine("Sistema encerrado.");
            continuar = false;
            break;

        default:
            Console.WriteLine("Digite uma opção válida!");
            break;
    }
}

void CadastrarCurso() {
    Console.WriteLine("\n====================================");
    Console.WriteLine("          Cadastro de curso         ");
    Console.WriteLine("====================================");


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
}

void CadastrarAluno() {
    Console.Clear();
    Console.WriteLine("--- Cadastro de Aluno ---");

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? string.Empty;

    Console.Write("CPF: ");
    string cpf = Console.ReadLine() ?? string.Empty;

    //Regra de negócio: Validar CPF único, sem repetição.
    if (alunos.Any(a => a.Cpf == cpf) || professores.Any(p => p.Cpf == cpf)) {
        Console.WriteLine("Erro: Já existe uma pessoa cadastrada com este CPF.");
        return;
    }

    Console.Write("E-mail: ");
    string email = Console.ReadLine() ?? string.Empty;

    Console.Write("Número de Matrícula: ");
    string matricula = Console.ReadLine() ?? string.Empty;

    //Regra de negócio: Validar matrícula única.
    if (alunos.Any(a => a.Matricula == matricula)) {
        Console.WriteLine("Erro: Já existe um aluno cadastrado com este número de matrícula.");
        return;
    }

    Aluno novoAluno = new Aluno {
        Nome = nome,
        Cpf = cpf,
        Email = email,
        Matricula = matricula
    };

    alunos.Add(novoAluno);
    Console.WriteLine("Sucesso: Aluno cadastrado com sucesso!");
}

void CadastrarProfessor() {
    Console.Clear();
    Console.WriteLine("--- Cadastro de Professor ---");

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? string.Empty;

    Console.Write("CPF: ");
    string cpf = Console.ReadLine() ?? string.Empty;

    //Regra: validar CPF único
    if (alunos.Any(a => a.Cpf == cpf) || professores.Any(p => p.Cpf == cpf)) {
        Console.WriteLine("Erro: Já existe uma pesssoa cadastrada com este CPF.");
        return;
    }

    Console.Write("E-mail: ");
    string email = Console.ReadLine() ?? string.Empty;

    Console.Write("Registro: ");
    string registro = Console.ReadLine() ?? string.Empty;

    //Regra: validar registro único do professor.
    if (professores.Any(p => p.Registro == registro)) {
        Console.WriteLine("Erro: Já existe um professor cadastrado com este registro.");
        return;
    }

    Console.Write("Especialidade: ");
    string especialidade = Console.ReadLine() ?? string.Empty;

    Professor novoProfessor = new Professor {
        Nome = nome,
        Cpf = cpf,
        Email = email,
        Registro = registro,
        Especialidade = especialidade
    };

    professores.Add(novoProfessor);
    Console.WriteLine("Sucesso: Professor cadastrado com sucesso!");
}

void ConsultarPessoas() {
    Console.Clear();
    Console.WriteLine("--- Consulta de Pessoas ---");

    Console.WriteLine("\n=== PROFESSORES ===");
    if (professores.Count == 0) {
        Console.WriteLine("Nenhum professor cadastrado.");
    }
    else {
        foreach (var prof in professores) {
            prof.ExibirDados();//Uso do método polimórfico
        }
    }

    Console.WriteLine("\n=== ALUNOS ===");
    if (alunos.Count == 0) {
        Console.WriteLine("Nenhum aluno cadastrado.");
    }
    else {
        foreach (var aluno in alunos) {
            aluno.ExibirDados();
        }
    }
}

void ConsultarCursos() {

    Console.WriteLine("\n====================================");
    Console.WriteLine("          Consultar cursos         ");
    Console.WriteLine("====================================");

    sistema.ConsultarCursos();
}

