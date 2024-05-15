using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPrefabs : MonoBehaviour
{
    [HideInInspector] public List<GameObject> all;
    [HideInInspector] public List<GameObject> rarity1;
    [HideInInspector] public List<GameObject> rarity2;
    [HideInInspector] public List<GameObject> rarity3;
    [Header("examples")]
    [SerializeField] GameObject baseLootObject;
    [SerializeField] GameObject example1;
    [SerializeField] GameObject example2;
    [SerializeField] GameObject example3;

    void Awake()
    {
        all = new List<GameObject>
        {
            baseLootObject,
            example1,
            example2,
            example3
        };
        
        rarity1 = new List<GameObject>();
        rarity2 = new List<GameObject>();
        rarity3 = new List<GameObject>();

        foreach(GameObject loot in all)
        {
            switch(loot.GetComponent<LootProperties>().rarity)
            {
                case LootProperties.lootRarity.rarity1:
                    rarity1.Add(loot);
                    break;
                case LootProperties.lootRarity.rarity2:
                    rarity2.Add(loot);
                    break;
                case LootProperties.lootRarity.rarity3:
                    rarity3.Add(loot);
                    break;
            }
        }
    }
}
