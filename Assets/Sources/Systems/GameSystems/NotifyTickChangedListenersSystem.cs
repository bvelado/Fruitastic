using System.Collections.Generic;
using Entitas;

public class NotifyTickChangedListenersSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    public NotifyTickChangedListenersSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var tickEntity = entities[0];
        var uiListenerEntities = _contexts.uI.GetEntities(UIMatcher.TickChanged);

        foreach(var e in uiListenerEntities)
        {
            e.tickChanged.Listener.TickChanged(tickEntity.gameTime.Tick);
        }

        var gameListenerEntities = _contexts.game.GetEntities(GameMatcher.TickChanged);
        foreach(var e in gameListenerEntities)
        {
            e.tickChanged.Listener.TickChanged(tickEntity.gameTime.Tick);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasGameTime)
            return true;

        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameTime);
    }
}
