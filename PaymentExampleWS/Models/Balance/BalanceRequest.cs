using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentExampleWS.Models.Balance
{
    public class BalanceRequest
    {
        public BalanceRequest(string Contract, string ApiKey)
        {
            this.Contract = Contract;
            this.ApiKey = ApiKey;
        }
        public string Contract { get; set; }
        public string ApiKey { get; set; }
    }
}