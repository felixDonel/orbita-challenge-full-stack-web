using Microsoft.EntityFrameworkCore;
using Orbita.Model.Interfaces;
using Orbita.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbita.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OrbitaDbContext _context;

        public StudentRepository(OrbitaDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
