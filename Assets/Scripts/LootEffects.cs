using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootEffects : MonoBehaviour
{
    GameObject character;
	void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    public void TriggerEffectPowerup(int id)
    {
		switch (id)
        {
            case 0: // Current HP up
                break;
            case 1: // Current HP to max HP
                break;
            case 2: // Current mana up
                break;
            case 3: // Current mana to max mana
                break;
            case 4: // Stamina regeneration up
                break;
            case 5: // Attack up
                break;
            case 6: // Defense up
                break;
            case 7: // Movement speed up
                break;
            default:
                Debug.Log("No buff triggered!");
                break;
        }
    }

    public void TriggerEffectWeapon(int id)
    {
        switch (id)
        {
            case 0: // sword
                break;
            case 1: // axe
                break;
        }
    }

    public void TriggerEffectSpell(int id)
    {
        switch (id)
        {
            case 0: // o
                break;
            case 1: // p
                break;
            case 2: // arrow pointing right
                break;
            case 3: // music note
                break;
        }
    }
}
