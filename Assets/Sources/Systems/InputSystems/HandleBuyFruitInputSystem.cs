using System;
using System.Collections.Generic;
using Entitas;

public class HandleBuyFruitInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;
    IGroup<GameEntity> _observed;

    public HandleBuyFruitInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _observed = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Stored).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            if (_contexts.game.playerMoney.Money > e.buyFruit.FruitData.SeedBuyPrice &&
                _observed.count < GameParametersManager.Instance.Parameters.MAX_STOCK_SLOTS)
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
        var fruitEntity = _contexts.game.CreateEntity();
        fruitEntity.AddFruit(e.buyFruit.FruitData);
        fruitEntity.isStored = true;
        _contexts.game.isSelected = false;
        fruitEntity.isSelected = true;
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
