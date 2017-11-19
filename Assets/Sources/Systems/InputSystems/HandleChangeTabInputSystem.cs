using System;
using System.Collections.Generic;
using Entitas;

public class HandleChangeTabInputSystem : ReactiveSystem<InputEntity>
{
    public HandleChangeTabInputSystem(Contexts contexts) : base(contexts.input) { }

    protected override void Execute(List<InputEntity> entities)
    {
        throw new NotImplementedException();
    }

    protected override bool Filter(InputEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return null;
        //return context.CreateCollector(InputMatcher.Chan)
    }
}
