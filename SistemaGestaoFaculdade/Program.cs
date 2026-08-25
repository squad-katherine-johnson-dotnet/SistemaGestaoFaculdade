using ModuloPOO.DesafioSquad.Models;

class Program
{
    // Listas em memória para armazenar os cadastros
    static List<Aluno> alunos = new List<Aluno>();
    static List<Professor> professores = new List<Professor>();

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("========= SISTEMA DE GESTÃO DA FACULDADE SKJ =========");
            Console.WriteLine("01 - Cadastrar curso");
            Console.WriteLine("02 - Cadastrar professor");
            Console.WriteLine("03 - Cadastrar aluno");
            Console.WriteLine("04 - Cadastrar disciplina");
            Console.WriteLine("05 - Realizar matrícula");
            Console.WriteLine("06 - Lançar notas e faltas");
            Console.WriteLine("07 - Consultar boletim");
            Console.WriteLine("08 - Consultar pessoas");
            Console.WriteLine("09 - Consultar cursos e disciplinas");
            Console.WriteLine("10 - Consultar matrículas");
            Console.WriteLine("11 - Gerar relatório geral");
            Console.WriteLine("12 - Enviar notificação");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 01:
                        Console.WriteLine("\nCadastro de curso.");
                        break;
                    case 02:
                        CadastrarProfessor();
                        break;
                    case 03:
                        CadastrarAluno();
                        break;
                    case 04:
                        Console.WriteLine("\nCadastro de disciplina.");
                        break;
                    case 05:
                        Console.WriteLine("\nRealizar matrícula.");
                        break;
                    case 06:
                        Console.WriteLine("\nLançar notas e faltas.");
                        break;
                    case 07:
                        Console.WriteLine("\nConsultar boletim.");
                        break;
                    case 08:
                        ConsultarPessoas();
                        break;
                    case 09:
                        Console.WriteLine("\nConsultas gerais.");
                        break;
                    case 10:
                        Console.WriteLine("\nConsultar matrículas.");
                        break;
                    case 11:
                        Console.WriteLine("\nRelatório geral.");
                        break;
                    case 12:
                        Console.WriteLine("\nEnviar notificação.");
                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do sistema. Até logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Escolha um número de 0 a 12.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPor favor, digite um número válido.");
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();//Pausa a tela até se ler a mensagem.
            }

        } while (opcao != 0);//O loop continua rodando até que se digite 0 para sair.
    }
        static void CadastrarAluno()
    {
        Console.Clear();
        Console.WriteLine("--- Cadastro de Aluno ---");

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? string.Empty;
        
        //Regra de negócio: Validar CPF único, sem repetição.
        if (alunos.Any(a => a.Cpf == cpf) || professores.Any(p => p.Cpf == cpf))
        {
            Console.WriteLine("Erro: Já existe uma pessoa cadastrada com este CPF.");
            return;
        }

        Console.Write("E-mail: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.Write("Número de Matrícula: ");
        string matricula = Console.ReadLine() ?? string.Empty;

        //Regra de negócio: Validar matrícula única.
        if (alunos.Any(a => a.Matricula == matricula))
        {
            Console.WriteLine("Erro: Já existe um aluno cadastrado com este número de matrícula.");
            return;
        }

        Aluno novoAluno = new Aluno
        {
            Nome = nome,
            Cpf = cpf,
            Email = email,
            Matricula = matricula
        };

        alunos.Add(novoAluno);
        Console.WriteLine("Sucesso: Aluno cadastrado com sucesso!");
    }

    static void CadastrarProfessor()
    {
        Console.Clear();
        Console.WriteLine("--- Cadastro de Professor ---");

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        //Regra: validar CPF único
        if (alunos.Any(a => a.Cpf == cpf) || professores.Any(p => p.Cpf == cpf))
        {
            Console.WriteLine("Erro: Já existe uma pesssoa cadastrada com este CPF.");
            return;
        }

        Console.Write("E-mail: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.Write("Registro: ");
        string registro = Console.ReadLine() ?? string.Empty;

        //Regra: validar registro único do professor.
        if (professores.Any(p => p.Registro == registro))
        {
            Console.WriteLine("Erro: Já existe um professor cadastrado com este registro.");
            return;
        }

        Console.Write("Especialidade: ");
        string especialidade = Console.ReadLine() ?? string.Empty;

        Professor novoProfessor = new Professor
        {
            Nome = nome,
            Cpf = cpf,
            Email = email,
            Registro = registro,
            Especialidade = especialidade
        };

        professores.Add(novoProfessor);
        Console.WriteLine("Sucesso: Professor cadastrado com sucesso!");
    }

    static void ConsultarPessoas()
    {
        Console.Clear();
        Console.WriteLine("--- Consulta de Pessoas ---");

        Console.WriteLine("\n=== PROFESSORES ===");
        if (professores.Count == 0)
        {
            Console.WriteLine("Nenhum professor cadastrado.");
        }
        else
        {
            foreach (var prof in professores)
            {
                prof.ExibirDados();//Uso do método polimórfico
            }
        }

        Console.WriteLine("\n=== ALUNOS ===");
        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            foreach (var aluno in alunos)
            {
                aluno.ExibirDados();
            }
        }
    }
}
