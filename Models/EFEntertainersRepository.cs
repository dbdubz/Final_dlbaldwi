using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_dlbaldwi.Models
{
    public class EFEntertainersRepository : IEntertainmentRepository
    {
        private EntertainmentAgencyExampleContext _context { get; set; }
        public EFEntertainersRepository(EntertainmentAgencyExampleContext temp)
        {
            _context = temp;
        }
        public IQueryable<Entertainers> Entertainers => _context.Entertainers;

        public void UpdateEntertainers(Entertainers entertainer)
        {
            Entertainers tochange = _context.Entertainers.Single(e => e.EntertainerId == entertainer.EntertainerId);
            _context.Entry(tochange).CurrentValues.SetValues(entertainer);
            _context.SaveChanges();
        }

        public long GetNextId()
        {
            long id = _context.Entertainers.Max(e => e.EntertainerId) + 1;
            return id;
        }

        public void AddEntertainer(Entertainers entertainer)
        {
            _context.Add(entertainer);
            _context.SaveChanges();
        }

        public void DeleteEntertainer(Entertainers entertainer)
        {
            _context.Remove(entertainer);
            _context.SaveChanges();
        }
    }
}
