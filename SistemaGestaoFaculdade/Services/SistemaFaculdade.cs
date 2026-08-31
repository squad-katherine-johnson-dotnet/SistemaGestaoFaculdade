using Microsoft.Win32;
using SistemaGestaoFaculdade.Entities;
using SistemaGestaoFaculdade.Enums;
using System.Runtime.Intrinsics.X86;

namespace SistemaGestaoFaculdade.Services {
    public class SistemaFaculdade {

        public List<Curso> Cursos { get; set; } = new();
        public List<Disciplina> Disciplinas { get; set; } = new();
        public List<Aluno> Alunos { get; set; } = new();
        public List<Professor> Professores { get; set; } = new();

        public void CadastrarCurso(Curso curso) {
            if (Cursos.Any(x => x.Codigo == curso.Codigo)) throw new ArgumentException("Já existe um curso cadastrado com esse código.");

            Cursos.Add(curso);
        }

        public void CadastrarProfessor(Professor professor) {

            if (Alunos.Any(a => a.Cpf == professor.Cpf) || Professores.Any(p => p.Cpf == professor.Cpf)) throw new ArgumentException("Já existe uma pesssoa cadastrada com este CPF.");

            if (Professores.Any(p => p.Registro == professor.Registro)) throw new ArgumentException("Já existe um professor cadastrado com este registro.");

            Professores.Add(professor);
        }

        public void CadastrarAluno(Aluno aluno) {

            if (Alunos.Any(a => a.Cpf == aluno.Cpf) || Professores.Any(p => p.Cpf == aluno.Cpf)) throw new ArgumentException("Já existe uma pesssoa cadastrada com este CPF.");

            if (Alunos.Any(a => a.Matricula == aluno.Matricula)) throw new ArgumentException("Já existe um aluno cadastrado com este número de matrícula.");

            Alunos.Add(aluno);
        }

        public void CadastrarDisciplina(Disciplina disciplina) {
            if (Disciplinas.Any(x => x.Codigo == disciplina.Codigo)) throw new ArgumentException("Já existe uma disciplina cadastrada com esse código");

            Disciplinas.Add(disciplina);
        }
        public Professor BuscarProfessorPorRegistro(string registro) {

            Professor? professor = Professores.FirstOrDefault(
                p => p.Registro == registro
            );

            if (professor == null) throw new ArgumentException("Professor não encontrado. Cadastre o professor primeiro.");

            return professor;
        }

        public void VincularDisciplinaCurso(Curso curso, Disciplina disciplina) {
            if (curso.Disciplinas.Any(x => x.Codigo == disciplina.Codigo))
                throw new ArgumentException("Essa disciplina já está vinculada a esse curso");

            curso.Disciplinas.Add(disciplina);
        }

        public void ConsultarCursos() {

            foreach (var curso in Cursos) {

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
