using Entitas;
using System.Collections.Generic;

public class NotifyProducingEntityChangedSystem : ReactiveSystem<GameEntity>
{
    IGroup<UIEntity> _listeners;

    public NotifyProducingEntityChangedSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.uI.GetGroup(UIMatcher.ProducingEntityChanged);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var l in _listeners)
            {
                l.producingEntityChanged.Listener.ProducingEntityChanged(e);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasPlanted && entity.hasProducing)
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Planted, GameMatcher.Producing));
    }
}
