using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            if (_context.Persons.Count() == 0)
            {
                _context.Persons.Add(new Person() { Name = "Marko", Age = 32, Gender = Gender.Male });
                _context.Persons.Add(new Person() { Name = "Anni", Age = 21, Gender = Gender.Female });
                _context.Persons.Add(new Person() { Name = "Paju", Age = 29, Gender = Gender.Other });
                _context.Persons.Add(new Person() { Name = "Säde", Age = 45 });
                _context.SaveChanges();
            }
        }

        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _context.Persons;
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Person> Get(int id)
        {
            var p = _context.Persons.Find(id);
            if (p != null)
            {
                return _context.Persons.Find(id);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Person
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post([FromBody] Person p)
        {
            if (p.Name.Length <= 70 && !string.IsNullOrWhiteSpace(p.Name) && p.Age >= 0)
            {
                var person = new Person();
                person.Name = p.Name;
                person.Age = p.Age;
                person.Gender = p.Gender;
                _context.Persons.Add(person);
                _context.SaveChanges();
                return _context.Persons;
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Person/Delete/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Person>> Delete(int id)
        {
            var p = _context.Persons.Find(id);
            if (p != null)
            {
                _context.Persons.Remove(p);
                _context.SaveChanges();
                return _context.Persons;
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
