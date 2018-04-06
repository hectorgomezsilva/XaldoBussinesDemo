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
            var balanceDetail = new BalanceModel();/*Aquí se reemplaza -new BalanceModel();- por la consulta a la base de datos correspondiente por ejemplo
            var balancedetail = await BalanceDetail.getBalanceByContractNumber(balanceRequest.Contract);
            dicha consulta deberá llenar balanceDetail con un objeto que contendrá Amount(monto de deuda), Concept(concepto o servicio), DueDate(fecha de vencimiento)
            IdError se dejara en 0 y Status como false, ya que eso lo manejara el webservice por su cuenta para verificar el estado de la operación*/
            balanceToReturn.Contract = BalanceRequest.Contract;
            if (balanceDetail != null)
            {
                balanceToReturn.Amount = 5.00;
                balanceToReturn.Concept = "Pago de Servicio";
                balanceToReturn.DueDate = "05/04/2018";
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