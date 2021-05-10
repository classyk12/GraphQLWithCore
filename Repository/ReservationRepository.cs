using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using graphql.models;
using Microsoft.EntityFrameworkCore;

namespace graphql.repository
{

    public interface IReservationRepository
    {
        Task<List<T>> GetAll<T>();
        Task<IEnumerable<Reservation>> GetAll();
    }

    public class ReservationRepository : IReservationRepository
    {
        private readonly MyHotelDbContext _myHotelDbContext;
        private readonly IMapper _mapper;

        public ReservationRepository(MyHotelDbContext myHotelDbContext,  IMapper mapper)
        {
            _myHotelDbContext = myHotelDbContext;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAll<T>()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ProjectTo<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }
    }
}