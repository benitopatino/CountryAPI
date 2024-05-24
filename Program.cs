using CountryAPI.Services.CountryInfoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CountryInfoAPI api = new CountryInfoAPI();
            try
            {
                foreach(var c in api.GetAllContinents())
                {
                    Console.WriteLine(c.Name);
                }

                Console.WriteLine(api.GetCountryFlagUrl("US"));
            }
            catch(Exception ex) { }
            {
                // do whaterv
            }
        }
    }
}
