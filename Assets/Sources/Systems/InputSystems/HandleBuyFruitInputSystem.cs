using System;
using System.Collections.Generic;
using Entitas;

public class HandleBuyFruitInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleBuyFruitInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            if (_contexts.game.playerMoney.Money > e.buyFruit.FruitData.SeedBuyPrice)
            {
                DoBuy(e);
            } else
            {
                DoNotBuy(e);
            }
            e.isDestroy = true;
        }        
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasBuyFruit)
            return true;

        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.BuyFruit);
    }

    private void DoBuy(InputEntity e)
    {
        _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money - e.buyFruit.FruitData.SeedBuyPrice);
        _contexts.game.CreateEntity().AddFruit(e.buyFruit.FruitData);
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
