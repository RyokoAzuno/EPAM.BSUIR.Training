using BankAccountApp.BLL.Interfaces;
using BankAccountApp.BLL.Services;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using BankAccountApp.DAL.Repositories;
using BankAccountApp.DAL.Storages;
using Ninject.Modules;
using Ninject.Syntax;

namespace BankAccountApp.BLL.Dependencies
{
    /// <summary>
    /// Class resolver
    /// </summary>
    public class NinjectServiceModule : NinjectModule
    {
        private string _storageType;

        public NinjectServiceModule(string storageType)
        {
            _storageType = storageType;
        }

        public override void Load()
        {
            IBindingToSyntax<IStorage<BankAccount>> bind = Bind<IStorage<BankAccount>>();
            switch (_storageType.ToLower())
            {
                case "json":
                    {
                        bind.To<JsonStorage>();
                        break;
                    }

                case "xml":
                    {
                        bind.To<XmlStorage>();
                        break;
                    }

                default:
                    {
                        bind.To<BinaryStorage>();
                        break;
                    }
            }
            Bind<IUnitOfWork>().To<UnitOfWork>()
                               .WithConstructorArgument(bind);
            Bind<IBankAccountService>().To<BankAccountService>();
        }
    }
}
