using Entitas;

public class FruitasticFeature : Feature {
    
    public FruitasticFeature(Contexts contexts) : base("Fruitastic systems")
    {
        Add(new GameFeature(contexts));
    }

}
