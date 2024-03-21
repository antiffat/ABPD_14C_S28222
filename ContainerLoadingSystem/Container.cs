namespace ContainerLoadingSystem;

public abstract class Container
{
    public double CargoMass { get; protected set; }
    public int Height { get; private set; }
    public double TareWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public double MaximumPayload { get; private set; }

    private static int serialCounter = 0;

    protected Container(int height, double tareWeight, int depth, double maximumPayload)
    {
        this.Height = height;
        this.TareWeight = TareWeight;
        this.Depth = depth;
        this.MaximumPayload = maximumPayload;
        this.SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        return $"KON-{GetSerialNumberPrefix()}-{++serialCounter}";
    }

    protected abstract string GetSerialNumberPrefix();

    public virtual void LoadCargo(double mass)
    {
        if (mass > MaximumPayload)
            throw new OverfillException("Mass of the cargo is greater than the capacity of a given container.");

        CargoMass = mass;
    }

    public virtual void EmptyCargo()
    {
        CargoMass = 0;
    }
}