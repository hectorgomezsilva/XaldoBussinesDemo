using Newtonsoft.Json;
using PaymentExampleWS.Helpers;
using PaymentExampleWS.Models;
using PaymentExampleWS.Models.Balance;
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
    public class BalanceController : ApiController
    {

        [HttpPost]
        public async Task<JsonResult<BalanceModel>> getBalance(BalanceRequest balanceRequest)
        {
            BalanceModel balanceModel = new BalanceModel();
            /* Para sabe cual es su ApiKey debe iniciar sesion como empresa en www.Xaldo.com e ir al apartado de "Empresa" despúes en la parte "WebService" y "Api Key" */
            if (balanceRequest.ApiKey == "Qpx4AQlFWoCe4wrESGxYycyb3j1EwO")
            {
                if (balanceRequest.Contract != "" && balanceRequest.Contract != null)
                {
                    DataBaseDebt debtSearcher = new DataBaseDebt(balanceRequest);
                    try
                    {
                        balanceModel = await debtSearcher.search();
                    }
                    catch (Exception e)
                    {
                        balanceModel.Contract = balanceRequest.Contract;
                        balanceModel.Amount = 0.0;
                        balanceModel.Concept = "not_found";
                        balanceModel.DueDate = "01/01/1900";
                        balanceModel.IdError = 1;
                        balanceModel.Status = false;
                    }
                }
                else
                {
                    balanceModel.Contract = balanceRequest.Contract;
                    balanceModel.Amount = 0.0;
                    balanceModel.Concept = "not_found";
                    balanceModel.DueDate = "01/01/1900";
                    balanceModel.IdError = (int)ErrorEnum.ErrorResponce.Invalid_Contract;
                    balanceModel.Status = false;
                }
            }
            else
            {
                balanceModel.Contract = balanceRequest.Contract;
                balanceModel.Amount = 0.0;
                balanceModel.Concept = "not_found";
                balanceModel.DueDate = "01/01/1900";
                balanceModel.IdError = (int)ErrorEnum.ErrorResponce.Unauthorized;
                balanceModel.Status = false;
            }
           
            return Json(balanceModel);
        }
    }
}
