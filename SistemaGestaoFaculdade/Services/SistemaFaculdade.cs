using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;

namespace SistemaGestaoFaculdade.Services {
    public class SistemaFaculdade {

        public List<Curso> Cursos { get; set; } = new();
        public List<Disciplina> Disciplinas { get; set; } = new(); 
        public List<Aluno> Alunos { get; set; } = new();
        public List<Professor> Professores { get; set; } = new();

        public void CadastrarCurso(Curso curso) {

            if (Cursos.Any(x => x.Codigo == curso.Codigo)) throw new ArgumentException("Já existe um curso cadastrado com esse código!");

            Cursos.Add(curso);
        }

        public void ConsultarCursos() {

            foreach (var curso in Cursos) {

                Console.WriteLine("\n-------------- Curso --------------");
                Console.WriteLine($"Nome: {curso.Nome.ToUpper()} - {curso.Codigo.ToUpper()}");
                Console.WriteLine($"Tipo: {(curso.Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-Graduação")}");

                /*

                Console.WriteLine("\nDisciplinas:");

                IMPLEMENTAR APÓS ESQUELETO!!!

                Console.WriteLine("\nAlunos matriculados:");

                */
            }
        }
    }
}
