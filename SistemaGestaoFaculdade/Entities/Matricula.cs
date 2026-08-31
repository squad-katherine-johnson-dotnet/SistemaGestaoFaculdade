namespace SistemaGestaoFaculdade.Entities
{
    public class Matricula
    {
        public Aluno Aluno { get; private set; }
        public Curso Curso { get; private set; }
        public Boletim Boletim { get; private set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            Aluno = aluno;
            Curso = curso;
            Boletim = new Boletim();
        }
    }
}