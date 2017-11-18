using Entitas;
using System.Collections.Generic;

public class HandleSellVegetableInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleSellVegetableInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money + e.sellVegetable.Entity.vegetable.VegetableData.SeedSellPrice);
            e.sellVegetable.Entity.isDestroy = true;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasSellVegetable)
            return true;

        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.SellVegetable);
    }
}