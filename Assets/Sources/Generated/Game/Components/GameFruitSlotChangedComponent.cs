//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FruitSlotChangedComponent fruitSlotChanged { get { return (FruitSlotChangedComponent)GetComponent(GameComponentsLookup.FruitSlotChanged); } }
    public bool hasFruitSlotChanged { get { return HasComponent(GameComponentsLookup.FruitSlotChanged); } }

    public void AddFruitSlotChanged(IFruitSlotChangedListener newListener) {
        var index = GameComponentsLookup.FruitSlotChanged;
        var component = CreateComponent<FruitSlotChangedComponent>(index);
        component.Listener = newListener;
        AddComponent(index, component);
    }

    public void ReplaceFruitSlotChanged(IFruitSlotChangedListener newListener) {
        var index = GameComponentsLookup.FruitSlotChanged;
        var component = CreateComponent<FruitSlotChangedComponent>(index);
        component.Listener = newListener;
        ReplaceComponent(index, component);
    }

    public void RemoveFruitSlotChanged() {
        RemoveComponent(GameComponentsLookup.FruitSlotChanged);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : IFruitSlotChanged { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFruitSlotChanged;

    public static Entitas.IMatcher<GameEntity> FruitSlotChanged {
        get {
            if (_matcherFruitSlotChanged == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FruitSlotChanged);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFruitSlotChanged = matcher;
            }

            return _matcherFruitSlotChanged;
        }
    }
}