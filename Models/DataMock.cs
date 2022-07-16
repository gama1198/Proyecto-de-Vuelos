using System;
using System.Collections.Generic;

namespace VuelosApp.Models
{
    public class DataMock
    {
        public static List<Flight> Flights = new List<Flight>()
        {
            new Flight() { 
                Date = new DateTime(2022,5,18,14,30,00),
                Destination = "Santiago, Chile", 
                Origin = "Concepción, Chile", 
                FlightType = FlightType.National, 
                NumFlight = "SC0509", 
                State = State.Arrival  
            },
            new Flight() {
                Date = new DateTime(2022,5,18,14,30,00),
                Destination = "Puerto Montt, Chile",
                Origin = "Concepción, Chile",
                FlightType = FlightType.National,
                NumFlight = "PC0529",
                State = State.OnBoarding
            },
            new Flight() {
                Date = new DateTime(2022,5,18,14,30,00),
                Destination = "Arica, Chile",
                Origin = "Santiago, Chile",
                FlightType = FlightType.National,
                NumFlight = "SC045509",
                State = State.Waiting
            },
            new Flight() {
                Date = new DateTime(2022,5,17,17,30,00),
                Destination = "Hong Kong, China",
                Origin = "Santiago, Chile",
                FlightType = FlightType.International,
                NumFlight = "SH06587509",
                State = State.Closed
            },
            new Flight() {
                Date = new DateTime(2022,5,18,21,30,00),
                Destination = "Santiago, Chile",
                Origin = "Tokio, Japón",
                FlightType = FlightType.International,
                NumFlight = "SC9545509",
                State = State.Waiting
            },
        };
    }
}
