using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeassurementWebService.Model
{
    public class Meassurement
    {
        public int Id { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public DateTime TimeStamp { get; set; }

        public Meassurement()
        {
            
        }
        
        public Meassurement(float pressure, float humidity, float temperature, DateTime timeStamp)
        {
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Pressure)}: {Pressure}, {nameof(Humidity)}: {Humidity}, {nameof(Temperature)}: {Temperature}, {nameof(TimeStamp)}: {TimeStamp}";
        }
    }
}
