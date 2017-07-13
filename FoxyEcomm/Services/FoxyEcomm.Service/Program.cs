using log4net.Config;

namespace FoxyEcomm.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            using (var service = new FoxyEcommService()) service.Start(args);
        }
    }
}
