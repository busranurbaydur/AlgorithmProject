using AlgorithmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject
{
    static class TravelTimeManager
    {
        /// <summary>
        /// Lokasyonlar arasındaki seyahat sürelerini döndürür.
        /// </summary>
        /// <returns></returns>
        public static List<TravelTime> GetTravelTimes()
        {
            return new List<TravelTime>
            {
                new TravelTime { From = "A", To = "B", DurationMinutes = 15 },
                new TravelTime { From = "A", To = "C", DurationMinutes = 20 },
                new TravelTime { From = "A", To = "D", DurationMinutes = 10 },
                new TravelTime { From = "B", To = "C", DurationMinutes = 5 },
                new TravelTime { From = "B", To = "D", DurationMinutes = 25 },
                new TravelTime { From = "C", To = "D", DurationMinutes = 25 }
            };
        }

        /// <summary>
        /// Seçilen iki lokasyon arasındaki seyahat süresini döndürür
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Eğer lokasyonlar aynıysa 0 döner. Geçerli bir seyahat süresi bulunamazsa int.MaxValue döner.</returns>
        public static int GetTravelTime(string from, string to)
        {
            if (from == to)
                return 0;

            var travelTimes = GetTravelTimes();
            var travel = travelTimes.FirstOrDefault(t => (t.From == from && t.To == to) || (t.From == to && t.To == from));
            return travel?.DurationMinutes ?? int.MaxValue ; 
        }
    }
}
