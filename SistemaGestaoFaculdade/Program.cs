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

            // BIANCA

            break;
        case 2:

            // ROSANA

            break;
        case 3:

            // ROSANA

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

            // ROSANA

            break;
        case 9:

            // BIANCA

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