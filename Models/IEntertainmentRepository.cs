using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_dlbaldwi.Models
{
    public interface IEntertainmentRepository
    {
        IQueryable<Entertainers> Entertainers { get; }
        void UpdateEntertainers(Entertainers entertainer);
        long GetNextId();
        void AddEntertainer(Entertainers entertainer);
        void DeleteEntertainer(Entertainers entertainer);
    }
}
