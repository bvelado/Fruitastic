using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New VegetableData", menuName = "Fruitastic/VegetableData")]
public class VegetableData : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public int SeedBuyPrice;
    public int SeedSellPrice;
    public int VegetableSellPrice;
    public long GrowthDuration;
    public Sprite VegetableIcon;
    public Sprite SeedIcon;
}
