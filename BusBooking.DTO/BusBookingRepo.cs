using BusBooking.Entities;
using BusBooking.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public class BusBookingRepo:IBusBookingRepo
    {
        private readonly BusDbContext dbContext;

        public BusBookingRepo(BusDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddReservation(List<ReservationdetailsModel> reservationdetails)
        {
            Invoice invoice= new Invoice();
            invoice.ReservationDate = reservationdetails[0].ReservationDate;
            invoice.InvoiceDate=DateTime.Now;
            invoice.busInfo = await dbContext.Buses.FindAsync(reservationdetails[0].busid);
            await  dbContext.Invoices.AddAsync(invoice);
            await dbContext.SaveChangesAsync();
            List<ReservationDetails> reservationdetailsList= new List<ReservationDetails>();
            ReservationDetails reservation;
            foreach (var model in reservationdetails)
            {
                reservation=new ReservationDetails();
                reservation.invoice = invoice;
                reservation.seatnumber= model.seatnumber;
                reservation.Gender = model.Gender;
                reservation.Age = model.Age;
                reservationdetailsList.Add(reservation);
            }
            await dbContext.Reservations.AddRangeAsync(reservationdetailsList);
            await dbContext.SaveChangesAsync();
            return reservationdetailsList.Count;
                
        }

        public async Task<int> deleteBooking(int id)
        {
            List<ReservationDetails> reservationDetails =await (from rd in dbContext.Reservations 
                                                           where rd.invoice.Id == id select rd).ToListAsync();
            dbContext.Reservations.RemoveRange(reservationDetails);
            return 1;
        }

        public async Task<List<int>> GetAllReservedSeatsByBusId(ReservationdetailsModel reservationdetailsModel)
        {
            return await(from b in dbContext.Buses 
                         join i in dbContext.Invoices on b.Id equals i.busInfo.Id
                         join r in dbContext.Reservations on i.Id equals r.invoice.Id
                         where b.Id ==reservationdetailsModel.busid && i.ReservationDate ==reservationdetailsModel.ReservationDate
                          select r.seatnumber
                         ).ToListAsync();
        }
    }
}
