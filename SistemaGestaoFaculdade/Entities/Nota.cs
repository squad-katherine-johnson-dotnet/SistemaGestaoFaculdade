using SistemaGestaoFaculdade.Enums;

namespace SistemaGestaoFaculdade.Entities {
    public class Nota {
        public Disciplina Disciplina { get; private set; }
        public double Valor { get; private set; }

        public Nota(Disciplina disciplina, double valor) {
            if (disciplina is null)
                throw new ArgumentNullException(nameof(disciplina), "A disciplina deve ser informada.");

            if (valor < 0 || valor > 10)
                throw new ArgumentException("A nota deve estar entre 0 e 10.");

            Disciplina = disciplina;
            Valor = valor;
        }

        public bool EstaAprovado(TipoCurso tipoCurso) {
            if (tipoCurso == TipoCurso.Graduacao)
                return Valor >= 7;

            if (tipoCurso == TipoCurso.PosGraduacao)
                return Valor >= 8;

            throw new ArgumentException("Tipo de curso inválido.");
        }
    }
}