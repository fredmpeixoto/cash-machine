using CashMachine.Domain.Entitys;
using CashMachine.Domain.Interfaces;
using CashMachine.Domain.Interfaces.Repository;
using CashMachine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Domain.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;

        }

        public UserVM Adicionar(UserVM entity)
        {
            try
            {
                var existe = _userRepository.ObterPorEmail(entity.Email);
                if (existe == null)
                {
                    var newUser = ConvertToDomain(new User(), entity);
                    return new UserVM(_userRepository.Adicionar(newUser));
                }else
                {
                    throw new Exception("Usuario já existe");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserVM Atualizar(string id, UserVM entity)
        {
            try
            {
                var userById = _userRepository.ObterPorId(id);
                return new UserVM(_userRepository.Atualizar(ConvertToDomain(userById, entity)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserVM Login(string email, string password)
        {
            try
            {
                return new UserVM(_userRepository.Logar(email, password));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public UserVM ObterPorId(string id)
        {
            try
            {
                return new UserVM(_userRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<UserVM> ObterTodos()
        {
            try
            {
                return _userRepository.GetAll().Select(s => new UserVM(s, GetAccountByUser(s.Id.ToString())));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remover(string id)
        {
            try
            {
                return _userRepository.Remover(_userRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private double GetAccountByUser(string id)
        {
            try
            {
                return (_accountRepository.GetByUser(id) != null ? _accountRepository.GetByUser(id).Balance : 0.0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private User ConvertToDomain(User user, UserVM entity)
        {
            user.Cpf = entity.Cpf;
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
            return user;
        }
    }
}
