namespace SistemaGestaoFaculdade.Entities
{
    public class Nota
    {
        public Disciplina Disciplina { get; private set; }
        public double Valor { get; private set; }

        public Nota(Disciplina disciplina, double valor)
        {
            Disciplina = disciplina;
            Valor = valor;
        }
    }
}