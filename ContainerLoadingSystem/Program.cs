namespace ContainerLoadingSystem;

public class Program
{
    private static ContainerShip _containerShip = new ContainerShip(30, 5, 300000);

    public static void Main(string[] args)
{
    ContainerShip ship1 = new ContainerShip(20, 5, 100000); // Example parameters
    ContainerShip ship2 = new ContainerShip(25, 10, 200000); // Another ship

    var refrigeratedContainer = CreateRefrigeratedContainer("Fish", -2);
    var gasContainer = CreateGasContainer(10.5);

    refrigeratedContainer.LoadCargo(5000);
    gasContainer.LoadCargo(8500);

    ship1.LoadContainer(refrigeratedContainer);
    ship1.LoadContainer(gasContainer);

    // Load a list of containers onto a ship (assuming we have a list)
    List<Container> containers = new List<Container>
    {
        CreateGasContainer(8),
        CreateRefrigeratedContainer("Bananas", 13.3)
    };
    containers.ForEach(ship2.LoadContainer);

    // Remove a container from the ship
    ship1.UnloadContainer(gasContainer);

    // Unload a container (assuming this means emptying it)
    refrigeratedContainer.EmptyCargo();

    // Replace a container on the ship
    var newRefrigeratedContainer = CreateRefrigeratedContainer("Ice cream", -18);
    ship1.ReplaceContainer(refrigeratedContainer, newRefrigeratedContainer);

    // Transfer a container between two ships
    ship1.TransferContainer(newRefrigeratedContainer, ship2);

    // Print information about a given container
    ship2.PrintContainerInfo(newRefrigeratedContainer.SerialNumber);

    // Print information about a given ship and its cargo
    ship1.PrintShipInformation();
    ship2.PrintShipInformation();
}

// These methods are placeholders for the actual instantiation of containers
private static RefrigeratedContainer CreateRefrigeratedContainer(string productType, double temperature)
{
    // The actual implementation would create a refrigerated container with the given parameters
    return new RefrigeratedContainer(250, 1000, 200, 20000, productType, temperature);
}

private static GasContainer CreateGasContainer(double pressure)
{
    // The actual implementation would create a gas container with the specified pressure
    return new GasContainer(300, 1500, 250, 15000, pressure);
}

}