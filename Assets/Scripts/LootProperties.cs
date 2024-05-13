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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public enum lootRarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }

    public enum lootType
    {
        powerup,
        key,
        weapon,
        spell
    }
}
