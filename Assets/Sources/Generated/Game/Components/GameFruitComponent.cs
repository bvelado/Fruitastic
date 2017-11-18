//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FruitComponent fruit { get { return (FruitComponent)GetComponent(GameComponentsLookup.Fruit); } }
    public bool hasFruit { get { return HasComponent(GameComponentsLookup.Fruit); } }

    public void AddFruit(FruitData newFruitData) {
        var index = GameComponentsLookup.Fruit;
        var component = CreateComponent<FruitComponent>(index);
        component.FruitData = newFruitData;
        AddComponent(index, component);
    }

    public void ReplaceFruit(FruitData newFruitData) {
        var index = GameComponentsLookup.Fruit;
        var component = CreateComponent<FruitComponent>(index);
        component.FruitData = newFruitData;
        ReplaceComponent(index, component);
    }

    public void RemoveFruit() {
        RemoveComponent(GameComponentsLookup.Fruit);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFruit;

    public static Entitas.IMatcher<GameEntity> Fruit {
        get {
            if (_matcherFruit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Fruit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFruit = matcher;
            }

            return _matcherFruit;
        }
    }
}