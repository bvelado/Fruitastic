public interface IFruitSlotChangedListener {

    int Index { get; }
    void FruitSlotChanged(GameEntity e);

}
