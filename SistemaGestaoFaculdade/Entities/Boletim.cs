namespace SistemaGestaoFaculdade.Entities
{
    public class Boletim
    {
        public List<Nota> Notas { get; private set; }

        public Boletim()
        {
            Notas = new List<Nota>();
        }
    }
}