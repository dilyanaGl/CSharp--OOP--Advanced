public class Ammunition : IAmmunition
{
    private string name;
    private double weight;
    private double wearLevel;

    public Ammunition(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
        this.wearLevel = this.weight * 100;
    }

    public string Name { get => this.name; }

    public double Weight { get => this.weight; }

    public double WearLevel
    {
        get => this.wearLevel;
    }

    public bool WearLevelIsZero { get => this.WearLevel == 0; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.wearLevel -= wearAmount;
    }

    public void ReturnWearLevelToOriginal()
    {
        this.wearLevel = this.weight * 100;
    }
}