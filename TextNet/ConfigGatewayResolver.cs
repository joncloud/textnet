using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    class ConfigGatewayResolver : IGatewayResolver
    {
        static Dictionary<string, string> gateways = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { Carriers.US.AcsWireless, "{0}@paging.acswireless.com" },
            { Carriers.US.Alltel, "{0}@message.alltel.com" },
            { Carriers.US.Att, "{0}@txt.att.net" },
            { Carriers.US.CellularOne, "{0}@mobile.celloneusa.com" },
            { Carriers.US.Qwest, "{0}@qwestmp.com" },
            { Carriers.US.Rogers, "{0}@pcs.rogers.com" },
            { Carriers.US.SprintPcs, "{0}@messaging.sprintpcs.com" },
            { Carriers.US.Telus, "{0}@msg.telus.com" },
            { Carriers.US.TMobile, "{0}@tmomail.net" },
            { Carriers.US.USCellular, "" },
            { Carriers.US.Verizon, "{0}@vtext.com" },
            { Carriers.US.WindMobile, "{0}@txt.windmobile.ca" }
        };

        string gateway;

        static ConfigGatewayResolver()
        {
            var settings = ConfigurationManager.AppSettings;

            foreach (string key in settings.Keys
                                           .Cast<string>()
                                           .Where(k => k.StartsWith("ConfigGatewayResolver.")))
            {
                gateways[key] = settings[key];
            }
        }

        public ConfigGatewayResolver(string carrier)
        {
            if (!gateways.TryGetValue(carrier, out gateway))
                throw new ArgumentException("Invalid Carrier", "carrier");
        }

        public string Resolve(string phone)
        {
            return string.Format(gateway, phone);
        }
    }
}
