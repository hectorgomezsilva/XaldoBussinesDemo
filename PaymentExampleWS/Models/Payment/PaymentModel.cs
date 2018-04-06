using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentExampleWS.Models.Payment
{
    public class PaymentModel
    {
        public PaymentModel() { }
        public bool Status { get; set; } //Etado de la petición a realizar
        public string Reference { get; set; } //Número para referenciar el pago
        public int IdError { get; set; } //Codigo que indentifica el estado de la peticion en base a los codigos de error.
    }
}