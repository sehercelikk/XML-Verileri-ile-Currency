using OrnekProje.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekProje.Classes
{
    public class Sale
    {
        CurrencyDbEntities db = new CurrencyDbEntities();

        public void MakeSale(string customerName, string customerSurname, int currencyCode, string operationType, decimal currentValue, decimal amount, decimal totalPrice)
        {
            Operation operation = new Operation();
            operation.CustomerName = customerName;
            operation.CustomerSurname = customerSurname;
            operation.CurrencyId = currencyCode;
            operation.OperationType = operationType;
            operation.CurrentValue = currentValue;
            operation.Amount = amount;
            operation.TotalPrice = totalPrice;
            operation.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Operation.Add(operation);
            db.SaveChanges();
            Console.WriteLine("Satış işlemi başarıyla gerçekleşti");


        }
    }
}
