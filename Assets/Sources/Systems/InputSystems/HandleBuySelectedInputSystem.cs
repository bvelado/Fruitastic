using System;
using System.Collections.Generic;
using Entitas;

public class HandleBuySelectedInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleBuySelectedInputSystem(Contexts context) : base(context.input)
    {
        _contexts = context;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            if(_contexts.game.isSelected && _contexts.game.hasPlayerMoney)
            {
                if(_contexts.game.selectedEntity.hasBuyable && _contexts.game.selectedEntity.buyable.Price <= _contexts.game.playerMoney.Money)
                {
                    _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money - _contexts.game.selectedEntity.buyable.Price);
                    _contexts.game.selectedEntity.RemoveBuyable();
                    _contexts.game.selectedEntity.isSeed = true;
                    _contexts.game.selectedEntity.isStored = true;
                    _contexts.game.selectedEntity.isSelected = false;
                }
            }
            e.isDestroy = true;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.isBuySelected)
            return true;
        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.BuySelected);
    }
}
