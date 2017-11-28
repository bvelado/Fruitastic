using Entitas;
using System.Collections.Generic;

public class HandleSellFruitInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleSellFruitInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money + e.sellFruit.Entity.sellable.Price);
            e.sellFruit.Entity.isDestroy = true;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasSellFruit)
            return true;

        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.SellFruit);
    }
}