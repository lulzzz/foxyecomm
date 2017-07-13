using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Common.Models
{
    public abstract class Service : DisposableObject, IService
    {
        public abstract void Start(object[] args);
    }
}
