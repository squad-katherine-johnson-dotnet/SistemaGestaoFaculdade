using SistemaGestaoFaculdade.Interfaces;

namespace SistemaGestaoFaculdade.Entities {

    public class Aluno : Pessoa, INotificavel {
        public string Matricula { get; set; } = string.Empty;

        public Aluno(string nome, string cpf, string email, string matricula) : base(nome, cpf, email) {
            Matricula = matricula.Trim();
        }

        public override void ExibirDados() {
            base.ExibirDados();
            Console.WriteLine($"Número de matrícula: {Matricula}");
            Console.WriteLine("------------------------------------");
        }

        public void ReceberNotificacao(string mensagem) {
            Console.WriteLine($"Notificação para o aluno {Nome}: \"{mensagem}\" ");
        }
    }
}
