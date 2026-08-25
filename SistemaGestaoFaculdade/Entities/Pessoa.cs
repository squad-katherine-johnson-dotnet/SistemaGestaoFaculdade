using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloPOO.DesafioSquad.Models
{
    public abstract class Pessoa
    {
        //Propriedades comuns a qualquer pessoa no sistema
        public string Nome { get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;

        //Exibe dados básicos (pode ser sobrescrito pelas classes filhos)
        public virtual void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"E-mail: {Email}");
        }
    }
}
