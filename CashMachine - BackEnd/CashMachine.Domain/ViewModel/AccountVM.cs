using CashMachine.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashMachine.Domain.ViewModel
{
    public class AccountVM
    {
        public AccountVM()
        {

        }
        public AccountVM(Account account)
        {
            UserId = account.UserId.ToString();
            Balance = account.Balance;
            Moneys = new List<int>();
        }

        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "Value cannot be negative!")]
        public double Balance { get; set; }
        public List<int> Moneys { get; set; }
    }
}
