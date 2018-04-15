//C7353
//Program 1A
//9-24-2017
//CIS 200-01
//This class is designed as an extension and derived from the airpackage class.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TwoDayAirPackage : AirPackage
{
    //establishes pricate backing field
    public enum Delivery { Early, Saver }
    private Delivery _deliveryType;

    //precondition: none
    //postcondition: assigns the correct values to backing fields
    public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery deliveryType)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        DeliveryType = deliveryType;
    }

    //precondition: none
    //postcondition: returns enum value
    public Delivery DeliveryType
    {
        get
        {
            return _deliveryType;
        }
        set
        {
            if (value != Delivery.Early)
            { value = _deliveryType; }

            else
            if (value != Delivery.Saver)
            { value = _deliveryType; }

            else
                throw new ArgumentOutOfRangeException($"{nameof(DeliveryType)}", value,
                    $"{nameof(DeliveryType)} must be a valid delivery type.");
        }
    }

    //precondition: none
    //postcondition: returns an updated value for the calcCost method
    public override decimal CalcCost()
    {
        const double dimensionCost = .25;
        const double weightCost = .25;
        const double saverdiscount = .9;

        double baseCost = dimensionCost * (Length + Height + Width) + weightCost * (Weight);

        if(DeliveryType == Delivery.Saver)
        {
            baseCost = baseCost * saverdiscount;
        }

        return Convert.ToDecimal(baseCost);
    }
    //precondition: all the values have been assigned
    //postcondition: displays a tostring of the values created
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Two Day Air Package: {NL}Origin Address: {OriginAddress} {NL}{NL} Destination Address: {DestinationAddress} {NL}"
            +
            $"{NL}Length: {Length} inches{NL} Width: {Width} inches{NL} Height: {Height} inches{NL}" +
            $" Weight: {Weight} Lbs{NL} Is Overweight: {IsHeavy().ToString()}{NL} Is Large: {IsLarge().ToString()}{NL}" +
            $"Delivery Type: {DeliveryType.ToString()}{NL} Cost: {CalcCost():C}";
    }


}

