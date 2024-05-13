using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootCollision : MonoBehaviour
{
    GameObject currentlyTouching;
    LootProperties lootProperties;
    LootEffects lootEffects;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "loot")
        {
            currentlyTouching = collider.gameObject;
            currentlyTouching.GetComponent<SphereCollider>().enabled = false;
            currentlyTouching.GetComponent<LootFadeOut>().TriggerFadeOut();
            lootProperties = currentlyTouching.GetComponent<LootProperties>();
            lootEffects = currentlyTouching.GetComponent<LootEffects>();

            switch (lootProperties.type)
            {
                case LootProperties.lootType.powerup:
                    lootEffects.TriggerEffectPowerup(lootProperties.effectId);
                    break;
                case LootProperties.lootType.key:
                    break;
                case LootProperties.lootType.weapon:
                    lootEffects.TriggerEffectWeapon(lootProperties.effectId);
                    break;
                case LootProperties.lootType.spell:
                    lootEffects.TriggerEffectSpell(lootProperties.effectId);
                    break;
            }

            Destroy(currentlyTouching, 1.6f);
            currentlyTouching = null;
        }
    }
}
