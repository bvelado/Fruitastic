using Entitas;
using System.Collections.Generic;
using System;

public class NotifyFruitSlotChangedSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public NotifyFruitSlotChangedSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        var fruitSlotChangedListeners = _contexts.uI.GetEntities(UIMatcher.FruitSlotChanged);

        foreach(var e in entities)
        {
            foreach (var listenerEntity in fruitSlotChangedListeners)
            {
                //if (listenerEntity.fruitSlotChanged.Listener.Index == e.fruitSlot.Index)
                //{
                    listenerEntity.fruitSlotChanged.Listener.FruitSlotChanged(e);
                //}
            }
        }
        
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasFruitSlot)
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.FruitSlot);
    }
}
