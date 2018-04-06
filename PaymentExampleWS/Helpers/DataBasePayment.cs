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
        PaymentRequest paymentRequest;
        public DataBasePayment(PaymentRequest paymentRequest)
        {
            this.paymentRequest = paymentRequest;
        }

        public async Task<PaymentModel> pay()
        {
            PaymentModel paymentResponse = new PaymentModel();
            var paymentDetail = new PaymentModel();/*Aquí se remplaza -new PaymentModel();- por el update a la base de datos correspondiente por ejemplo
            var paymentDetail = await PaymentDetail.updateAccountByContractNumber(paymentRequest.Contract, paymentRequest.Amount);
            dicho update deberá retornar a paymentDetail con un objeto que contendrá Status(true si fue exitoso o false si no fue así), Reference(el numero referencia de la operación)
            IdError se dejará en 0 ya que eso lo manejará el webservice por su cuenta para verificar el estado de la operación*/
            if (paymentDetail != null)
            {
                paymentResponse.Status = true;
                paymentResponse.Reference = "1";
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