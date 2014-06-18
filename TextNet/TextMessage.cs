using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    public class TextMessage
    {
        ISmtpProvider provider;
        IGatewayResolver resolver;
        IGatewayResolverAsync resolverAsync;

        static TextMessage()
        {
            SmtpProvider = new NetSmtpProvider();
        }

        public TextMessage(string phone, string message, string carrier)
            : this(DefaultSource, phone, message, carrier)
        {
        }

        public TextMessage(string source, string phone, string message, string carrier)
            : this(source, phone, message, new ConfigGatewayResolver(carrier), SmtpProvider)
        {
        }

        public TextMessage(string source, string phone, string message, IGatewayResolverAsync resolverAsync, ISmtpProvider provider)
        {
            Phone = phone;
            Message = message;
            this.provider = provider;
            this.resolverAsync = resolverAsync;

            CheckState();
        }

        public TextMessage(string source, string phone, string message, IGatewayResolver resolver, ISmtpProvider provider)
        {
            Message = message;
            Phone = phone;
            Source = source;
            this.provider = provider;
            this.resolver = resolver;

            CheckState();
        }

        public static string DefaultSource { get; set; }
        public static ISmtpProvider SmtpProvider { get; set; }

        public string Message { get; private set; }
        public string Phone { get; private set; }
        public string Source { get; private set; }

        void CheckState()
        {
            if (string.IsNullOrWhiteSpace(Message))
                throw new ArgumentNullException("message");
            if (string.IsNullOrWhiteSpace(Phone))
                throw new ArgumentNullException("phone");
            if (string.IsNullOrWhiteSpace(Source))
                throw new ArgumentNullException("source");
            if (provider == null)
                throw new ArgumentNullException("provider");
            if (resolver == null)
                throw new ArgumentNullException("resolver");
        }

        async public Task SendAsync()
        {
            string gateway;
            if (resolverAsync != null)
                gateway = await resolverAsync.Resolve(Phone);
            else if (resolver != null)
                gateway = resolver.Resolve(Phone);
            else
                throw new InvalidOperationException("Null IGatewayResolver or IGatewayResolverAsync");

            await provider.Send(Source, gateway, Message);
        }
    }
}
