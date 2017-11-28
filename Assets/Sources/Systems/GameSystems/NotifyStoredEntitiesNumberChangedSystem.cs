using System;
using System.Collections.Generic;
using Entitas;

public class NotifyStoredEntitiesNumberChangedSystem : ReactiveSystem<GameEntity> {

    IGroup<UIEntity> _listeners;
    IGroup<GameEntity> _observed;

    public NotifyStoredEntitiesNumberChangedSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.uI.GetGroup(UIMatcher.StoredEntitiesNumberChanged);
        _observed = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Stored).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var l in _listeners.GetEntities())
            {
                l.storedEntitiesNumberChanged.Listener.StoredEntitiesNumberChanged(_observed.count);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.isStored && (entity.isFruit || entity.isVegetable))
            return true;

        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Stored).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));
    }
}
