using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloPOO.DesafioSquad.Models;
//Contrato de notificação | Uma interface funciona como um contrato
public interface INotificavel
{
    //Obriga quem assinar esta interface a saber receber uma mensagem
    void ReceberNotificacao(string mensagem);
}
