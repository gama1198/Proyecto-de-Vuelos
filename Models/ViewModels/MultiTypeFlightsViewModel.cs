using System.Collections.Generic;

namespace VuelosApp.Models.ViewModels
{
    public class MultiTypeFlightsViewModel
    {
        public List<Flight> NationalFlights;
        public List<Flight> InternationalFlights;

        public List<string> NationalCities;
        public List<string> InternactionalCities;
    }
}
