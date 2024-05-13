using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPrefabs : MonoBehaviour
{
    [HideInInspector] public List<GameObject> all;
    [HideInInspector] public List<GameObject> common;
    [HideInInspector] public List<GameObject> uncommon;
    [HideInInspector] public List<GameObject> rare;
    [HideInInspector] public List<GameObject> epic;
    [HideInInspector] public List<GameObject> legendary;
    [HideInInspector] public List<GameObject> boss;
    [Header("powerups")]
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject mana1;
    [SerializeField] GameObject mana2;
    [SerializeField] GameObject mana3;
    [SerializeField] GameObject stamina1;
    [SerializeField] GameObject stamina2;
    [SerializeField] GameObject stamina3;
    [SerializeField] GameObject attack1;
    [SerializeField] GameObject attack2;
    [SerializeField] GameObject attack3;
    [SerializeField] GameObject defense1;
    [SerializeField] GameObject defense2;
    [SerializeField] GameObject defense3;
    [SerializeField] GameObject speed1;
    [SerializeField] GameObject speed2;
    [SerializeField] GameObject speed3;
    [Header("weapons")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject axe;
    [Header("spells")]
    [SerializeField] GameObject o;
    [SerializeField] GameObject p;
    [SerializeField] GameObject arrowPointingRight;
    [SerializeField] GameObject musicNote;
    [Header("keys")]
    [SerializeField] GameObject key;

    public GameObject GetKey()
    {
        return key;
    }

    private void Awake()
    {
        all = new List<GameObject>
        {
            hp1,
            hp2,
            hp3,
            mana1,
            mana2,
            mana3,
            stamina1,
            stamina2,
            stamina3,
            attack1,
            attack2,
            attack3,
            defense1,
            defense2,
            defense3,
            speed1,
            speed2,
            speed3,
            sword,
            axe,
            o,
            p,
            arrowPointingRight,
            musicNote,
            key
        };
        
        common = new List<GameObject>();
        uncommon = new List<GameObject>();
        rare = new List<GameObject>();
        epic = new List<GameObject>();
        legendary = new List<GameObject>();

        foreach(GameObject loot in all)
        {
            switch(loot.GetComponent<LootProperties>().rarity)
            {
                case LootProperties.lootRarity.common:
                    common.Add(loot);
                    break;
                case LootProperties.lootRarity.uncommon:
                    uncommon.Add(loot);
                    break;
                case LootProperties.lootRarity.rare:
                    rare.Add(loot);
                    break;
                case LootProperties.lootRarity.epic:
                    epic.Add(loot);
                    boss.Add(loot);
                    break;
                case LootProperties.lootRarity.legendary:
                    if(loot.GetComponent<LootProperties>().type != LootProperties.lootType.key) 
                    {
                        legendary.Add(loot);
                        boss.Add(loot);
                    }
                    break;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
