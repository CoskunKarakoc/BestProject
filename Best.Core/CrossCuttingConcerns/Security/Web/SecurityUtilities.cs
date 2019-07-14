using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Best.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Email = SetEmail(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                Name = SetName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthencidated(),
                Roles = SetRoles(ticket)
            };
            return identity;
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private bool SetIsAuthencidated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
