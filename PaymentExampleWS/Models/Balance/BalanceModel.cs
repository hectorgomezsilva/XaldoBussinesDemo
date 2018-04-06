using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentExampleWS.Models.Balance
{
    public class BalanceModel
    {
        public BalanceModel() { }
        public string Contract { get; set; } //Número del contrato a pagar
        public double Amount { get; set; }   //Monto a pagar para el contrato solicitado
        public string Concept { get; set; }  //Concepto a pagar al usuario
        public string DueDate { get; set; }  //Fecha de vencimiento del contrato solicitado
        public int IdError { get; set; }     //Código que identifica el estado de la petición en base a los códigos de error.
        public bool Status { get; set; }     //Estado de la petición a realizar
    }
}