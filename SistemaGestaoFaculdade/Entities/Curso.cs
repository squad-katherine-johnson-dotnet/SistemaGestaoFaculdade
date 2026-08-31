using SistemaGestaoFaculdade.Enums;

namespace SistemaGestaoFaculdade.Entities {
    public class Curso {

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public TipoCurso Tipo { get; private set; }
        public List<Disciplina> Disciplinas { get; private set; }

        public Curso(string codigo, string nome, TipoCurso tipo) {

            ValidarCodigo(codigo);

            ValidarNome(nome);

            if (!Enum.IsDefined(typeof(TipoCurso), tipo)) throw new ArgumentException("Tipo de curso informado é inválido.");

            Codigo = codigo.Trim().ToUpper();
            Nome = nome.Trim();
            Tipo = tipo;
            Disciplinas = new List<Disciplina>();
        }

        private void ValidarCodigo(string codigo) {
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("Código informado é inválido.");

            if (!codigo.All(char.IsLetter)) throw new ArgumentException("O código do curso deve conter apenas letras.");
        }

        private void ValidarNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome informado é inválido.");

            if (nome.All(char.IsDigit)) throw new ArgumentException("O nome do curso não pode conter apenas números.");
        }
    }
}
