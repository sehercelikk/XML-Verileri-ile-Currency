using OrnekProje.Classes;
using OrnekProje.Model;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrnekProje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Sale sale = new Sale();
            SaleOperation operation = new SaleOperation();
            CurrencyDbEntities db = new CurrencyDbEntities();
            void DovizVerileri()
            {
                string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);
                string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
                string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                string euroAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
                string euroSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
                Console.WriteLine("Dolar Alış Fiyatı:" + dolarAlis);
                Console.WriteLine("Dolar Satış Fiyatı:" + dolarSatis);
                Console.WriteLine("Euro Alış Fiyatı:" + euroAlis);
                Console.WriteLine("Euro Satış Fiyatı:" + euroSatis);
            }

            void CurrencyList()
            {
                Console.WriteLine();
                Console.WriteLine("Döviz Listesi");
                var values = db.Currency.ToList();
                foreach (var value in values)
                {
                    Console.WriteLine(value.Id + " " + value.CurrencyName + " " + value.CurrencySymbol);
                }
            }

            void CurrentCurrency()
            {
                Console.WriteLine();
                Console.WriteLine("Güncel Kur Listesi");
                var values = db.CurrencyValue.ToList();
                foreach (var value in values)
                {
                    Console.WriteLine("Döviz " + value.Currency.CurrencyName + " Alış: " + value.CurrencyBuying + " Satış: " + value.CurrencySelling);
                }
            }

            void GetCurrencyClass()
            {
                GetCurrency currency = new GetCurrency();
                currency.SaveCurrencyDolar();
                currency.SaveCurrencyEuro();
                currency.SaveCurrencyPound();
            }

            Console.WriteLine("Döviz büromuza Hoş Geldiniz");
            Console.WriteLine();
            Console.WriteLine("Mevcut Kullanıcı : Admin" + "       Tarih: " + DateTime.Now.ToLongDateString());
            Console.WriteLine();
            Console.WriteLine("Yapmak istediğiniz işlemi seçin");
            Console.WriteLine();
            Console.WriteLine("1 - Döviz Listesi");
            Console.WriteLine("2 - Güncel Kurlar");
            Console.WriteLine("3 - Satış Yap");
            Console.WriteLine("4 - Müşterilere Yapılan Satış Hareketleri");
            Console.WriteLine("5 - Müşterilerden Alınan Satış Hareketleri");
            Console.WriteLine("6 - Kurları Veri Tabanına Kaydet");
            Console.WriteLine("7 - Yardım");
            Console.WriteLine("8 - Çıkış Yap");
            Console.WriteLine();
            Console.WriteLine("İşlem Numarası:");

            string choose;
            choose = Console.ReadLine();
            if (choose == "1" || choose == "01")
            {
                CurrencyList();
            }
            if (choose == "2" || choose == "02")
            {
                CurrentCurrency();
            }
            if (choose == "3" || choose == "03")
            {
                Console.WriteLine();
                Console.Write("Müşteri Adı:");
                string customerName= Console.ReadLine();
                Console.Write("Müşteri Soyadı:");
                string customerSurname = Console.ReadLine();
                Console.Write("Döviz Kodu:");
                int currencyCode =int.Parse(Console.ReadLine());
                Console.Write("İşlem Türü:");
                string operationType = Console.ReadLine();
                Console.Write("Güncel Kur Değeri:");
                decimal currentValue =decimal.Parse(Console.ReadLine());
                Console.Write("Alınacak Tutar:");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Toplam Ücret:");
                decimal totalAmount = decimal.Parse(Console.ReadLine());
                sale.MakeSale(customerName,customerSurname,currencyCode,operationType,currentValue,amount,totalAmount);
            }

            if (choose == "4" || choose == "04")
            {
                operation.CustomerSaleOperationAlis();

            }
            if (choose == "5" || choose == "05")
            {
                operation.CustomerSaleOperationSatis();

            }

            if (choose == "6" || choose == "06")
            {
                GetCurrencyClass();
                Console.WriteLine("Dövüzler başarıyla veri tabanına kaydedildi");
            }
            if (choose == "7" || choose == "07")
            {
                Console.WriteLine("Tüm sorularınız için mail@mail.com adresinden bize ulaşın");
            }
            if (choose == "8" || choose == "08")
            {
                Environment.Exit(1);
            }


            Console.ReadLine();
        }
    }
}
