using Entitas;

public class CleanInputSystem : ICleanupSystem
{
    Contexts _contexts;
    IGroup<InputEntity> _inputs;

    public CleanInputSystem(Contexts contexts) : base()
    {
        _contexts = contexts;
        _inputs = contexts.input.GetGroup(InputMatcher.Destroy);
    }

    public void Cleanup()
    {
        foreach(var input in _inputs.GetEntities())
        {
            if (input.isDestroy)
                input.Destroy();
        }
    }
    
}
