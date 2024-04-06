using BlazorApp.Shared.Models;
namespace BlazorApp.Server.Interfaces
{
    public interface IContact
    {
        public List<Contact> GetContactDetails();
        public void AddContact(Contact contact);
        public void UpdateContactDetails(Contact contact);
        public Contact GetContactData(int id);
        public void DeleteContact(int id);
    }
}