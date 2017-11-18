using Entitas;
using System.Collections.Generic;

public class HandleBuyVegetableInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleBuyVegetableInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_contexts.game.playerMoney.Money > e.buyVegetable.VegetableData.SeedBuyPrice)
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
        _contexts.game.CreateEntity().AddVegetable(e.buyVegetable.VegetableData);
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
