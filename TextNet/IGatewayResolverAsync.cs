using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    public interface IGatewayResolverAsync
    {
        Task<string> Resolve(string phone);
    }
}
