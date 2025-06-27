using OrnekProje.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrnekProje.Classes
{
    public class GetCurrency
    {
        CurrencyDbEntities db = new CurrencyDbEntities();

        public void SaveCurrencyDolar()
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarAlis = dolarAlis.Replace(".", ",");
            string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolarSatis = dolarSatis.Replace(".", ",");
            CurrencyValue currency = new CurrencyValue();
            currency.CurrencyId = 1;
            currency.CurrencyBuying = decimal.Parse(dolarAlis);
            currency.CurrencySelling = decimal.Parse(dolarSatis);
            currency.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.CurrencyValue.Add(currency);
            db.SaveChanges();


        }

        public void SaveCurrencyEuro()
        {

            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string euroAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroAlis = euroAlis.Replace(".", ",");
            string euroSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euroSatis = euroSatis.Replace(".", ",");
            CurrencyValue currency = new CurrencyValue();
            currency.CurrencyId = 2;
            currency.CurrencyBuying = decimal.Parse(euroAlis);
            currency.CurrencySelling = decimal.Parse(euroSatis);
            currency.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.CurrencyValue.Add(currency);
            db.SaveChanges();
        }
        public void SaveCurrencyPound()
        {

            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string poundAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            poundAlis = poundAlis.Replace(".", ",");
            string poundSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            poundSatis = poundSatis.Replace(".", ",");
            CurrencyValue currency = new CurrencyValue();
            currency.CurrencyId = 4;
            currency.CurrencyBuying = decimal.Parse(poundAlis);
            currency.CurrencySelling = decimal.Parse(poundSatis);
            currency.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.CurrencyValue.Add(currency);
            db.SaveChanges();
        }
    }
}
