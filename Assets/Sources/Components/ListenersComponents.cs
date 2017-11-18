using Entitas;

[Game, UI]
public class TickChangedComponent : IComponent
{
    public ITickChangedListener Listener;
}