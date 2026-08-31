using Microsoft.Win32;
using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;
using SistemaGestaoFaculdade.Interfaces;
using SistemaGestaoFaculdade.Services;

SistemaFaculdade sistema = new SistemaFaculdade();

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
            CadastrarDisciplina();
            break;
        case 5:
            VincularDisciplinaCurso();
            break;
        case 6:
            MatricularAlunoCurso();
            break;
        case 7:
            LancarNota();
            break;
        case 8:
            ConsultarPessoas();
            break;
        case 9:
            ConsultarCursos();
            break;
        case 10:
            ConsultarMatriculas();
            break;
        case 11:
            ConsultarBoletim();
            break;
        case 12:
            EnviarNotificacao();
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
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("          Cadastro de Curso         ");
    Console.WriteLine("====================================");

    try {
        Console.Write("\nInforme o código do curso: ");
        string codigoCurso = Console.ReadLine()!;

        Console.Write("Informe o nome do curso: ");
        string nomeCurso = Console.ReadLine()!;

        Console.Write("Informe o tipo do curso (1 - Graduação | 2 - Pós Graduação): ");

        string tipoDigitado = Console.ReadLine()!;

        if (!int.TryParse(tipoDigitado, out int tipoSelecionado)) throw new ArgumentException("Tipo de curso informado é inválido.");

        TipoCurso tipoCurso = (TipoCurso)tipoSelecionado;

        Curso curso = new Curso(codigoCurso, nomeCurso, tipoCurso);

        sistema.CadastrarCurso(curso);
        Console.WriteLine("Curso cadastrado com sucesso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void CadastrarProfessor() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("       Cadastro de Professor        ");
    Console.WriteLine("====================================");

    try {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        Console.Write("E-mail: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.Write("Registro: ");
        string registro = Console.ReadLine() ?? string.Empty;

        Console.Write("Especialidade: ");
        string especialidade = Console.ReadLine() ?? string.Empty;

        Professor novoProfessor = new Professor(nome, cpf, email, registro, especialidade);

        sistema.CadastrarProfessor(novoProfessor);
        Console.WriteLine("Professor cadastrado com sucesso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void CadastrarAluno() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("         Cadastro de Aluno          ");
    Console.WriteLine("====================================");

    try {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        Console.Write("E-mail: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.Write("Número de Matrícula: ");
        string matricula = Console.ReadLine() ?? string.Empty;

        Aluno novoAluno = new Aluno(nome, cpf, email, matricula);

        sistema.CadastrarAluno(novoAluno);
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void CadastrarDisciplina() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("       Cadastro de Disciplina       ");
    Console.WriteLine("====================================");

    try {
        Console.Write("Código: ");
        string codigo = Console.ReadLine() ?? string.Empty;

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Carga horária: ");
        if (!int.TryParse(Console.ReadLine(), out int cargaHoraria)) throw new ArgumentException("Carga horária inválida.");

        Console.Write("Registro do professor responsável: ");
        string registroProfessor = Console.ReadLine() ?? string.Empty;

        Professor professor = sistema.BuscarProfessorPorRegistro(registroProfessor);

        Disciplina novaDisciplina = new Disciplina(codigo, nome, cargaHoraria, professor);

        sistema.CadastrarDisciplina(novaDisciplina);

        Console.WriteLine("Disciplina cadastrada com sucesso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void VincularDisciplinaCurso() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("   Vincular Disciplina a um Curso   ");
    Console.WriteLine("====================================");

    try {
        Console.Write("Código do curso: ");
        string codigoCurso = Console.ReadLine() ?? string.Empty;

        Curso curso = sistema.BuscarCursoPorCodigo(codigoCurso);

        Console.Write("Código da disciplina: ");
        string codigoDisciplina = Console.ReadLine() ?? string.Empty;

        Disciplina disciplina = sistema.BuscarDisciplinaPorCodigo(codigoDisciplina);

        sistema.VincularDisciplinaCurso(curso, disciplina);

        Console.WriteLine("Disciplina vinculada ao curso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void MatricularAlunoCurso() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("      Matricular Aluno em Curso     ");
    Console.WriteLine("====================================");

    try {
        Console.Write("Digite o número de matrícula do aluno: ");
        string numeroMatricula = Console.ReadLine() ?? string.Empty;

        Aluno aluno = sistema.BuscarAlunoPorMatricula(numeroMatricula);

        Console.Write("Digite o código do curso: ");
        string codigoCurso = Console.ReadLine() ?? string.Empty;

        Curso curso = sistema.BuscarCursoPorCodigo(codigoCurso);

        sistema.MatricularAlunoCurso(aluno, curso);

        Console.WriteLine("Matrícula realizada com sucesso!");
        Console.WriteLine($"\nAluno: {aluno.Nome}");
        Console.WriteLine($"Matrícula: {aluno.Matricula}");
        Console.WriteLine($"Curso: {curso.Nome.ToUpper()}");
        Console.WriteLine($"Tipo: {(curso.Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-Graduação")}");
        Console.WriteLine("Boletim criado automaticamente!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void ConsultarPessoas() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("          Consultar Pessoas         ");
    Console.WriteLine("====================================");

    Console.WriteLine("\n----------- Professores ------------ ");

    if (sistema.Professores.Count == 0) {
        Console.WriteLine("Nenhum professor cadastrado.");
    }
    else {
        foreach (var prof in sistema.Professores) {
            prof.ExibirDados();
        }
    }

    Console.WriteLine("\n----------- Alunos ------------ ");

    if (sistema.Alunos.Count == 0) {
        Console.WriteLine("Nenhum aluno cadastrado.");
    }
    else {
        foreach (var aluno in sistema.Alunos) {
            aluno.ExibirDados();
        }
    }
}

void ConsultarCursos() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("          Consultar Cursos         ");
    Console.WriteLine("====================================");

    if (!sistema.Cursos.Any()) {
        Console.WriteLine("Nenhum curso cadastrado.");
        return;
    }

    foreach (var curso in sistema.Cursos) {

        Console.WriteLine("\n-------------- Curso ---------------");
        Console.WriteLine($"Nome: {curso.Nome.ToUpper()} - {curso.Codigo.ToUpper()}");
        Console.WriteLine($"Tipo: {(curso.Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-Graduação")}");

        Console.WriteLine("\nDisciplinas:");

        if (!curso.Disciplinas.Any()) {
            Console.WriteLine("Nenhuma disciplina vinculada.");
        }
        else {
            foreach (var disciplina in curso.Disciplinas) {
                Console.WriteLine(disciplina.Nome);
                Console.WriteLine($"Professor(a): {disciplina.ProfessorResponsavel.Nome}");
            }
        }

        Console.WriteLine("\nAlunos matriculados:");

        var matriculasDoCurso = sistema.Matriculas.Where(m => m.Curso.Codigo == curso.Codigo);

        if (!matriculasDoCurso.Any()) {
            Console.WriteLine("Nenhum aluno matriculado.");
        }
        else {
            foreach (var matricula in matriculasDoCurso) {
                Console.WriteLine(matricula.Aluno.Nome.ToUpper());
                Console.WriteLine($"Matrícula: {matricula.Aluno.Matricula}");
            }
        }
        Console.WriteLine("------------------------------------");
    }
}

void ConsultarMatriculas() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("        Consultar Matrículas        ");
    Console.WriteLine("====================================");

    if (sistema.Matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    foreach (var matricula in sistema.Matriculas) {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome.ToUpper()}");
        Console.WriteLine($"Matrícula: {matricula.Aluno.Matricula}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome.ToUpper()}");
        Console.WriteLine($"Tipo: {(matricula.Curso.Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-Graduação")}");
        Console.WriteLine("------------------------------------");
    }
}

void LancarNota() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("            Lançar nota             ");
    Console.WriteLine("====================================");

    if (sistema.Matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    try {
        Console.Write("Digite a matrícula do aluno: ");
        string numeroMatricula = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Digite o código do curso: ");
        string codigoCurso = Console.ReadLine()?.Trim() ?? string.Empty;

        Matricula matricula = sistema.BuscarMatricula(numeroMatricula, codigoCurso);

        if (matricula.Curso.Disciplinas.Count == 0) {
            Console.WriteLine("Esse curso ainda não possui disciplinas vinculadas.");
            return;
        }

        Console.WriteLine("\nDisciplinas do curso:");

        foreach (Disciplina item in matricula.Curso.Disciplinas) {
            Console.WriteLine($"{item.Codigo} - {item.Nome}");
        }

        Console.Write("\nDigite o código da disciplina: ");
        string codigoDisciplina = Console.ReadLine()?.Trim() ?? string.Empty;

        Disciplina disciplina = sistema.BuscarDisciplinaDoCurso(matricula, codigoDisciplina);

        Console.Write("Digite a nota entre 0 e 10: ");

        if (!double.TryParse(Console.ReadLine(), out double valor)) {
            Console.WriteLine("Digite uma nota válida.");
            return;
        }

        sistema.LancarNota(matricula, disciplina, valor);

        Console.WriteLine("\nNota lançada com sucesso!");
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome}");
        Console.WriteLine($"Disciplina: {disciplina.Nome}");
        Console.WriteLine($"Nota: {valor:F1}");

    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void ConsultarBoletim() {
    Console.Clear();
    Console.WriteLine("\n====================================");
    Console.WriteLine("         Consultar Boletim          ");
    Console.WriteLine("====================================");

    if (sistema.Matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    try {
        Console.Write("Digite a matrícula do aluno: ");
        string numeroMatricula = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Digite o código do curso: ");
        string codigoCurso = Console.ReadLine()?.Trim() ?? string.Empty;

        Matricula matricula = sistema.BuscarMatricula(numeroMatricula, codigoCurso);

        Console.WriteLine("\n====================================");
        Console.WriteLine("              BOLETIM");
        Console.WriteLine("====================================");
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
        Console.WriteLine($"Matrícula: {matricula.Aluno.Matricula}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome}");
        Console.WriteLine($"Tipo: {matricula.Curso.Tipo}");

        if (matricula.Boletim.Notas.Count == 0) {
            Console.WriteLine("\nNenhuma nota lançada.");
            return;
        }

        Console.WriteLine("\nNotas:");

        foreach (var nota in matricula.Boletim.Notas) {
            string situacao = nota.EstaAprovado(matricula.Curso.Tipo) ? "Aprovado" : "Reprovado";

            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Disciplina: {nota.Disciplina.Nome} " + $"({nota.Disciplina.Codigo})");
            Console.WriteLine($"Nota: {nota.Valor:F1}");
            Console.WriteLine($"Situação: {situacao}");
        }

        Console.WriteLine("------------------------------------");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
}

void EnviarNotificacao() {
    Console.Clear();
    Console.WriteLine("--- Enviar Notificação ---");
    Console.WriteLine("1 - Aluno");
    Console.WriteLine("2 - Professor");
    Console.Write("Escolha o destinatário: ");

    if (!int.TryParse(Console.ReadLine(), out int tipoDestinatario)) {
        Console.WriteLine("Opção inválida.");
        return;
    }

    INotificavel? destinatario = null;

    if (tipoDestinatario == 1) {
        Console.Write("Digite a matrícula do aluno: ");
        string numeroMatricula =
            Console.ReadLine()?.Trim() ?? string.Empty;

        destinatario = sistema.Alunos.FirstOrDefault(a =>
            a.Matricula.Equals(
                numeroMatricula,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (destinatario is null) {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }
    }
    else if (tipoDestinatario == 2) {
        Console.Write("Digite o registro do professor: ");
        string registroProfessor =
            Console.ReadLine()?.Trim() ?? string.Empty;

        destinatario = sistema.Professores.FirstOrDefault(p =>
            p.Registro.Equals(
                registroProfessor,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (destinatario is null) {
            Console.WriteLine("Professor não encontrado.");
            return;
        }
    }
    else {
        Console.WriteLine("Opção inválida.");
        return;
    }

    Console.Write("Digite a mensagem: ");
    string mensagem = Console.ReadLine()?.Trim() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(mensagem)) {
        Console.WriteLine("A mensagem não pode ficar vazia.");
        return;
    }

    destinatario.ReceberNotificacao(mensagem);
    Console.WriteLine("Notificação enviada com sucesso!");
}