using System;
using System.ComponentModel.DataAnnotations;

namespace DanskeBankREST.Models
{
    public class CreditApplication
    {
        public decimal AppliedAmount { get; set; }
        public uint Term { get; set; }
        public decimal PrevAmount { get; set; }
        public decimal totalAmount => AppliedAmount + PrevAmount;
    }
}
