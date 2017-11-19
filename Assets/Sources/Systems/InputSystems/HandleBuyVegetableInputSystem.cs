using Entitas;
using System.Collections.Generic;

public class HandleBuyVegetableInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;
    IGroup<GameEntity> _observed;

    public HandleBuyVegetableInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _observed = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Stored).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_contexts.game.playerMoney.Money > e.buyVegetable.VegetableData.SeedBuyPrice && 
                _observed.count < GameParametersManager.Instance.Parameters.MAX_STOCK_SLOTS)
            {
                DoBuy(e);
            }
            else
            {
                DoNotBuy(e);
            }
            e.isDestroy = true;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasBuyVegetable)
            return true;

        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.BuyVegetable);
    }

    private void DoBuy(InputEntity e)
    {
        _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money - e.buyVegetable.VegetableData.SeedBuyPrice);
        var v = _contexts.game.CreateEntity();
        v.AddVegetable(e.buyVegetable.VegetableData);
        v.isStored = true;
        _contexts.game.isSelected = false;
        v.isSelected = true;
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
