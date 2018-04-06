using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentExampleWS.Models.Payment
{
    public class PaymentRequest
    {
        public PaymentRequest(string Contract, double Amount, string ApiKey)
        {
            this.Contract = Contract;
            this.Amount = Amount;
            this.ApiKey = ApiKey;
        }
        public string Contract { get; set; } //Número del contrato a pagar
        public double Amount { get; set; } //Monto a pagar
        public string ApiKey { get; set; } //Llave de seguridad para acceder al App Service. Para sabe cual es su ApiKey debe iniciar sesión como empresa en www.Xaldo.com e ir al apartado de "Empresa" después en la parte "WebService" y "Api Key"
    }
}