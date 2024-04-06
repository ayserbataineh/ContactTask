using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace BlazorApp.Server.Services
{
    public class ContactManager : IContact
    {
        readonly DatabaseContext _dbContext = new();
        public ContactManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<Contact> GetContactDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddContact(Contact contact)
        {
            try
            {
                _dbContext.Users.Add(contact);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateContactDetails(Contact contact)
        {
            try
            {
                _dbContext.Entry(contact).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public Contact GetContactData(int id)
        {
            try
            {
                Contact? contact = _dbContext.Users.Find(id);
                if (contact != null)
                {
                    return contact;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteContact(int id)
        {
            try
            {
                Contact? contact = _dbContext.Users.Find(id);
                if (contact != null)
                {
                    _dbContext.Users.Remove(contact);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}