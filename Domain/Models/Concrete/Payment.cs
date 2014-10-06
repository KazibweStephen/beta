using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Concrete
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string UserId { get; set; }
        public int AccountId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPaid { get; set; }
        public int MethodId { get; set; }
        public int PeriodId { get; set; }
        public string RecievedBy { get; set; }
        public string TransType { get; set; }
        public string VerificationCode { get; set; }
    
    }
}
