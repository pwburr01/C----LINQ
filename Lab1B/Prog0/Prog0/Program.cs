// C7353
//Program 1B
// CIS 200-01
// Fall 2017
// Due: 10-4-2017
// Will display Linq Query results based on correct parameters

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class Program
    {

        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test Letter 3

            GroundPackage gp1 = new GroundPackage(a1, a2, 39, 23, 11, 4.5);
            NextDayAirPackage nda1 = new NextDayAirPackage(a3, a2, 33, 44, 55, 34, 3);
            TwoDayAirPackage tda1 = new TwoDayAirPackage(a1, a3, 33, 66, 54, 80, TwoDayAirPackage.Delivery.Early);


            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            // Add test data to list
            parcels.Add(l1);
            parcels.Add(l2);
            parcels.Add(l3);
            parcels.Add(gp1);
            parcels.Add(nda1);
            parcels.Add(tda1);

            ////Display data
            //Console.WriteLine("Program 0 - List of Parcels\n");

            //foreach (Parcel p in parcels)
            //{
            //    Console.WriteLine(p);
            //    Console.WriteLine("--------------------");
            //}
            string NL = Environment.NewLine;

            //displays the parcels organized by zipcode
            var destinationzip =
                from item in parcels
                orderby item.DestinationAddress.Zip descending
                select item;
            //code to legitimately display said items
            Console.WriteLine("Descending order of Destination Zipcodes:");
            Console.WriteLine();
            foreach (Parcel item in destinationzip)
            { Console.WriteLine($"{item} {NL}"); }


            //resets the system and allows for a pause between outputs
            Reset();
            Console.WriteLine("Ascending order of Cost:");
            Console.WriteLine();

            //query for ascending order cost
            var costOrder =
                from item in parcels
                orderby item.CalcCost() ascending
                select item;
            //display for cost query
            foreach (Parcel item in costOrder)
            { Console.WriteLine($"{item} {NL}"); }


            //resets the system and allows for a pause between outputs
            Reset();
            Console.WriteLine("Ordered by Type and then Cost:");
            Console.WriteLine();

            //query for organization based on type and cost
            var typeAndCost =
                from item in parcels
                orderby item.GetType().ToString() ascending, item.CalcCost() descending
                select item;
            //display for typecost query
            foreach (Parcel item in typeAndCost)
            {
                Console.WriteLine($"{item} {NL}");
            }

            //resets the system and allows for a pause between outputs
            Reset();
            Console.WriteLine("Heavy Airpackages:");
            Console.WriteLine();

            //query to output heavy airpackages
            var heavyPackages =
                from item in parcels
                where item is AirPackage
             let heavyPack = (AirPackage)item
             where heavyPack.IsHeavy()
                select item;

            //loop that will display the output of the Linq query
            foreach (Parcel item in heavyPackages)
            { Console.WriteLine($"{item}{NL}"); }
            Reset();

        }

        //precondition: none
        //postcondition: will display a prompt to enter to reset for the next display
            public static void Reset()
            {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear();
            }

        
    }
}
