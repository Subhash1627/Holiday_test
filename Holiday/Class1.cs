using Newtonsoft.Json;
using System.Reflection;

namespace Holiday
{
    public class Class1
    {

       
            List<Flight> flights = new List<Flight>();
            List<Hotel> hotels = new List<Hotel>();


        public Class1()
        {
           

           // string dataFolderPath = @"C:\Projects\Holiday\Holiday\Data\"; 
            //string flightsFilePath = Path.Combine(dataFolderPath, "flights.json");

            string flightsFilePath = @"C:\Users\DELL\Downloads\Holiday\Holiday\Data\flights.json";

            List<Flight> lstFlight = JsonConvert.DeserializeObject<List<Flight>>(File.ReadAllText(flightsFilePath));

            // Read hotels JSON file
            //string hotelsFilePath = Path.Combine(dataFolderPath, "hotels.json");

            string hotelsFilePath = @"C:\Users\DELL\Downloads\Holiday\Holiday\Data\hotels.json";
            List<Hotel> lstHotel = JsonConvert.DeserializeObject<List<Hotel>>(File.ReadAllText(hotelsFilePath));

            this.flights = lstFlight;
            this.hotels = lstHotel;

        }



        public Tuple<Flight, Hotel> SearchHoliday(string from, string to, DateTime departureDate, int duration)
            {
                List<Flight> lstflights = new List<Flight>();
                List<Hotel> lsthotels = new List<Hotel>();
                // flier flights from and to date if we enter airport code in brace start 
                if (from.Contains("(") && from.Contains(")"))
                {
                    string airportCode = from.Split('(')[1].Split(')')[0];
                    lstflights = flights.Where(flight => flight.from.Equals(airportCode, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (flights.Exists(flight => flight.from.Equals(from, StringComparison.OrdinalIgnoreCase)))
                {
                    lstflights = flights.Where(flight => flight.from.Equals(from, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    lstflights = flights;
                }

                if (to.Contains("(") && to.Contains(")") && lstflights != null && lstflights.Count > 0)
                {
                    string airportCode = to.Split('(')[1].Split(')')[0];
                    lstflights = lstflights.Where(flight => flight.to.Equals(airportCode, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (lstflights != null && lstflights.Count > 0 && lstflights.Exists(flight => flight.to.Equals(to, StringComparison.OrdinalIgnoreCase)))
                {
                    lstflights = lstflights.Where(flight => flight.from.Equals(from, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                // flier flights from and to date if we enter airport code in brace end

                // flier hotel start
                if (to.Contains("(") && to.Contains(")") && hotels != null && hotels.Count > 0)
                {
                    string destination = to.Split('(')[1].Split(')')[0];
                    lsthotels = hotels.Where(hotel => hotel.local_airports.Contains(destination)).ToList();
                }
                else if (hotels.Exists(hotel => hotel.local_airports.Contains(to)))
                {
                    lsthotels = hotels.Where(hotel => hotel.local_airports.Contains(to)).ToList();
                }
                else
                {
                    lsthotels = hotels;
                }
                // flier hotel end

                List<Flight> availableFlights = lstflights.Where(f => f.departure_date.Date == departureDate.Date).ToList();
                if (availableFlights == null || (availableFlights != null && availableFlights.Count == 0) && flights.Exists(f => f.departure_date.Date == departureDate.Date))
                {
                    availableFlights = flights.Where(f => f.departure_date.Date == departureDate.Date).ToList();
                }
                var bestFlight = availableFlights.OrderBy(f => f.price).FirstOrDefault();

                List<Hotel> availableHotels = lsthotels.Where(h => (h.arrival_date.Date <= departureDate.Date && h.nights == duration)).OrderBy(h => h.price_per_night).ToList();
                if (availableHotels == null || (availableHotels != null && availableHotels.Count == 0) && hotels.Exists(h => h.arrival_date.Date == departureDate.Date))
                {
                    availableHotels = hotels.Where(h => h.arrival_date.Date == departureDate.Date && h.nights == duration).OrderBy(h => h.price_per_night).ToList();
                    availableHotels = availableHotels.Where(hotel => hotel.local_airports.Contains(bestFlight.to)).ToList();
                }
                if (!availableFlights.Any() || !availableHotels.Any())
                    return null;

                var bestHotel = availableHotels.First();

                return new Tuple<Flight, Hotel>(bestFlight, bestHotel);
            }
        }
    

}
