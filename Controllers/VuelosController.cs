using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using VuelosApp.Models;
using VuelosApp.Models.ViewModels;

namespace VuelosApp.Controllers
{
    public class VuelosController : Controller
    {
        public IActionResult Index()
        {
            MultiTypeFlightsViewModel viewModel = new MultiTypeFlightsViewModel();  
            viewModel.NationalFlights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.National)).ToList();
            viewModel.NationalCities = City.NationalCities.ToList();

            viewModel.InternationalFlights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.International)).ToList();
            viewModel.InternactionalCities = City.InternationalCities.ToList();
            return View(viewModel);
        }

        public IActionResult Nacionales()
        {
            FlightsViewModel viewModel = new FlightsViewModel();
            viewModel.Flights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.National)).ToList();
            viewModel.Cities = City.NationalCities.ToList();
            ViewData["titulo"] = "Historial de vuelos nacionales";
            ViewData["origen"] = FlightType.National;
            return View(viewModel);
        }

        public IActionResult Internacionales()
        {
            FlightsViewModel viewModel = new FlightsViewModel();
            viewModel.Flights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.International)).ToList();
            viewModel.Cities = City.InternationalCities.ToList();
            ViewData["titulo"] = "Historial de vuelos internacionales";
            ViewData["origen"] = FlightType.International;
            return View("Nacionales", viewModel);
        }

        public IActionResult FindFlights(string origin, string destination, string flighType)
        {
            FlightsViewModel viewModel = new FlightsViewModel();
            if (flighType.Equals(FlightType.National))
            {
                viewModel.Flights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.National) && f.Origin.Equals(origin) &&
                                                            f.Destination.Equals(destination)).ToList();
                viewModel.Cities = City.NationalCities.ToList();
                ViewData["titulo"] = "Historial de vuelos nacionales";
                ViewData["origen"] = FlightType.National;
            }
            else
            {
                viewModel.Flights = DataMock.Flights.Where(f => f.FlightType.Equals(FlightType.International) && f.Origin.Equals(origin) &&
                                                            f.Destination.Equals(destination)).ToList();
                viewModel.Cities = City.InternationalCities.ToList();
                ViewData["titulo"] = "Historial de vuelos internacionales";
                ViewData["origen"] = FlightType.International;
            }

            return View("Nacionales", viewModel);
        }

        public IActionResult Create(string flightType)
        {
            if (string.IsNullOrEmpty(flightType)){
                flightType = FlightType.National;
            }else if(!flightType.Equals(FlightType.National) && !flightType.Equals(FlightType.International))
            {
                return StatusCode(500);
            }

            CreateFlightViewModel viewModel = new CreateFlightViewModel();

            if (FlightType.National.Equals(flightType))
            {
                viewModel.Cities = City.NationalCities.ToList(); 
            }
            else
            {
                viewModel.Cities = City.InternationalCities.ToList();
            }

            viewModel.States = new List<string>() { State.Waiting, State.Arrival, State.OnWay, State.OnBoarding, State.Closed };

            ViewData["FlightType"] = flightType;

            return View(viewModel);
        }

        public IActionResult Save(Flight flight)
        {
            List<string> errors = ValidFlightForm(flight);

            if(errors.Count > 0)
            {
                CreateFlightViewModel viewModel = new CreateFlightViewModel();
                viewModel.States = new List<string>() { State.Waiting, State.Arrival, State.OnWay, State.OnBoarding, State.Closed };
                viewModel.Errors = errors;
                return View("create", viewModel);
            }

            DataMock.Flights.Add(flight);

            if (FlightType.National.Equals(flight.FlightType))
            {
                return RedirectToAction(nameof(Nacionales));
            }
            else
            {
                return RedirectToAction(nameof(Internacionales));
            }
        }

        private List<string> ValidFlightForm(Flight flight)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(flight.Origin))
            {
                errors.Add("El origen no puede estar vacio");
            }

            if (string.IsNullOrEmpty(flight.Destination))
            {
                errors.Add("El destino no puede estar vacio");
            }

            if (string.IsNullOrEmpty(flight.NumFlight))
            {
                errors.Add("El número de vuelo no puede estar vacio");
            }

            if (string.IsNullOrEmpty(flight.State))
            {
                errors.Add("El estado del vuelo no puede estar vacio");
            }

            if (flight.Date.Equals(new System.DateTime(1, 1, 1)))
            {
                errors.Add("La fecha no puede estar vacia");
            }

            if (flight.Origin.Equals(flight.Destination))
            {
                errors.Add("El origen y el destino no pueden ser iguales");
            }

            return errors;
        }
    }
}
