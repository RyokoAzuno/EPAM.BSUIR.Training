namespace BankAccountApp.DAL.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
