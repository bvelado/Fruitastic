using Entitas;

public class StartNewGameSystem : IInitializeSystem
{

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

        //for (int i = 0; i < 8; i++)
        //{
        //    var fruitSlotEntity = _contexts.game.CreateEntity();
        //    fruitSlotEntity.AddFruitSlot(i);
        //}

        //for (int i = 8; i < 16; i++)
        //{
        //    var vegetableSlotEntity = _contexts.game.CreateEntity();
        //    vegetableSlotEntity.AddVegetableSlot(i);
        //}
    }
}