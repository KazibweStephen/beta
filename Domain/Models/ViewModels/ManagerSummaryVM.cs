using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ViewModels
{
    public class ManagerSummaryVM
    {
        public string TellerName { get; set; }
        public decimal TellerBalance { get; set; }
        public int ReceiptCount { get; set; }
        public decimal  TotalSales { get; set; }
        public decimal CashOut{ get; set; }
    }
}
