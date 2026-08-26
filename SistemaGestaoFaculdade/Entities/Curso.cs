using SistemaGestaoFaculdade.Enums;

namespace SistemaGestaoFaculdade.Entities {
    public class Curso {

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public TipoCurso Tipo { get; private set; }
        public List<Disciplina> Disciplinas { get; private set; }

        public Curso(string codigo, string nome, TipoCurso tipo) {

            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("Código informado é inválido.");

            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome informado é inválido.");

            if (!Enum.IsDefined(typeof(TipoCurso), tipo)) throw new ArgumentException("Tipo de curso informado é inválido.");

            Codigo = codigo;
            Nome = nome;
            Tipo = tipo;
            Disciplinas = new List<Disciplina>();
        }
    }
}
