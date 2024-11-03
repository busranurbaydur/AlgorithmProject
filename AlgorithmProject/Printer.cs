using AlgorithmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject
{
    static class Printer
    {
        /// <summary>
        /// Seçilen etkinlikleri istenilen formata göre konsola yazdırır
        /// </summary>
        /// <param name="selectedEvents">Seçilen etkinliklerin listesi.</param>
        public static void PrintResults(List<Event> selectedEvents)
        {
            int totalEvents = selectedEvents.Count;
            string eventIds = string.Join(", ", selectedEvents.Select(e => e.Id));
            int totalPriority = selectedEvents.Sum(e => e.Priority);

            Console.WriteLine($"Katılınabilecek Maksimum Etkinlik Sayısı: {totalEvents}");
            Console.WriteLine($"Katılınabilecek Etkinliklerin ID'leri: {eventIds}");
            Console.WriteLine($"Toplam Değer: {totalPriority}");
        }
    }
}
