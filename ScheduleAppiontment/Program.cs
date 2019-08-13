using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleAppiontment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = CreateCustomerData();
            Console.WriteLine("START: Creates a list of available time slots");
            List<AvailableTimeSlots> availableTimeSlots = new List<AvailableTimeSlots>();
            for (int i = 1; i <= 5; i++)
            {
                AvailableTimeSlots temp = new AvailableTimeSlots
                {
                    slotId = i,
                    dateTime = DateTime.UtcNow.AddDays(i)
                };

                availableTimeSlots.Add(temp);
            }
            Console.WriteLine("END: Created a list of available time slots");

            Console.WriteLine("START: Assign car schedule to customers");
           
            List<ScheduledAppointments> scheduledAppointments = new List<ScheduledAppointments>();
            int idx = 0; 
            foreach (var item in customers)
            {
                foreach (var item2 in item.Cars)
                {
                    idx = idx + 1;
                    ScheduledAppointments scheduled = new ScheduledAppointments
                    {
                        customername = item.Name,
                        phoneno = item.Phone,
                        carinfo = item2.Year + "  " + item2.Make + " " + item2.Model,
                        appointmentTime = availableTimeSlots[idx].dateTime
                    };
                    availableTimeSlots[idx].isScheduled = true;
                    scheduledAppointments.Add(scheduled);
                }
                
            }
            
            Console.WriteLine("END: Assigned car schedule to customers");

            Console.WriteLine("Print out Schedule");
            Console.WriteLine("---------------------------------------");
            PrintScheduledAppointments(scheduledAppointments);
            Console.WriteLine("---------------------------------------");



            Console.WriteLine("Order by Date");
            Console.WriteLine("---------------------------------------");
            PrintScheduledAppointments(scheduledAppointments.OrderBy(a => a.appointmentTime).ToList());
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Order by Customer Name ASC");
            Console.WriteLine("---------------------------------------");
            PrintScheduledAppointments(scheduledAppointments.OrderBy(a => a.customername).ToList());
            Console.WriteLine("---------------------------------------");


            // Schedule Car1 Tuesday 3pm

            // Schedule Car2 Monday 9am

            // Schedule Car3 Wednesday 1pm

            // Schedule Car4 Wednesday 11am


            // Print out Schedule
            // Customer Name, Phone, Car Year, Make, Model, Date
            //Console.WriteLine("Print out Schedule");


            // Print out Schedule Ordered by Date
            //Console.WriteLine("Schedule by Date");


            // Print out Schedule Ordered by Customer Name
            //Console.WriteLine("Schedule by Date");


            // Keep Console Window open till user hits a key
            Console.ReadKey();
        }


        static List<Customer> CreateCustomerData()
        {
            var customers = new List<Customer>();

            var car1 = new Car("Honda", "CRV", 2004, "Silver");
            var customer1 = new Customer("Joe Schmoe", "801-914-3947", "222 River Rd");
            customer1.Cars.Add(car1);
            customers.Add(customer1);

            var car2 = new Car("Toyota", "Camry", 2007, "Red");
            var customer2 = new Customer("Jane Doe", "385-476-8834", "1314 Main St");
            customer2.Cars.Add(car2);
            customers.Add(customer2);

            var car3 = new Car("Ford", "Mustang", 2011, "Black");
            var car4 = new Car("Ford", "F150", 2009, "Blue");
            var customer3 = new Customer("Jack Lake", "915-445-7563", "3789 LEgacy Park Ln");
            customer3.Cars.Add(car3);
            customer3.Cars.Add(car4);
            customers.Add(customer3);

            return customers;
        }

        static void PrintScheduledAppointments(List<ScheduledAppointments> scheduledAppointments)
        {
            foreach (var item in scheduledAppointments)
            {
                Console.WriteLine(item.customername + " " + item.phoneno + "  " + item.carinfo + " " + item.appointmentTime.ToString());
            }

        }
    }
}
