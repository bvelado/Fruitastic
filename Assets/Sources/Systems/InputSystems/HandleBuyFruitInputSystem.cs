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
        fruitEntity.isFruit = true;
        fruitEntity.isStored = true;
        fruitEntity.isSeed = true;
        fruitEntity.AddGrowable(e.buyFruit.FruitData.GrowthDuration);
        fruitEntity.AddProductor(e.buyFruit.FruitData.Frequency);
        fruitEntity.AddTitle(e.buyFruit.FruitData.Name);
        fruitEntity.AddDescription(e.buyFruit.FruitData.Description);
        fruitEntity.AddIcon(e.buyFruit.FruitData.SeedIcon);
        _contexts.game.isSelected = false;
        fruitEntity.isSelected = true;
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
