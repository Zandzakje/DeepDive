using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropped : MonoBehaviour
{
    [Header("Loot dropped settings")]
    public bool specificLootEnabled = false;
    [Tooltip(
        "0 = powerup - health 1 star\n" +
        "1 = powerup - health 2 star\n" +
        "2 = powerup - health 3 star\n" +
        "3 = powerup - mana 1 star\n" +
        "4 = powerup - mana 2 star\n" +
        "5 = powerup - mana 3 star\n" +
        "6 = powerup - stamina 1 star\n" +
        "7 = powerup - stamina 2 star\n" +
        "8 = powerup - stamina 3 star\n" +
        "9 = powerup - attack 1 star\n" +
        "10 = powerup - attack 2 star\n" +
        "11 = powerup - attack 3 star\n" +
        "12 = powerup - defense 1 star\n" +
        "13 = powerup - defense 2 star\n" +
        "14 = powerup - defense 3 star\n" +
        "15 = powerup - speed 1 star\n" +
        "16 = powerup - speed 2 star\n" +
        "17 = powerup - speed 3 star\n" +
        "18 = weapon - sword\n" +
        "19 = weapon - mace\n" +
        "20 = spell - o\n" +
        "21 = spell - p\n" +
        "22 = spell - arrow pointing right\n" +
        "23 = spell - music note\n" +
        "24 = other - key")]
    public int lootId = 0;
    [Tooltip("range 0 - 100")]
    public int dropChance = 0;
    public lootDropTable dropTable;
    [Header("")]
    public LootPrefabs lootPrefabs;
    List<GameObject> drops;

    void Start()
    {
        lootPrefabs = FindAnyObjectByType<LootPrefabs>();
        if (specificLootEnabled)
        {
            drops = new List<GameObject>(lootPrefabs.all);
        }
        else
        {
            switch (dropTable)
            {
                case lootDropTable.Common:
                    drops = new List<GameObject>(lootPrefabs.common);
                    break;
                case lootDropTable.Uncommon:
                    drops = new List<GameObject>(lootPrefabs.uncommon);
                    break;
                case lootDropTable.Rare:
                    drops = new List<GameObject>(lootPrefabs.rare);
                    break;
                case lootDropTable.Epic:
                    drops = new List<GameObject>(lootPrefabs.epic);
                    break;
                case lootDropTable.Legendary:
                    drops = new List<GameObject>(lootPrefabs.legendary);
                    break;
                case lootDropTable.All:
                    drops = new List<GameObject>(lootPrefabs.all);
                    break;
                case lootDropTable.Boss:
                    drops = new List<GameObject>(lootPrefabs.boss);
                    break;
                default:
                    drops = new List<GameObject>(lootPrefabs.all);
                    break;
            }
        }
    }

    void Update()
    {
        
    }

    public enum lootDropTable
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        All,
        Boss
    }

    public void CheckDropChance(Vector3 enemyPosition, bool hasKey)
    {
        if (hasKey)
        {
            Instantiate(drops[24], new Vector3(enemyPosition.x, 1f, enemyPosition.z), Quaternion.identity);
        }
        else
        {
            int random = Random.Range(1, 101);
            if (random <= dropChance)
            {
                if (specificLootEnabled)
                {
                    Instantiate(drops[lootId], new Vector3(enemyPosition.x, 1f, enemyPosition.z), Quaternion.identity);
                }
                else
                {
                    int randomPowerup = Random.Range(0, drops.Count);
                    Instantiate(drops[randomPowerup], new Vector3(enemyPosition.x, 1f, enemyPosition.z), Quaternion.identity);
                }
            }
        }
    }
}
