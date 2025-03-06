using Dream_Properties.Models;

namespace Dream_Properties.Repository
{
    public interface IContactMessageRepository
    {
        Task SaveContactMessages(ContactMessage contactMessage);
    }
}
