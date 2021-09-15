using System;
using System.ComponentModel.DataAnnotations;

namespace DanskeBankREST.Models
{
    public class CreditApplication
    {
        [Required]
        public decimal? AppliedAmount { get; set; }
        [Required,Range(1,600)]
        public uint Term { get; set; }
        [Required]
        public decimal? PrevAmount { get; set; }
        public decimal? totalAmount => AppliedAmount + PrevAmount;
    }
}
