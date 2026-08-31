using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;
using SistemaGestaoFaculdade.Services;

SistemaFaculdade sistema = new SistemaFaculdade();

List<Aluno> alunos = new List<Aluno>();
List<Professor> professores = new List<Professor>();
List<Matricula> matriculas = new List<Matricula>();

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

    try {
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
        Console.WriteLine("Curso cadastrado com sucesso!");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadKey();
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

void CadastrarDisciplina() {
    Console.Clear();
    Console.WriteLine("--- Cadastro de Disciplina ---");

    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? string.Empty;

    if (sistema.Disciplinas.Any(d => d.Codigo == codigo)) {
        Console.WriteLine("Erro: Já existe uma disciplina cadastrada com este código.");
        return;
    }

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? string.Empty;

    Console.Write("Carga horária: ");
    if (!int.TryParse(Console.ReadLine(), out int cargaHoraria)) {
        Console.WriteLine("Erro: Carga horária inválida.");
        return;
    }

    Console.Write("Registro do professor responsável: ");
    string registroProfessor = Console.ReadLine() ?? string.Empty;

    Professor? professor = professores.FirstOrDefault(
        p => p.Registro == registroProfessor
    );

    if (professor == null) {
        Console.WriteLine("Erro: Professor não encontrado. Cadastre o professor primeiro.");
        return;
    }

    Disciplina novaDisciplina = new Disciplina(
        codigo,
        nome,
        cargaHoraria,
        professor
    );

    sistema.CadastrarDisciplina(novaDisciplina);

    Console.WriteLine("Sucesso: Disciplina cadastrada com sucesso!");
}

void VincularDisciplinaCurso() {
    Console.Clear();
    Console.WriteLine("--- Vincular Disciplina a um Curso ---");

    Console.Write("Código do curso: ");
    string codigoCurso = Console.ReadLine() ?? string.Empty;

    Curso? curso = sistema.Cursos.FirstOrDefault(
        c => c.Codigo == codigoCurso
    );

    if (curso == null) {
        Console.WriteLine("Erro: Curso não encontrado.");
        return;
    }

    Console.Write("Código da disciplina: ");
    string codigoDisciplina = Console.ReadLine() ?? string.Empty;

    Disciplina? disciplina = sistema.Disciplinas.FirstOrDefault(
        d => d.Codigo == codigoDisciplina
    );

    if (disciplina == null) {
        Console.WriteLine("Erro: Disciplina não encontrada.");
        return;
    }

    if (curso.Disciplinas.Any(d => d.Codigo == disciplina.Codigo)) {
        Console.WriteLine("Erro: Essa disciplina já está vinculada a esse curso.");
        return;
    }

    sistema.VincularDisciplinaCurso(curso, disciplina);

    Console.WriteLine("Sucesso: Disciplina vinculada ao curso!");
}

void MatricularAlunoCurso() {
    Console.Clear();
    Console.WriteLine("--- Matrícula de Aluno em Curso ---");

    // Selecionar aluno
    Console.Write("Digite o número de matrícula do aluno: ");
    string numeroMatricula = Console.ReadLine() ?? string.Empty;

    Aluno? aluno = alunos.FirstOrDefault(
        a => a.Matricula == numeroMatricula
    );

    // Regra: o aluno deve existir
    if (aluno == null) {
        Console.WriteLine("Erro: Aluno não encontrado.");
        return;
    }

    // Selecionar curso
    Console.Write("Digite o código do curso: ");
    string codigoCurso = Console.ReadLine() ?? string.Empty;

    Curso? curso = sistema.Cursos.FirstOrDefault(
        c => c.Codigo == codigoCurso
    );

    // Regra: o curso deve existir
    if (curso == null) {
        Console.WriteLine("Erro: Curso não encontrado.");
        return;
    }

    // Regra: aluno não pode ser matriculado duas vezes no mesmo curso
    bool jaMatriculado = matriculas.Any(
        m => m.Aluno.Matricula == aluno.Matricula &&
             m.Curso.Codigo == curso.Codigo
    );

    if (jaMatriculado) {
        Console.WriteLine("Erro: Este aluno já está matriculado neste curso.");
        return;
    }

    // Cria a matrícula
    Matricula novaMatricula = new Matricula(aluno, curso);

    // Adiciona a matrícula à lista
    matriculas.Add(novaMatricula);

    Console.WriteLine("\n====================================");
    Console.WriteLine("     MATRÍCULA REALIZADA COM SUCESSO");
    Console.WriteLine("====================================");
    Console.WriteLine($"Aluno: {aluno.Nome}");
    Console.WriteLine($"Matrícula: {aluno.Matricula}");
    Console.WriteLine($"Curso: {curso.Nome}");
    Console.WriteLine($"Tipo: {curso.Tipo}");
    Console.WriteLine("Boletim criado automaticamente!");
    Console.WriteLine("====================================");
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

void ConsultarMatriculas() {
    Console.Clear();

    Console.WriteLine("--- Consultar Matrículas ---");

    // Verifica se existem matrículas cadastradas
    if (matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    // Percorre todas as matrículas
    foreach (var matricula in matriculas) {
        Console.WriteLine("\n------------------------------------");
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
        Console.WriteLine($"Matrícula: {matricula.Aluno.Matricula}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome}");
        Console.WriteLine($"Tipo: {matricula.Curso.Tipo}");
        Console.WriteLine("------------------------------------");
    }
}

void LancarNota() {
    Console.Clear();
    Console.WriteLine("--- Lançar Nota ---");

    if (matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    Console.Write("Digite a matrícula do aluno: ");
    string numeroMatricula = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Digite o código do curso: ");
    string codigoCurso = Console.ReadLine()?.Trim() ?? string.Empty;

    Matricula? matricula = matriculas.FirstOrDefault(m =>
        m.Aluno.Matricula.Equals(
            numeroMatricula,
            StringComparison.OrdinalIgnoreCase
        ) &&
        m.Curso.Codigo.Equals(
            codigoCurso,
            StringComparison.OrdinalIgnoreCase
        )
    );

    if (matricula is null) {
        Console.WriteLine("Matrícula não encontrada para esse aluno e curso.");
        return;
    }

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

    Disciplina? disciplina = matricula.Curso.Disciplinas.FirstOrDefault(d =>
        d.Codigo.Equals(
            codigoDisciplina,
            StringComparison.OrdinalIgnoreCase
        )
    );

    if (disciplina is null) {
        Console.WriteLine("A disciplina não pertence ao curso da matrícula.");
        return;
    }

    Console.Write("Digite a nota entre 0 e 10: ");

    if (!double.TryParse(Console.ReadLine(), out double valor)) {
        Console.WriteLine("Digite uma nota válida.");
        return;
    }

    try {
        Nota nota = new Nota(disciplina, valor);
        matricula.Boletim.AdicionarNota(nota);

        Console.WriteLine("\nNota lançada com sucesso!");
        Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
        Console.WriteLine($"Curso: {matricula.Curso.Nome}");
        Console.WriteLine($"Disciplina: {disciplina.Nome}");
        Console.WriteLine($"Nota: {valor:F1}");
    }
    catch (ArgumentException ex) {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}

void ConsultarBoletim() {
    Console.Clear();
    Console.WriteLine("--- Consultar Boletim ---");

    if (matriculas.Count == 0) {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
        return;
    }

    Console.Write("Digite a matrícula do aluno: ");
    string numeroMatricula = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Digite o código do curso: ");
    string codigoCurso = Console.ReadLine()?.Trim() ?? string.Empty;

    Matricula? matricula = matriculas.FirstOrDefault(m =>
        m.Aluno.Matricula.Equals(
            numeroMatricula,
            StringComparison.OrdinalIgnoreCase
        ) &&
        m.Curso.Codigo.Equals(
            codigoCurso,
            StringComparison.OrdinalIgnoreCase
        )
    );

    if (matricula is null) {
        Console.WriteLine("Matrícula não encontrada para esse aluno e curso.");
        return;
    }

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

    foreach (Nota nota in matricula.Boletim.Notas) {
        string situacao = nota.EstaAprovado(matricula.Curso.Tipo)
            ? "Aprovado"
            : "Reprovado";

        Console.WriteLine("------------------------------------");
        Console.WriteLine(
            $"Disciplina: {nota.Disciplina.Nome} " +
            $"({nota.Disciplina.Codigo})"
        );
        Console.WriteLine($"Nota: {nota.Valor:F1}");
        Console.WriteLine($"Situação: {situacao}");
    }

    Console.WriteLine("------------------------------------");
}