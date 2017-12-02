using System.Collections.Generic;
using Entitas;

public class GrowGrowableSystem : ReactiveSystem<GameEntity> {

    private Contexts _contexts;
    private IGroup<GameEntity> _growingEntities;

    public GrowGrowableSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _growingEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Growing, GameMatcher.Growable, GameMatcher.Seed).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var growingEntity in _growingEntities.GetEntities())
            {
                if (growingEntity.hasGrowing)
                {
                    if (growingEntity.growing.Elapsed > growingEntity.growable.Duration)
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
