using SistemaGestaoFaculdade.Interfaces;

namespace SistemaGestaoFaculdade.Entities {
    public class Professor : Pessoa, INotificavel {
        public string Registro { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;

        public Professor(string nome, string cpf, string email, string registro, string especialidade) : base(nome, cpf, email) {
            Registro = registro;
            Especialidade = especialidade;
        }

        public override void ExibirDados() {
            base.ExibirDados();
            Console.WriteLine($"Registro: {Registro}");
            Console.WriteLine($"Especialista: {Especialidade}");
            Console.WriteLine("------------------------------------");
        }

        public void ReceberNotificacao(string mensagem) {
            Console.WriteLine($"Notificação para o Professor {Nome}: \"{mensagem}\" ");
        }
    }
}
