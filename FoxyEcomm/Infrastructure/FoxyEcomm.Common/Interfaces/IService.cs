using System;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IService : IDisposable
    {
        void Start(object[] args);
    }
}
