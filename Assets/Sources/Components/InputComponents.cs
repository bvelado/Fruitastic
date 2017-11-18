using Entitas;

[Input]
public class BuyFruitComponent : IComponent
{
    public FruitData FruitData;
}

[Input]
public class BuyFruitSlotComponent : IComponent
{
    public int Index;
}