using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootCollision : MonoBehaviour
{
    GameObject player;
    LootProperties lootProperties;
    LootEffects lootEffects;

    void Start()
    {
        lootProperties = this.gameObject.GetComponent<LootProperties>();
        lootEffects = this.gameObject.GetComponent<LootEffects>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            player = collider.gameObject;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<LootFadeOut>().TriggerFadeOut();

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

            Destroy(this.gameObject, 1.6f);
            player = null;
        }
    }
}
