using Entitas;

public class GameFeature : Feature {
    
    public GameFeature(Contexts contexts) : base("Game Systems")
    {
        Add(new IncrementGameTimeSystem(contexts));
        Add(new NotifyTickChangedListenersSystem(contexts));
    }

}
