using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CCMapping : MonoBehaviour
{
    [SerializeField] private GameObject closedCaption;
    private bool mappingMod;

    public void MappingModToggle()
    {
        if (mappingMod == false)
        {
            closedCaption.SetActive(true);
            mappingMod = true;
        }
        else
        {
            closedCaption.SetActive(false);
            mappingMod = false;
        }
    }
}
