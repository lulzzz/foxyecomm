using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Services.Common;

namespace FoxyEcomm.Services.Inventory
{
    public class InventoryService : Microservice
    {
        public InventoryService(ICommandConsumer commandConsumer, IEventConsumer eventConsumer)
            :base(commandConsumer, eventConsumer)
        {

        }
        
    }
}
