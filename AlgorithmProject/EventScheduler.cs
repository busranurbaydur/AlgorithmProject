using AlgorithmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject
{
    static class EventScheduler
    {
        /// <summary>
        /// Etkinlikleri, çakışma ve öncelik durumlarını göz önüne alarak zaman çizelgesine ekler. Çakışma durumunda, önceliği yüksek olan etkinlik seçilir.
        /// </summary>
        /// <param name="events">Planlanacak etkinliklerin listesi.</param>
        /// <param name="travelTimes">Etkinlikler arasındaki seyahat sürelerini içeren liste.</param>
        /// <returns></returns>
        public static List<Event> ScheduleEvents(List<Event> events, List<TravelTime> travelTimes)
        {
            events = events.OrderBy(e => e.StartTime).ToList();
            var selectedEvents = new List<Event>();
            foreach (var currentEvent in events)
            {
                //Çakışan etkinliğin olup olmadığını tutar
                bool conflictingEvent = false;
                foreach (var selectedEvent in selectedEvents)
                {
                    int travelTime = TravelTimeManager.GetTravelTime(selectedEvent.Location, currentEvent.Location);
                    var arrivalTime = selectedEvent.EndTime.Add(TimeSpan.FromMinutes(travelTime));

                    if (arrivalTime > currentEvent.StartTime)
                    {
                        if (currentEvent.Priority > selectedEvent.Priority)
                        {
                            //Mevcut etkinlik daha yüksek öncelikliyse, eski etkinlik artık seçilen etkinliklerden silinir
                            selectedEvents.Remove(selectedEvent);
                            selectedEvents.Add(currentEvent);
                        }
                        conflictingEvent = true;
                        break;
                    }
                }
                // Eğer çakışma yoksa etkinlik eklenir
                if (!conflictingEvent)
                {
                    selectedEvents.Add(currentEvent);
                }
            }

            return selectedEvents;
        }
    }
}
