using Entitas;
using System.Collections.Generic;
using System;

public class NotifyGrowingEntityChangedSystem : ReactiveSystem<GameEntity>
{
    IGroup<UIEntity> _listeners;

    public NotifyGrowingEntityChangedSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.uI.GetGroup(UIMatcher.GrowingEntityChanged);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var l in _listeners)
            {
                l.growingEntityChanged.Listener.GrowingEntityChanged(e);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasPlanted && entity.hasGrowing)
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Planted, GameMatcher.Growing));
    }
}
