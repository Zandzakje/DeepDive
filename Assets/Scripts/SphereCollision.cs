using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    LootDropped lootDropped;

    void Start()
    {
        lootDropped = this.gameObject.GetComponent<LootDropped>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            lootDropped.CheckDropChance(this.gameObject.transform.position);
        }
    }
}
