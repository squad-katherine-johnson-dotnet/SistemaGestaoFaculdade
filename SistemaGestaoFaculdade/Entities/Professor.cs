using SistemaGestaoFaculdade.Interfaces;

namespace SistemaGestaoFaculdade.Entities {
    //Professor herda de Pessoa e também implementa a interface de notificação
    public class Professor : Pessoa, INotificavel
    {
        public  string Registro { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;

        //Exibe os dados comuns e acrescenta os específicos do professor
        public override void ExibirDados()
        {
                base.ExibirDados();
            Console.WriteLine($"Registro: {Registro}");
            Console.WriteLine($"Especialista: {Especialidade}");
            Console.WriteLine("--------------------------------");
        }

        public void ReceberNotificacao(string mensagem)
        {
            Console.WriteLine($"Notificação para o Professor {Nome}: \"{mensagem}\" ");
        }
    }
}
