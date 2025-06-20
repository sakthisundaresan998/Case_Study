using Microsoft.AspNetCore.Mvc;
using ContactsDirectory.Models;

namespace ContactsDirectory.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contactInfo.ContactId = contacts.Count == 0
                                     ? 1
                                     : contacts.Max(c => c.ContactId) + 1;

            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}