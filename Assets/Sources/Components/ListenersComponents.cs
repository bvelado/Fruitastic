using Entitas;

[Game, UI]
public class TickChangedComponent : IComponent
{
    public ITickChangedListener Listener;
}

[Game, UI]
public class PlayerMoneyChangedComponent : IComponent
{
    public IPlayerMoneyChangedListener Listener;
}

[Game, UI]
public class FruitSlotChangedComponent : IComponent
{
    public IFruitSlotChangedListener Listener;
}