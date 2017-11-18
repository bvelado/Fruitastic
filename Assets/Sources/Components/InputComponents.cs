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

[Input]
public class SellFruitComponent : IComponent
{
    public GameEntity Entity;
}

[Input]
public class BuyVegetableComponent : IComponent
{
    public VegetableData VegetableData;
}

[Input]
public class BuyVegetableSlotComponent : IComponent
{
    public int Index;
}

[Input]
public class SellVegetableComponent : IComponent
{
    public GameEntity Entity;
}

