using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Take.Blip.Client.Extensions.HelpDesk;
using Takenet.Iris.Messaging.Resources;

namespace Take.Blip.Builder.Variables
{
    public class TicketVariableProvider : UserVariableProviderBase<Ticket>
    {
        private readonly IHelpDeskExtension _helpDeskExtension;

        public TicketVariableProvider(IHelpDeskExtension helpDeskExtension)
            : base(VariableSource.Ticket, ContextExtensions.TICKET_KEY)
        {
            _helpDeskExtension = helpDeskExtension;
        }

        protected override Task<Ticket> GetAsync(Identity userIdentity, CancellationToken cancellationToken) 
            => _helpDeskExtension.GetCustomerActiveTicketAsync(userIdentity, cancellationToken);
    }
}