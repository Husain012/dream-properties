
using Dream_Properties.Context;
using Dream_Properties.Models;

namespace Dream_Properties.Repository
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly AppDBContext appDBContext;

        public ContactMessageRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task SaveContactMessages(ContactMessage contactMessage)
        {
           await this.appDBContext.SaveContactMessageAsync(contactMessage.Name, contactMessage.Email, contactMessage.Subject, contactMessage.Message);
        }
    }
} 
 