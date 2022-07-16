using System;
namespace VuelosApp.Models
{
    public class Flight
    {
        public DateTime Date { get; set; } 
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string NumFlight { get; set; }
        public string FlightType { get; set; }
        public string State { get; set; }
    }

    public static class FlightType
    {
        public const string National = "Nacional", International = "Internacional";
    }

    public static class State 
    {
        public const string Waiting = "Pendiente",
            Arrival = "En arribo",
            OnBoarding = "En Embarque",
            OnWay = "En espera",
            Closed = "Cerrado";
    }

    public static class City
    {
        public static string[] NationalCities = { "Santiago, Chile", "Concepción, Chile", "Puerto Montt, Chile", "Antofagasta, Chile", "Arica, Chile" };

        public static string[] InternationalCities = { "Santiago, Chile", "Tokio, Japón", "Londres, Reino Unido",
            "Paris, Francia", "Hong Kong, China", "Pekín, China", "Berlín, Alemania", "New York, Estado Unidos", "Sídney, Australia"  };
    }
}
