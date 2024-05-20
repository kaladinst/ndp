using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactInfo { get; set; }
    }
    public interface IAppointment
    {
        void Schedule();
        void Cancel();
    }
    public class Customer : Person
    {

    }
    // Define the Employee class
    public class Employee : Person
    {

    }

// Define the Service class
    public class Service
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }



// Define the Appointment class
    public class Appointment : IAppointment
    {
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }

        public void Schedule()
        {
        }

        public void Cancel()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}