using UnityEngine;

[CreateAssetMenu(fileName ="New GameParameters", menuName ="Fruitastic/Game parameters")]
public class GameParametersData : ScriptableObject {

    public int INITIAL_MONEY = 100;
    public int MAX_STOCK_SLOTS = 8;
    public int MAX_FRUIT_SLOTS = 8;
    public int MAX_VEGETABLES_SLOTS = 8;


}
