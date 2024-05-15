using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LootFadeOut : MonoBehaviour
{
    float alpha;
    [HideInInspector]
    public bool fadeOut = false;
    public float fadeOutSpeedInner;
    public float fadeOutSpeedOuter;
    public float fadeOutSpeedEffects;
    public float fadeOutSpeedLights;

    GameObject inner;
    GameObject outer;
    GameObject effects;
    List<Material> materials = new List<Material>();
    List<Light> lights = new List<Light>();

    void Start()
    {
        //fadeOutSpeedInner = 0.7f;
        //fadeOutSpeedOuter = 0.5f;
        //fadeOutSpeedEffects = 0.7f;
        //fadeOutSpeedLights = 1.4f;

        inner = gameObject.transform.GetChild(0).gameObject;
        outer = gameObject.transform.GetChild(1).gameObject;
        effects = gameObject.transform.GetChild(2).gameObject;

        if (inner.transform.childCount > 0)
        {
            EditMaterialPropertiesInner(inner);
        }
        if (outer.transform.childCount > 0)
        {
            EditMaterialPropertiesOuter(outer);
        }
        if (effects.transform.childCount > 0)
        {
            EditMaterialPropertiesEffects(effects);
        }
    }

    void Update()
    {
        if (fadeOut)
        {
            StartFadeOutMaterials();
            StartFadeOutLights();
        }
    }

    void EditMaterialPropertiesInner(GameObject inner)
    {
        foreach(Transform innerObject in inner.transform)
        {
            foreach (Transform child in innerObject.transform)
            {
                if(child.gameObject.GetComponent<Renderer>() != null)
                {
                    foreach (Material m in child.gameObject.GetComponent<Renderer>().materials)
                    {
                        m.EnableKeyword("_ALPHABLEND_ON");
                        materials.Add(m);
                    }
                }
            }
        }
    }

    void EditMaterialPropertiesOuter(GameObject outer)
    {
        foreach (Transform child in outer.transform)
        {
            foreach (Material m in child.gameObject.GetComponent<Renderer>().materials)
            {
                m.EnableKeyword("_ALPHABLEND_ON");
                materials.Add(m);
            }
        }
    }

    void EditMaterialPropertiesEffects(GameObject effects)
    {
        foreach (Transform child in effects.transform)
        {
            if(child.gameObject.GetComponent<Renderer>() != null)
            {
                foreach (Material m in child.gameObject.GetComponent<Renderer>().materials)
                {
                    m.EnableKeyword("_ALPHABLEND_ON");
                    materials.Add(m);
                }
            }
            else
            {
                lights.Add(child.gameObject.GetComponent<Light>());
            }
        }
    }

    public void TriggerFadeOut()
    {
        fadeOut = true;
    }

    void StartFadeOutMaterials()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            alpha = materials[i].color.a;

            if (materials[i].name.Contains("inner_"))
            {
                alpha -= fadeOutSpeedInner * Time.deltaTime;
            }
            else if(materials[i].name.Contains("outer_"))
            {
                alpha -= fadeOutSpeedOuter * Time.deltaTime;
            }
            else if (materials[i].name.Contains("Default") || materials[i].name.Contains("sparkle_"))
            {
                alpha -= fadeOutSpeedEffects * Time.deltaTime;
            }

            if (alpha <= 0f)
            {
                materials[i].color = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, 0f);
            }
            else
            {
                materials[i].color = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, alpha);
            }
        }

        if (alpha <= 0f)
        {
            fadeOut = false;
        }
    }

    void StartFadeOutLights()
    {
        for (int i = 0; i < lights.Count; i++)
        {

            if (lights[i].intensity > 0f)
            {
                lights[i].intensity -= fadeOutSpeedLights * Time.deltaTime;
            }
            else
            {
                lights[i].intensity = 0f;
            }
        }
    }
}
