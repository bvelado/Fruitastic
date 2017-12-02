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
            foreach(var producingEntity in producingEntities)
            {
                if (producingEntity.hasProducing)
                {
                    if(producingEntity.producing.Elapsed > producingEntity.productor.Frequency)
                    {
                        producingEntity.ReplaceProducing(0);

                        // TODO
                        // DO GENERATE A NEW FRUIT
                        var producedEntity = _contexts.game.CreateEntity();
                        producedEntity.AddSellable(1000000);
                        producedEntity.RemovePlanted();
                        producedEntity.isStored = true;
                        producedEntity.RemoveGrowable();
                        producedEntity.RemoveProductor();
                        producedEntity.RemoveProducing();

                    } else
                    {
                        producingEntity.ReplaceProducing(producingEntity.producing.Elapsed + 1);
                    }
                } else
                {
                    producingEntity.AddProducing(0);
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
