using UnityEngine;

[CreateAssetMenu(fileName = "New FruitData", menuName = "Fruitastic/FruitData")]
public class FruitData : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public int SeedBuyPrice;
    public int SeedSellPrice;
    public int FruitSellPrice;
    public long GrowthDuration;
    public long Frequency;
    public Sprite FruitIcon;
    public Sprite SeedIcon;
}
