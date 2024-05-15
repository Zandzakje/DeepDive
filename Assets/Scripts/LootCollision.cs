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

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            player = collider.gameObject;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<LootFadeOut>().TriggerFadeOut();

            switch (lootProperties.type)
            {
                case LootProperties.lootType.type1:
                    lootEffects.TriggerEffectType1(lootProperties.effectId);
                    break;
                case LootProperties.lootType.type2:
                    lootEffects.TriggerEffectType2(lootProperties.effectId);
                    break;
                case LootProperties.lootType.type3:
                    lootEffects.TriggerEffectType3(lootProperties.effectId);
                    break;
            }

            Destroy(this.gameObject, 1.6f);
            player = null;
        }
    }
}
