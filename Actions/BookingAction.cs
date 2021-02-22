using Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Actions
{
    public class BookingAction
    {
        private readonly IMongoCollection<Booking> _bookings;

        public BookingAction(IBookingstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bookings = database.GetCollection<Booking>(settings.BookingsCollectionName);
        }

        public List<Booking> Get() =>
            _bookings.Find(booking => true).ToList();

        public Booking Get(string id) =>
            _bookings.Find<Booking>(booking => booking.Id == id).FirstOrDefault();

        public Booking Create(Booking booking)
        {
            _bookings.InsertOne(booking);
            return booking;
        }

        public void Update(string id, Booking newBooking) =>
            _bookings.ReplaceOne(booking => booking.Id == id, newBooking);

        public void Remove(Booking newBooking) =>
            _bookings.DeleteOne(booking => booking.Id == newBooking.Id);

        public void Remove(string id) =>
            _bookings.DeleteOne(booking => booking.Id == id);

    }
}