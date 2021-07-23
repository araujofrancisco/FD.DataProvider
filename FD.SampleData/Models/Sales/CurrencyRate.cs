using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{
    public partial class CurrencyRate
    {
        public CurrencyRate()
        {
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int CurrencyRateID { get; set; }
        public System.DateTime CurrencyRateDate { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal AverageRate { get; set; }
        public decimal EndOfDayRate { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Currency Currency1 { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }

}
