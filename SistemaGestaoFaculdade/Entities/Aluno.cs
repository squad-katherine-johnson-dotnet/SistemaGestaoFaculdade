using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloPOO.DesafioSquad.Models
{   //Aluno herda da Pessoa (Nome, CPF, E-mail) e implementa INotificavel
    internal class Aluno : Pessoa, INotificavel
    {
        public string Matricula { get; set; } = string.Empty;

        //ExibirDados para adicionar a matrícula do aluno
        public override void ExibirDados()
        {
               base.ExibirDados(); //Puxa o nome, cpf, e e-mail da classe pai (Pessoa)
            Console.WriteLine($"Número de Matrícula: {Matricula}");
            Console.WriteLine("----------------------------------");
        }

        //Cumpri o contrato da interface Inotificavel
        public void ReceberNotificacao(string mensagem)
        {
            Console.WriteLine($"Notificação para o aluno {Nome}: \"{ mensagem}\" "); 
        }
    }
}
