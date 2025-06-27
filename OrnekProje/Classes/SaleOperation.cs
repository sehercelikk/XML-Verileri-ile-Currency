using OrnekProje.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekProje.Classes
{
    public class SaleOperation
    {
        CurrencyDbEntities db = new CurrencyDbEntities();

        public void CustomerSaleOperationAlis()
        {
            var values = db.Operation.Where(x=>x.OperationType=="Alış").ToList();
            foreach (var value in values)
            {
                Console.WriteLine("Id: "+ value.Id + " Müşteri: " + value.CustomerName + " " + value.CustomerSurname + " Döviz: "+
                    value.Currency.CurrencyName+ " İşlem Türü:" + value.OperationType+ " Kur Birim Tutarı: "+ value.CurrentValue+
                    " Alınan Tutar: "+ value.Amount+ " Toplam Tutar: "+ value.TotalPrice);
            }
        }
        public void CustomerSaleOperationSatis()
        {
            var values = db.Operation.Where(x => x.OperationType == "Satış").ToList();
            foreach (var value in values)
            {
                Console.WriteLine("Id: " + value.Id + " Müşteri: " + value.CustomerName + " " + value.CustomerSurname + " Döviz: " +
                    value.Currency.CurrencyName + " İşlem Türü:" + value.OperationType + " Kur Birim Tutarı: " + value.CurrentValue +
                    " Alınan Tutar: " + value.Amount + " Toplam Tutar: " + value.TotalPrice);
            }
        }
    }
}
