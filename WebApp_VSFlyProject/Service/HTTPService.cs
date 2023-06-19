using Newtonsoft.Json;
using System.Text;
using WebApi_VSFlyProject.Models;

namespace WebApp_VSFlyProject.Service
{
    public class HTTPService
    {
        private readonly HttpClient _httpClient;
        private readonly string _urlApi;

        public HTTPService(string urlApi)
        {
            _urlApi = urlApi;
            _httpClient = new HttpClient();
        }

        //Return all available flights(not full and in the future)
        public async Task<ICollection<FlightModel>?> GetFlightsNotFull()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlApi);

            if (response.IsSuccessStatusCode)
            {
                string flightModel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ICollection<FlightModel>>(flightModel);
            }
            return null;

        }

        //Return the sale price of a flight if is not full and in future
        public async Task<double> GetSaleByFlight(string flightNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlApi+ "/salePrice/" + flightNumber);

            if (response.IsSuccessStatusCode)
            {
                string model = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<double>(model);
            }
            return -1;
        }

        // Buying a ticket on a flight
        public async Task<bool> BuyTicket(string flightNo, BookingRegistrationModel bookingContent)
        {
            var json = JsonConvert.SerializeObject(bookingContent);
            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_urlApi+ "/" + flightNo, stringContent);
            return response.IsSuccessStatusCode;
        }

        //Return the total sale price of all tickets sold for a flight
        public async Task<double> GetSalesByFlight(string flightNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlApi+ "/sales/" + flightNumber);

            if (response.IsSuccessStatusCode)
            {
                string model = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<double>(model);
            }
            return -1;
        }

        //Return the average sale price of all tickets sold for a destination(multiple flights possible)
        public async Task<double> GetAverageSalesByDestination(string destination)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlApi + "/average/" + destination);

            if (response.IsSuccessStatusCode)
            {
                string model = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<double>(model);
            }
            return -1;

        }

        //Return the list of all tickets sold for a destination 
        //with the first and last name of the travelers and the flight number as well as the sale price of each ticket
        public async Task<ICollection<BookingModel>?> GetTicketsByDestination(string destination)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlApi + "/ticket/" + destination);

            if (response.IsSuccessStatusCode)
            {
                string model = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ICollection<BookingModel>>(model);
            }
            return null;

        }
    }
}
