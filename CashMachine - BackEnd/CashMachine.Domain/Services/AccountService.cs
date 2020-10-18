using CashMachine.Domain.Entitys;
using CashMachine.Domain.Interfaces.Repository;
using CashMachine.Domain.Interfaces.Services;
using CashMachine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountVM Adicionar(AccountVM entity)
        {
            try
            {
                var account = _accountRepository.GetByUser(entity.UserId.ToString());
                if (account == null)
                    return new AccountVM(_accountRepository.Adicionar(ConvertToDomain(new Account(), entity)));
                else
                    return AtualizarById(account.Id.ToString(), entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccountVM AtualizarById(string id, AccountVM entity)
        {
            try
            {
                var account = _accountRepository.GetById(id);
                account.Balance = entity.Balance;
                return new AccountVM(_accountRepository.Atualizar(account));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AccountVM AtualizarByIdUser(string idUser, AccountVM entity)
        {
            try
            {
                var account = _accountRepository.GetByUser(idUser);
                account.Balance = entity.Balance;
                account.DataRemove = DateTime.Now;
                return new AccountVM(_accountRepository.Atualizar(account));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AccountVM ObterPorIdUser(string id)
        {
            try
            {
                var account = _accountRepository.GetByUser(id);
                return account != null ? new AccountVM(account) : null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AccountVM RemoveMoney(string idUser, double removeValue)
        {
            try
            {
                var listMoneys = new List<double>();
                int[] moneys = GetMoneyList();
                int totalRemovalValue = 0;
                var accountByUser = ObterPorIdUser(idUser);
                if (accountByUser.Balance < removeValue)
                    throw new Exception("Valor superior ao saldo! Saldo não pode ser negativo");


                foreach (int money in moneys)
                {
                    var nota = (int)removeValue / money;
                    for (int i = 0; i < nota; i++)
                    {
                        removeValue -= money;
                        totalRemovalValue += money;
                        accountByUser.Moneys.Add(money);
                    }
                }
                accountByUser.Balance -= totalRemovalValue;
                accountByUser.Balance = AtualizarByIdUser(accountByUser.UserId, accountByUser).Balance;

                return accountByUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private static int[] GetMoneyList()
        {
            var list = new int[] { 100, 50, 20, 10 };
            return list;
        }


        private Account ConvertToDomain(Account account, AccountVM entity)
        {
            account.Balance = entity.Balance;
            account.UserId = Guid.Parse(entity.UserId);
            return account;
        }


    }
}
