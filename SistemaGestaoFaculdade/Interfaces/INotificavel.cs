namespace SistemaGestaoFaculdade.Interfaces;
//Contrato de notificação | Uma interface funciona como um contrato
public interface INotificavel
{
    //Obriga quem assinar esta interface a saber receber uma mensagem
    void ReceberNotificacao(string mensagem);
}
