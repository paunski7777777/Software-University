public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double hardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType == "Hard")
        {
            tyre = new HardTyre(hardness);
        }
        else if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(tyreArgs[2]);

            tyre = new UltrasoftTyre(hardness, grip);
        }

        return tyre;
    }
}

