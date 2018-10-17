using PaymentExampleWS.Models;
using PaymentExampleWS.Models.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaymentExampleWS.Helpers
{
    public class DataBaseDebt
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
        BalanceRequest BalanceRequest;
        public DataBaseDebt(BalanceRequest BalanceRequest)
        {
            this.BalanceRequest = BalanceRequest;
        }
        public async Task<BalanceModel> search()
        {
            BalanceModel balanceToReturn = new BalanceModel();
            BalanceModel balanceDetail = new BalanceModel();
            //TO DO asignar a balanceDetail los valores que se regresaran, Amount(monto de deuda), Concept(concepto o servicio), DueDate(fecha de vencimiento)
            balanceToReturn.Contract = BalanceRequest.Contract;
            if (balanceDetail != null)
            {
                balanceToReturn.Amount = balanceDetail.Amount;
                balanceToReturn.Concept = balanceDetail.Concept;
                balanceToReturn.DueDate = balanceDetail.DueDate;
                balanceToReturn.IdError = (int)ErrorEnum.ErrorResponce.Success;
                balanceToReturn.Status = true;
            }
            else
            {
                balanceToReturn.Amount = 0.0;
                balanceToReturn.Concept = "";
                balanceToReturn.DueDate = "";
                balanceToReturn.IdError = (int)ErrorEnum.ErrorResponce.Contract_Not_Found;
                balanceToReturn.Status = false;
            }
            return balanceToReturn;
        }
    }
}