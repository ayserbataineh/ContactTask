using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _IContact;
        public ContactController(IContact iContact)
        {
            _IContact = iContact;
        }
        [HttpGet]
        public async Task<List<Contact>> Get()
        {
            return await Task.FromResult(_IContact.GetContactDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact contact = _IContact.GetContactData(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Contact contact)
        {
            _IContact.AddContact(contact);
        }
        [HttpPut]
        public void Put(Contact contact)
        {
            _IContact.UpdateContactDetails(contact);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IContact.DeleteContact(id);
            return Ok();
        }
    }
}