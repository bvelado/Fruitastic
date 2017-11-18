using Entitas;
using System.Collections.Generic;

public class HandleBuyFruitSlotInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;

    public HandleBuyFruitSlotInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_contexts.game.playerMoney.Money >= _contexts.game.GetFruitSlotEntityBySlotIndex(e.buyFruitSlot.Index).buyable.Price)
            {
                DoBuy(e);
            }
            else
            {
                DoNotBuy(e);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasBuyFruitSlot)
            return true;

        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.BuyFruitSlot);
    }

    private void DoBuy(InputEntity e)
    {
        var fruitSlotEntity = _contexts.game.GetFruitSlotEntityBySlotIndex(e.buyFruitSlot.Index);
        _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money - fruitSlotEntity.buyable.Price);
        fruitSlotEntity.isLocked = false;
        fruitSlotEntity.RemoveBuyable();
    }

    private void DoNotBuy(InputEntity e)
    {
        // Pas possible
    }
}
