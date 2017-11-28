using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

// Player

[Game, Unique]
public class PlayerComponent : IComponent
{
}

[Game, Unique]
public class PlayerMoneyComponent : IComponent
{
    public long Money;
}

// Time

[Game, Unique]
public class GameTimeComponent : IComponent
{
    public long Tick;
}

// Gameplay

[Game]
public class FruitComponent : IComponent
{
}

[Game]
public class TitleComponent : IComponent
{
    public string Content;
}

[Game]
public class DescriptionComponent : IComponent
{
    public string Content;
}

[Game]
public class BuyableComponent : IComponent
{
    public long Price;
}

[Game]
public class SellableComponent : IComponent
{
    public long Price;
}

[Game]
public class GrowableComponent : IComponent
{
    public long Duration;
}

[Game]
public class ProductorComponent : IComponent
{
    public long Frequency;
}

[Game]
public class VegetableComponent : IComponent
{
}

[Game]
public class SeedComponent : IComponent
{

}

[Game]
public class StoredComponent : IComponent
{

}

[Game]
public class PlantedComponent : IComponent
{
    public int SlotIndex;
}

[Game]
public class GrowingComponent : IComponent
{
    public long Elapsed;
}

/// <summary>
/// Put it on FruitComponent when they are grown up and they produce fruits
/// Elapsed is meant to keep track of the last time the tree produced a fruit 
/// and must be reset to 0 on production
/// </summary>
[Game]
public class ProducingComponent : IComponent
{
    public long Elapsed;
}

// Slots

[Game]
public class VegetableSlotComponent : IComponent
{
    public int Index;
}

[Game]
public class FruitSlotComponent : IComponent
{
    public int Index;
}

[Game]
public class LockedComponent : IComponent
{

}

[Game]
public class IconComponent : IComponent
{
    public Sprite Sprite;
}