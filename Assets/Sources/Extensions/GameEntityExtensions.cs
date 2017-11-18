using Entitas;

public static class GameEntityExtensions {

	public static GameEntity GetFruitSlotEntityBySlotIndex(this GameContext context, int index)
    {
        var fruitSlotEntities = context.GetEntities(GameMatcher.AllOf(GameMatcher.FruitSlot));
        foreach (var e in fruitSlotEntities)
        {
            if (e.fruitSlot.Index == index)
                return e;
        }

        return null;
    }

    public static GameEntity GetFruitEntityBySlotIndex(this GameContext context, int index)
    {
        var fruitsEntities = context.GetEntities(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted));
        foreach(var e in fruitsEntities)
        {
            if (e.planted.SlotIndex == index)
                return e;
        }

        return null;
    }

}
