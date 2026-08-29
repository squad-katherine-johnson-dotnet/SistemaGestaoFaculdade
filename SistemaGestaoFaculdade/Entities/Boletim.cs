namespace SistemaGestaoFaculdade.Entities
{
    public class Boletim
    {
        public List<Nota> Notas { get; private set; }

        public Boletim()
        {
            Notas = new List<Nota>();
        }

        public void AdicionarNota(Nota nota)
        {
            if (nota is null)
                throw new ArgumentNullException(
                    nameof(nota),
                    "A nota deve ser informada."
                );

            if (Notas.Any(x =>
                x.Disciplina.Codigo == nota.Disciplina.Codigo))
            {
                throw new ArgumentException(
                    "Já existe uma nota lançada para essa disciplina."
                );
            }

            Notas.Add(nota);
        }

        public Nota? BuscarNotaPorDisciplina(string codigoDisciplina)
        {
            if (string.IsNullOrWhiteSpace(codigoDisciplina))
            {
                throw new ArgumentException(
                    "O código da disciplina deve ser informado."
                );
            }

            return Notas.FirstOrDefault(x =>
                x.Disciplina.Codigo.Equals(
                    codigoDisciplina,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }
    }
}