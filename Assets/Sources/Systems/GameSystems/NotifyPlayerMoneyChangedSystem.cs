using System.Collections.Generic;
using Entitas;

public class NotifyPlayerMoneyChangedSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    public NotifyPlayerMoneyChangedSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var playerMoneyEntity = entities[0];
        var uiListenerEntities = _contexts.uI.GetEntities(UIMatcher.PlayerMoneyChanged);

        foreach (var e in uiListenerEntities)
        {
            e.playerMoneyChanged.Listener.PlayerMoneyChanged(playerMoneyEntity.playerMoney.Money);
        }

        var gameListenerEntities = _contexts.game.GetEntities(GameMatcher.PlayerMoneyChanged);
        foreach (var e in gameListenerEntities)
        {
            e.playerMoneyChanged.Listener.PlayerMoneyChanged(playerMoneyEntity.playerMoney.Money);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasPlayerMoney)
            return true;

        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlayerMoney);
    }
}