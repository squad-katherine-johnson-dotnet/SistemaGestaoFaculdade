using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;

namespace SistemaGestaoFaculdade.Services
{
    public class SistemaFaculdade
    {

        public List<Curso> Cursos { get; set; } = new();
        public List<Disciplina> Disciplinas { get; set; } = new();
        public List<Aluno> Alunos { get; set; } = new();
        public List<Professor> Professores { get; set; } = new();

        public void CadastrarCurso(Curso curso)
        {

            if (Cursos.Any(x => x.Codigo == curso.Codigo)) throw new ArgumentException("Já existe um curso cadastrado com esse código!");

            Cursos.Add(curso);
        }

        public void CadastrarDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Any(x => x.Codigo == disciplina.Codigo))
                throw new ArgumentException("Já existe uma disciplina cadastrada com esse código");

            Disciplinas.Add(disciplina);
        }

        public void VincularDisciplinaCurso(Curso curso, Disciplina disciplina)
        {
            if (curso.Disciplinas.Any(x => x.Codigo == disciplina.Codigo))
                throw new ArgumentException("Essa disciplina já está vinculada a esse curso");

            curso.Disciplinas.Add(disciplina);
        }

        public void ConsultarCursos()
        {

            foreach (var curso in Cursos)
            {

                Console.WriteLine("\n-------------- Curso ---------------");
                Console.WriteLine($"Nome: {curso.Nome.ToUpper()} - {curso.Codigo.ToUpper()}");
                Console.WriteLine($"Tipo: {(curso.Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-Graduação")}");

                Console.WriteLine("\nDisciplinas:");
                foreach (var disciplina in curso.Disciplinas) {
                    Console.WriteLine(disciplina.Nome);
                    Console.WriteLine($"Professor(a): {disciplina.ProfessorResponsavel}");
                }

                /*
                Console.WriteLine("\nAlunos matriculados:");
                foreach (var disciplina in curso.Disciplinas) {
                    Console.WriteLine(disciplina.Nome);
                    Console.WriteLine($"Professor(a): {disciplina.ProfessorResponsavel}");
                }
                */
            }
        }
    }
}
