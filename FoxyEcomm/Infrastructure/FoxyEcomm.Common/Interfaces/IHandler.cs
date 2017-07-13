using System.Threading.Tasks;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IHandler<in TMessage>
    {
        Task HandleAsync(TMessage message);
    }
}
