using APIsprint.Data;
using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(p => p.person_id == id);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            var cpfExists = await _context.Persons
                .AnyAsync(p => p.cpf == person.cpf);

            if (cpfExists)
                throw new Exception("CPF já cadastrado");

            _context.Persons.Add(person);

            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<bool> UpdateAsync(int id, Person person)
        {
            var existingPerson = await _context.Persons
                .FirstOrDefaultAsync(p => p.person_id == id);

            if (existingPerson == null)
                return false;

            existingPerson.person_name = person.person_name;
            existingPerson.person_surname = person.person_surname;
            existingPerson.age = person.age;
            existingPerson.occupation = person.occupation;
            existingPerson.monthly_income = person.monthly_income;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(p => p.person_id == id);

            if (person == null)
                return false;

            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}