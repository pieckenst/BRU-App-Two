using System;

namespace Burdukov_kurs
{
    public enum CallType
    {
        Incoming,
        Outgoing
    }

    public class Call
    {
        public string SubscriberNumber { get; set; }
        public string SubscriberName { get; set; }
        public CallType Type { get; set; }
        public string CorrespondentNumber { get; set; }
        public DateTime CallTime { get; set; }
        public int Duration { get; set; } // in seconds
        public decimal Cost { get; set; }
        public Tariff Tariff { get; set; }
        public OperatorService Service { get; set; }

        // Read-only properties for DataGridView binding
        public string TariffName => Tariff?.Name ?? "N/A";
        public string ServiceName => Service?.Name ?? "N/A";
        public string CallTypeString => Type.ToString();

        public Call() { }

        public Call(string subscriberName, string subscriberNumber, string correspondentNumber, 
                   CallType type, DateTime callTime, int duration, decimal cost, 
                   Tariff tariff, OperatorService service)
        {
            SubscriberName = subscriberName;
            SubscriberNumber = subscriberNumber;
            CorrespondentNumber = correspondentNumber;
            Type = type;
            CallTime = callTime;
            Duration = duration;
            Cost = cost;
            Tariff = tariff;
            Service = service;
        }
    }
}