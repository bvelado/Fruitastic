using Entitas;

public class StartNewGameSystem : IInitializeSystem {

    Contexts _contexts;

    public StartNewGameSystem(Contexts contexts) : base()
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var playerEntity = _contexts.game.CreateEntity();
        playerEntity.isPlayer = true;
        playerEntity.AddPlayerMoney(100);
    }
    
}
