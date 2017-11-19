using Entitas;
using System.Collections.Generic;

public class ProduceFruitSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> producingEntities;

    public ProduceFruitSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        producingEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted).NoneOf(GameMatcher.Seed, GameMatcher.Growing));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var productingEntity in producingEntities)
            {
                if (productingEntity.hasProducing)
                {
                    if(productingEntity.producing.Elapsed > productingEntity.fruit.FruitData.Frequency)
                    {
                        productingEntity.ReplaceProducing(0);

                        // TODO
                        // DO GENERATE A NEW FRUIT
                        _contexts.game.ReplacePlayerMoney(_contexts.game.playerMoney.Money + productingEntity.fruit.FruitData.FruitSellPrice);

                    } else
                    {
                        productingEntity.ReplaceProducing(productingEntity.producing.Elapsed + 1);
                    }
                } else
                {
                    productingEntity.AddProducing(0);
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasGameTime)
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameTime);
    }
}
