using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPI.CountryInfoServiceSOAP;

namespace CountryAPI.Services.CountryInfoServices
{
    public interface ICountryInfoAPI
    {
        IList<Continent> GetAllContinents();
        string GetCountryFlagUrl(string countryCode);
    }

    public class CountryInfoAPI : ICountryInfoAPI
    {
        private const string EndpointConfiguration = "CountryInfoServiceSoap12";

        private readonly CountryInfoServiceSoapTypeClient soapClient;

        public CountryInfoAPI()
        {
            soapClient = new CountryInfoServiceSoapTypeClient(EndpointConfiguration);
        }

        public IList<Continent> GetAllContinents()
        {
            List<Continent> result = new List<Continent>();
            try
            {
                foreach(var c in soapClient.ListOfContinentsByName())
                {
                    result.Add(new Continent() { Name = c.sName });
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<Continent>();
            }
        }

        public string GetCountryFlagUrl(string countryCode)
        {
            try
            {
                string url = soapClient.CountryFlag(countryCode);
                return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) ? url : string.Empty;

            }
            catch(Exception ex)
            {
                return string.Empty;
            }

        }
    }

}
