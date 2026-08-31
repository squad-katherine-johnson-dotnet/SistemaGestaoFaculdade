namespace SistemaGestaoFaculdade.Entities {
    public abstract class Pessoa {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Pessoa(string nome, string cpf, string email) {

            ValidarNome(nome);
            ValidarCpf(cpf);
            ValidarEmail(email);

            Nome = nome.Trim().ToUpper();
            Cpf = cpf.Trim();
            Email = email.Trim();
        }
        private void ValidarNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome informado é inválido.");

            if (nome.All(char.IsDigit)) throw new ArgumentException("O nome não pode conter apenas números.");
        }

        private void ValidarCpf(string cpf) {
            if (string.IsNullOrWhiteSpace(cpf)) throw new ArgumentException("CPF informado é inválido.");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit)) throw new ArgumentException("O CPF deve conter exatamente 11 números.");
        }

        private void ValidarEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail informado é inválido.");
        }
        public virtual void ExibirDados() {
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"E-mail: {Email}");
        }
    }
}
