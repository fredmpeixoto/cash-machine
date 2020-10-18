using System;

namespace CashMachine.Domain.Entitys
{
    public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid();
            DataRemove = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
        public DateTime DataRemove { get; set; }
        public User User { get; set; }

    }
}
