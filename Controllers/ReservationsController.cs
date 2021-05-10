
using System.Collections.Generic;
using System.Threading.Tasks;
using graphql.models;
using graphql.repository;
using graphql.viewmodels;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly IReservationRepository _reservationRepository;


        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("[action]")]
        public async Task<List<ReservationModel>> List()
        {
        return await _reservationRepository.GetAll<ReservationModel>();
        }
        
    }
