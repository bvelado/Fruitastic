using System.Collections.Generic;
using Entitas;

public class GrowVegetableSystem : ReactiveSystem<GameEntity>
{

    private Contexts _contexts;
    private IGroup<GameEntity> growingEntities;

    public GrowVegetableSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        growingEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vegetable, GameMatcher.Planted, GameMatcher.Seed));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var growingEntity in growingEntities.GetEntities())
            {
                if (growingEntity.hasGrowing)
                {
                    if (growingEntity.growing.Elapsed > growingEntity.vegetable.VegetableData.GrowthDuration)
                    {
                        growingEntity.isSeed = false;
                        growingEntity.RemoveGrowing();

                        growingEntity.isStored = true;
                        growingEntity.RemovePlanted();
                    }
                    else
                    {
                        growingEntity.ReplaceGrowing(growingEntity.growing.Elapsed + 1);
                    }
                }
                else
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
