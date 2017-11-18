using System;
using Entitas;

public class IncrementGameTimeSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts contexts;
    
    public IncrementGameTimeSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {
        contexts.game.SetGameTime(0);
    }

    public void Execute()
    {
        contexts.game.ReplaceGameTime(contexts.game.gameTime.Tick + 1);
    }
}