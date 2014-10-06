using System;

namespace Domain.Models.ViewModels
{
    public class RecieptDetailsVm:FixtureVm
    {
        public int RecieptId { get; set; }
        public string OptionName { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public Double BetMoney { get; set; }
        public Double SetOdd { get; set; }
        public DateTime Stime { get; set; }
        public string UserId { get; set; }
        public DateTime BetDate { get; set; }
        public string FT { get; set; }
        public string HT { get; set; }
        public double WinAmount { get; set; }
    }
}