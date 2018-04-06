using Newtonsoft.Json;
using PaymentExampleWS.Helpers;
using PaymentExampleWS.Models;
using PaymentExampleWS.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PaymentExampleWS.Controllers
{
    public class PaymentController : ApiController
    {

        [HttpPost]
        public async Task<JsonResult<PaymentModel>> updateAccount(PaymentRequest paymentRequest)
        {
            PaymentModel pModel = new PaymentModel();
            /* Para sabe cual es su ApiKey debe iniciar sesion como empresa en www.Xaldo.com e ir al apartado de "Empresa" despúes en la parte "WebService" y "Api Key" */
            if (paymentRequest.ApiKey == "A123456")
            {
                if (paymentRequest.Contract != "" && paymentRequest.Contract != null)
                {
                    DataBasePayment payer = new DataBasePayment(paymentRequest);
                    try
                    {
                        pModel = await payer.pay();
                    }
                    catch (Exception e)
                    {
                        pModel.Status = false;
                        pModel.Reference = "0";
                        pModel.IdError = (int)ErrorEnum.ErrorResponce.Error;
                    }
                }
                else
                {
                    pModel.Status = false;
                    pModel.Reference = "0";
                    pModel.IdError = (int)ErrorEnum.ErrorResponce.Invalid_Contract;
                }
            }
            else
            {
                pModel.Status = false;
                pModel.Reference = "0";
                pModel.IdError = (int)ErrorEnum.ErrorResponce.Unauthorized;
            }
            return Json(pModel);
        }
    }
}
