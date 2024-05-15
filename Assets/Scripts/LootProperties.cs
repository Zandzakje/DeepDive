using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LootProperties : MonoBehaviour
{
    [Header("Loot properties")]
    public int lootId = 0;
    public int effectId = 0;
    public float statModifier = 0f;
    public lootRarity rarity;
    public lootType type;

    public enum lootRarity
    {
        rarity1,
        rarity2,
        rarity3
    }

    public enum lootType
    {
        type1,
        type2,
        type3
    }
}
