using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentExampleWS.Models
{
    public class ErrorEnum
    {
        public enum ErrorResponce
        {
            Success = 0,
            Error = 1,
            Contract_Not_Found = 2,
            Without_Debt = 3,
            Failed_Conection = 4,
            Expired_Contract = 5,
            Invalid_Contract = 6,
            Unauthorized = 7
        }
    }
}