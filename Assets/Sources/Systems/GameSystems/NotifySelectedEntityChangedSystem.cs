using Entitas;
using System.Collections.Generic;

public class NotifySelectedEntityChangedSystem : ReactiveSystem<GameEntity>
{
    IGroup<UIEntity> _listeners;

    public NotifySelectedEntityChangedSystem(Contexts contexts) : base(contexts.game)
    {
        _listeners = contexts.uI.GetGroup(UIMatcher.SelectedEntityChanged);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            foreach(var l in _listeners.GetEntities())
            {
                l.selectedEntityChanged.Listener.SelectedEntityChanged(e);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.isSelected && (entity.isFruit || entity.isVegetable))
            return true;
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Selected).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable).AddedOrRemoved());
    }
}
