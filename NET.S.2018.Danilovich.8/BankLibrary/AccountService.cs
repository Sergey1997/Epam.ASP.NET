﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: BankLibrary
//
// summary:	
// add bool for block and unblock accounts
// email
// abstract class account:
//      bool is
//      номер счёта
//      Клиент инфо
//      тип клиента
//      balance decimal
//      bonuses
//      depost
//      withdraw
//      close
//      
// Template Method
//      репозиторий получает сохраняет удаляет create read update delete
//      GetbyId()
//      
// AccountService принимает ключ к Account в "репозитории". 
//      getAccount();
// интерфейс IRepository
// 
// FakeRepsitory: Обёртка листа
// пао бохари
// декоратор и адаптер
// 
//      
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace BankLibrary
{
    public sealed class AccountService
    {
        #region Fields
        /// <summary>  The list of accounts in bank </summary>
        /// <value> The accounts. </value>
        public List<Account> Accounts { get; set; } = null;
        #endregion

        #region Methods

        /// <summary>   Opens an account. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <param name="account">  The account. </param>
        public void OpenAccount(Account account)
        {
            if (Accounts == null)
            {
                Accounts = new List<Account>
                {
                    account
                };
            }
            else
            {
                if (Accounts.Contains(account) == false)
                {
                    Accounts.Add(account);
                }
                else
                {
                    throw new ArgumentException($"{(account)} already exist");
                }
            }

            if (account == null)
            {
                throw new ArgumentException($"{(nameof(account))} is null");
            }
        }
        
        /// <summary>   Closes an account from the list. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="NullReferenceException">   Thrown when a value was unexpectedly null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="account">  The account. </param>
        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{(nameof(account))} cant be a null");
            }

            if (Accounts == null)
            {
                throw new NullReferenceException($"{(Accounts)} cant be a null");
            }

            if (Accounts.Contains(account) == true)
            {
                Accounts.Remove(account);
            }
            else
            {
                throw new ArgumentException($"{(nameof(account))} doesnt find in list");
            }
        }
        #endregion
    }
}
