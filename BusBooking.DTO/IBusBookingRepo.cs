using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public interface IBusBookingRepo
    {
       Task<int> deleteBooking(int id);
       Task<int> AddReservation(List<ReservationdetailsModel> reservationdetails);
       Task<List<int>> GetAllReservedSeatsByBusId(ReservationdetailsModel reservationdetailsModel);
    }
}
