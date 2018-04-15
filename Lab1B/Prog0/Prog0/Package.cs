//C7353
//Program 1A
//9-24-2017
//CIS 200-01
//This class is designed as an extension and derived from the parcel class.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public abstract class Package : Parcel
{
    //confirms private backing fields
    private double _length;
    private double _width;
    private double _height;
    private double _weight;

    //precondition: none
    //postcondition: assigns the correct values to backing fields
    public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
        : base(originAddress, destAddress)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    //precondition: must be >= 0
    //postcondition: assigns correct value
    public double Length
    {
        get
        {
            return _length;
        }

        set
        {
            if (value >= 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException("Length", value,
                    "Length must be >= 0");
        }
    }

    //precondition: must be >= 0
    //postcondition: assigns correct value
    public double Width
    {
        get
        {
            return _width;
        }

        set
        {
            if (value >= 0)
                _width = value;
            else
                throw new ArgumentOutOfRangeException("Width", value,
                    "Width must be >= 0");
        }
    }

    //precondition: must be >= 0
    //postcondition: assigns correct value
    public double Height
    {
        get
        {
            return _height;
        }
            
        set
        {
            if (value >= 0)
                _height = value;
            else
                throw new ArgumentOutOfRangeException("Height", value,
                    "Height must be >= 0");
        }
    }

    //precondition: must be >= 0
    //postcondition: assigns correct value
    public double Weight
    { get
        {
            return _weight;
        }

        set
        {
            if (value >= 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException("Weight", value,
                    "Weight must be >= 0");
        }
    }

    //precondition: all the values have been assigned
    //postcondition: displays a tostring of the values created
    public override string ToString()
    {
        string NL = Environment.NewLine; 

        return $"Origin Address: {OriginAddress} {NL} Return Address: {DestinationAddress} {NL}"
            +
            $"Length: {Length} inches {NL} Width: {Width} inches {NL} Height: {Height} inches {NL} Weight: {Weight} Lbs";
    }
}

