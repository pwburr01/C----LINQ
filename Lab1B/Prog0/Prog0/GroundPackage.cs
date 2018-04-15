//C7353
//Program 1A
//9-24-2017
//CIS 200-01
//This class is designed as an extension and derived from the package class.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GroundPackage : Package
{
    //precondition: none
    //postcondition: assigns the correct values to backing fields
    public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight)
    { }

    //precondition: none
    //postcondition: returns distance of zip codes
    private int ZoneDistance
    {
        get
        {
            const int firstDigit = 10000;
            int ZD;

            ZD = (OriginAddress.Zip / firstDigit) - (DestinationAddress.Zip / firstDigit);

            return Math.Abs(ZD);
        }
    }

    //precondition: none
    //postcondition: replaces calculate cost with an updated value
    public override decimal CalcCost()
    {
        const double dimensionCost = .20;
        const double weightCost = .05;
        const double ZDadjustment = 1;

        double cost;

        cost = (dimensionCost * (Length + Width + Height) + weightCost * (ZoneDistance + ZDadjustment) * (Weight));

        return Convert.ToDecimal(cost);
    }

    //precondition: all the values have been assigned
    //postcondition: displays a tostring of the values created
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Ground Package: {NL}Origin Address: {OriginAddress} {NL}{NL} Destination Address: {DestinationAddress} {NL}" +
            $"{NL}Length: {Length} inches {NL} Width: {Width} inches {NL} Height: {Height} inches {NL}" +
            $" Weight: {Weight} Lbs {NL} Zone Distance: {ZoneDistance} {NL} Cost: {CalcCost():C}";
    }
}