using System;

namespace Domain.Models.ViewModels
{
    public class SummaryReportVm
    {
        public string BusinessDay { get; set; }
        public Decimal TicketSold { get; set; }
        public int TicketsNumber { get; set; }
        public int TicketsPaid { get; set; }
        public Decimal Sales { get; set; }
        public Decimal Profit { get; set; }
        public Decimal PaidOrders { get; set; }
        public Decimal Canceled { get; set; }
        public int  CanceledNumber { get; set; }
        public Decimal Deposits { get; set; }
        public Decimal OutStanding()
        {
            return (TotalWins - PaidOrders);
        }
        public Decimal TotalWins{ get; set; }

    }
}