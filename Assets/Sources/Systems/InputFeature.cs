public class InputFeature : Feature
{
    public InputFeature(Contexts contexts) : base("Input Systems")
    {
        Add(new HandleBuyFruitInputSystem(contexts));
        Add(new HandleBuyFruitSlotInputSystem(contexts));
        Add(new HandleBuyVegetableInputSystem(contexts));
        Add(new CleanInputSystem(contexts));
    }
}
