public class InputFeature : Feature
{
    public InputFeature(Contexts contexts) : base("Input Systems")
    {
        Add(new HandleBuyFruitInputSystem(contexts));
        Add(new HandleBuySelectedInputSystem(contexts));
        Add(new HandlePlantSelectedEntityInputSystem(contexts));
        Add(new CleanInputSystem(contexts));
    }
}
