using System.Collections.Generic;
using Entitas;

public class GrowFruitSystem : ReactiveSystem<GameEntity> {

    private Contexts _contexts;
    private IGroup<GameEntity> growingEntities;

    public GrowFruitSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        growingEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted, GameMatcher.Seed));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var growingEntity in growingEntities.GetEntities())
            {
                if (growingEntity.hasGrowing)
                {
                    if (growingEntity.growing.Elapsed > growingEntity.fruit.FruitData.GrowthDuration)
                    {
                        growingEntity.isSeed = false;
                        growingEntity.RemoveGrowing();
                    }
                    else
                    {
                        growingEntity.ReplaceGrowing(growingEntity.growing.Elapsed + 1);
                    }
                } else
                {
                    growingEntity.AddGrowing(0);
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
