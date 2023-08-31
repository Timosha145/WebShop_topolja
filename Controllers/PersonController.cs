using Microsoft.AspNetCore.Mvc;
using WebShop_topolja.Data.ApplicationDbContext;
using WebShop_topolja.Models;

namespace WebShop_topolja.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetPersons()
        {
            var persons = _context.Persons.ToList();
            return persons;
        }

        [HttpPost]
        public List<Person> PostPerson([FromBody] Person Person)
        {
            _context.Persons.Add(Person);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        [HttpDelete("/deletePerson/{id}")]
        public IActionResult DeletePerson2(int id)
        {
            var Person = _context.Persons.Find(id);

            if (Person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(Person);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var Person = _context.Persons.Find(id);

            if (Person == null)
            {
                return NotFound();
            }

            return Person;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> PutProduct(int id, [FromBody] Person updatedPerson)
        {
            var Person = _context.Persons.Find(id);

            if (Person == null)
            {
                return NotFound();
            }

            Person.PersonCode = updatedPerson.PersonCode;
            Person.FirstName = updatedPerson.FirstName;
            Person.LastName = updatedPerson.LastName;
            Person.Address = updatedPerson.Address;
            Person.Phone = updatedPerson.Phone;
            Person.Password = updatedPerson.Password;
            Person.Admin = updatedPerson.Admin;

            _context.Persons.Update(Person);
            _context.SaveChanges();

            return Ok(_context.Persons);
        }
    }
}
