using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card/CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite icon;
    public int time;
    public int energy;
    public Sprite rewardIcon;
    
    public Color backgroundColor;
    
    [Range(0f, 1f)]
    public float spawnChance = 1f;
}
