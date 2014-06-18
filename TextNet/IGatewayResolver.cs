using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    public interface IGatewayResolver
    {
        string Resolve(string phone);
    }
}
