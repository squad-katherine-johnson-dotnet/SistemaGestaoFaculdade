namespace SistemaGestaoFaculdade.Entities {
    public class Disciplina {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public Professor ProfessorResponsavel { get; private set; }

        public Disciplina(string codigo, string nome, int cargaHoraria, Professor professorResponsavel) {

            ValidarCodigo(codigo);
            ValidarNome(nome);
            ValidarCargaHoraria(cargaHoraria);
            ValidarProfessor(professorResponsavel);

            Codigo = codigo.Trim().ToUpper();
            Nome = nome.Trim();
            CargaHoraria = cargaHoraria;
            ProfessorResponsavel = professorResponsavel;
        }

        private void ValidarCodigo(string codigo) {
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("Código informado é inválido.");

            if (!codigo.All(char.IsLetterOrDigit)) throw new ArgumentException("O código da disciplina deve conter apenas letras e números.");
        }

        private void ValidarNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome informado é inválido.");

            if (nome.All(char.IsDigit)) throw new ArgumentException("O nome da disciplina não pode conter apenas números.");
        }

        private void ValidarCargaHoraria(int cargaHoraria) {
            if (cargaHoraria <= 0) throw new ArgumentException("A carga horária deve ser maior que zero.");
        }

        private void ValidarProfessor(Professor professorResponsavel) {
            if (professorResponsavel == null) throw new ArgumentException("Professor responsável é obrigatório.");
        }
    }
}