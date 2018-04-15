//C7353
//Program 1B
//10-4-2017
//CIS 200-01
//This class is designed as an extension and derived from the package class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NextDayAirPackage : AirPackage
{
    //precondition: none
    //postcondition: assigns the correct values to backing fields
    public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee)
        : base(originAddress, destAddress, length, width, height, weight)
    {}

    //precondition: none
    //postcondition: returns express fee
    public decimal ExpressFee
    {
        get
        {
            const decimal expressFee = 5.25m;

            return expressFee;
        }
        
    }

    //precondition: none
    //postcondition: returns an updated value for the calcCost method
    public override decimal CalcCost()
    {
        const double weightCharge = .25;
        const double sizeCharge = .25;
        const double dimensionCost = .40;
        const double weightCost = .30;
        

        double cost;

        cost = (dimensionCost * (Length + Width + Height) + weightCost * (Weight) + (Convert.ToDouble(ExpressFee)));

        if(IsHeavy())
        {
            cost = cost + (weightCharge * (Weight));
        }
        
        if(IsLarge())
        {
            cost = cost + (sizeCharge * (Length + Width + Height));
        }


        return Convert.ToDecimal(cost);

    }

    //precondition: all the values have been assigned
    //postcondition: displays a tostring of the values created
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Next Day Air Package: {NL}Origin Address: {OriginAddress} {NL}{NL} Destination Address: {DestinationAddress} {NL}"
            +
            $"{NL}Length: {Length} inches{NL} Width: {Width} inches{NL} Height: {Height} inches{NL}" +
            $" Weight: {Weight} Lbs{NL} Is Overweight: {IsHeavy().ToString()}{NL} Is Large: {IsLarge().ToString()}{NL}" +
            $"Express Fee: {ExpressFee}{NL} Cost: {CalcCost():C}";
    }
}

