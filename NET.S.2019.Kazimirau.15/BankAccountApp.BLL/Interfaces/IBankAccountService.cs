using BankAccountApp.BLL.DataTransferObjects;
using System.Collections.Generic;

namespace BankAccountApp.BLL.Interfaces
{
    public interface IBankAccountService
    {
        void CreateNew(BankAccountDTO bankAccountDTO);

        void Deposit(int id, decimal amount);

        void Withdraw(int id, decimal amount);

        void Close(int id);

        IEnumerable<BankAccountDTO> ShowAll();

        BankAccountDTO Show(int id);
    }
}
