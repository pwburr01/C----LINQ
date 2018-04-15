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


public abstract class AirPackage : Package
{
    //precondition: none
    //postcondition: assigns the correct values to backing fields
    public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight)
    { }


    //precondition: weight of package is determined
    //postcondition: returns value if overweight
    public bool IsHeavy()
    {
        int overweight = 75;


        if(Weight >= overweight)
        {
            return true;
        }
        else
        {
            return false;
        }    
    }

    //precondition: size of package is determined
    //postcondition: returns value if package is oversized
    public bool IsLarge()
    {
        int large = 100;
        double size = (Length + Width + Height);

        if(size >= large)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //precondition: all the values have been assigned
    //postcondition: displays a tostring of the values created
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Origin Address: {OriginAddress} {NL} Return Address: {DestinationAddress} {NL}"
            +
            $"Length: {Length} inches {NL} Width: {Width} inches {NL} Height: {Height} inches {NL}" +
            $" Weight: {Weight} Lbs {NL} Is Overweight: {IsHeavy().ToString()} {NL} Is Large: {IsLarge().ToString()}";
    }


}

