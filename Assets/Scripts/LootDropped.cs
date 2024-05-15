using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropped : MonoBehaviour
{
    [Header("Loot dropped settings")]
    public bool specificLootEnabled = false;
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
                case lootDropTable.rarity1:
                    drops = new List<GameObject>(lootPrefabs.rarity1);
                    break;
                case lootDropTable.rarity2:
                    drops = new List<GameObject>(lootPrefabs.rarity2);
                    break;
                case lootDropTable.rarity3:
                    drops = new List<GameObject>(lootPrefabs.rarity3);
                    break;
                case lootDropTable.all:
                    drops = new List<GameObject>(lootPrefabs.all);
                    break;
                default:
                    drops = new List<GameObject>(lootPrefabs.all);
                    break;
            }
        }
    }

    public enum lootDropTable
    {
        rarity1,
        rarity2,
        rarity3,
        all
    }

    public void CheckDropChance(Vector3 testObject)
    {
        int random = Random.Range(1, 101);
        if (random <= dropChance)
        {
            if (specificLootEnabled)
            {
                Instantiate(drops[lootId], new Vector3(testObject.x, 1f, testObject.z), Quaternion.identity);
            }
            else
            {
                int randomPowerup = Random.Range(0, drops.Count);
                Instantiate(drops[randomPowerup], new Vector3(testObject.x, 1f, testObject.z), Quaternion.identity);
            }
        }
    }
}
