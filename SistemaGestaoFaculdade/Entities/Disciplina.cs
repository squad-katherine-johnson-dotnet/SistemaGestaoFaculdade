namespace SistemaGestaoFaculdade.Entities
{
    public class Disciplina
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public Professor ProfessorResponsavel { get; private set; }

        public Disciplina(
            string codigo,
            string nome,
            int cargaHoraria,
            Professor professorResponsavel)
        {
            Codigo = codigo;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ProfessorResponsavel = professorResponsavel;
        }
    }
}