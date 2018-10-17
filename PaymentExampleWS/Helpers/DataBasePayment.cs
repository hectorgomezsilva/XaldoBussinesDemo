using PaymentExampleWS.Models;
using PaymentExampleWS.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaymentExampleWS.Helpers
{
    public class DataBasePayment
    {
        /*
        Errores:
        0-Success
        1-Error
        2-Contrato no encontrado
        3-No hay deuda
        4-Fallo en la conexión
        5-Contrato vencido
        6-Contrato no valido
        7-No autorizado
        */
        PaymentRequest paymentRequest;
        public DataBasePayment(PaymentRequest paymentRequest)
        {
            this.paymentRequest = paymentRequest;
        }

        public async Task<PaymentModel> pay()
        {
            PaymentModel paymentResponse = new PaymentModel();
            var paymentDetail = new PaymentModel();
            //TO DO asignar a paymentDetail los valores que se regresaran, Status(true si fue exitoso o false si no fue así), Reference(el numero referencia de la operación)
            if (paymentDetail != null)
            {
                paymentResponse.Status = paymentDetail.Status;
                paymentResponse.Reference = paymentDetail.Reference;
                paymentResponse.IdError = (int)ErrorEnum.ErrorResponce.Success;
            }
            else
            {
                paymentResponse.Status = false;
                paymentResponse.Reference = "0";
                paymentResponse.IdError = (int)ErrorEnum.ErrorResponce.Error;
            }
            return paymentResponse;
        }
    }
}