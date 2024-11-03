using AlgorithmProject;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var events = EventManager.GetEvents();

        var travelTimes = TravelTimeManager.GetTravelTimes();

        var selectedEvents = EventScheduler.ScheduleEvents(events, travelTimes);

        Printer.PrintResults(selectedEvents);
    }
}
