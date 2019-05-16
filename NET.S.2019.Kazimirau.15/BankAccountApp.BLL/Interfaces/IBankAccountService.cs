using System.Collections.Generic;
using BankAccountApp.BLL.DataTransferObjects;

namespace BankAccountApp.BLL.Interfaces
{
    public interface IBankAccountService
    {
        void CreateNew(BankAccountDTO bankAccountDTO);

        void Deposit(int id, decimal amount);

        void Withdraw(int id, decimal amount);

        void Close(int id);

        void Open(int id);

        IEnumerable<BankAccountDTO> GetAll();

        BankAccountDTO Get(int id);
    }
}
