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

[Game, UI]
public class StoredEntitiesNumberChangedComponent : IComponent
{
    public IStoredEntitiesNumberChangedListener Listener;
}

[Game, UI]
public class SelectedEntityChangedComponent : IComponent
{
    public ISelectedEntityChangedListener Listener;
}

[Game, UI]
public class PlantedEntityChangedComponent : IComponent
{
    public IPlantedEntityChangedListener Listener;
}

[Game, UI]
public class GrowingEntityChangedComponent : IComponent
{
    public IGrowingEntityChangedListener Listener;
}

[Game, UI]
public class ProducingEntityChangedComponent : IComponent
{
    public IProducingEntityChangedListener Listener;
}