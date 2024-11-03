using AlgorithmProject;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Etkinlikler başlangıç saatlerine göre sıralanır.
        //ilk etkinlik ve ondan sonraki etkinliğin yol süresi eklenerek çakışıp çakışmadığı kontrol edilir.
        //Çakışma varsa öncelik sırası ile iki etkinlik arasında gidilecek etkinlik belirlenir. Seçilen etkinlik ve sıradaki etkinlik için de aynı durum işlenir. Bu durum çakışma olmayana kadar devam eder. Çakışma yoksa seçilen etkinlik gidilecek etkinliğe eklenir.
        //Bu döngü sırayla tüm etkinlikler için yapılır.
        
        var events = EventManager.GetEvents();

        var travelTimes = TravelTimeManager.GetTravelTimes();

        var selectedEvents = EventScheduler.ScheduleEvents(events, travelTimes);

        Printer.PrintResults(selectedEvents);
    }
}
