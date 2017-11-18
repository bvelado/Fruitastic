using Entitas;

public class GameFeature : Feature {
    
    public GameFeature(Contexts contexts) : base("Game Systems")
    {
        Add(new StartNewGameSystem(contexts));
        Add(new IncrementGameTimeSystem(contexts));
        Add(new NotifyTickChangedListenersSystem(contexts));
        Add(new NotifyPlayerMoneyChangedSystem(contexts));
        Add(new NotifyFruitSlotChangedSystem(contexts));
        Add(new GrowFruitSystem(contexts));
        Add(new ProduceFruitSystem(contexts));
    }

}
