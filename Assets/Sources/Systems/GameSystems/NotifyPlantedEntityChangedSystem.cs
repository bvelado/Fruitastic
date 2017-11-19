using Entitas;
using System.Collections.Generic;
using System;

public class NotifyPlantedFruitChangedSystem : ReactiveSystem<GameEntity> {

    IGroup<UIEntity> _listeners;

	public NotifyPlantedFruitChangedSystem(Contexts contexts) : base(contexts.game)
    {
        _listeners = contexts.uI.GetGroup(UIMatcher.PlantedEntityChanged);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var l in _listeners)
            {
                l.plantedEntityChanged.Listener.PlantedEntityChanged(e);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasPlanted && (entity.hasFruit || entity.hasVegetable))
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Planted).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable).AddedOrRemoved());
    }
}
