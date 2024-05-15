using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootEffects : MonoBehaviour
{
    public void TriggerEffectType1(int id)
    {
		switch (id)
        {
            case 0:
                Debug.Log("Example 1 triggered!");
                break;
            default:
                Debug.Log("No effect triggered!");
                break;
        }
    }

    public void TriggerEffectType2(int id)
    {
        switch (id)
        {
            case 0:
                Debug.Log("Example 2 triggered!");
                break;
            default:
                Debug.Log("No effect triggered!");
                break;
        }
    }

    public void TriggerEffectType3(int id)
    {
        switch (id)
        {
            case 0:
                Debug.Log("Example 3 triggered!");
                break;
            default:
                Debug.Log("No effect triggered!");
                break;
        }
    }
}
