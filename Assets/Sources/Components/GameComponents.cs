using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PlayerComponent : IComponent
{
    public long Money;
}

[Game, Unique]
public class GameTimeComponent : IComponent
{
    public long Tick;
}