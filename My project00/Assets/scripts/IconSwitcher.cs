using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitcher : MonoBehaviour
{
    [SerializeField] private List<SwitchableItem> switchableItems;

    private void Awake()
    {
       for (int i = 0; i < switchableItems.Count; i++)
       {
            int switchId = i;
            switchableItems[i].switchButton.onClick.AddListener(() => SwitchIcon(switchId));
       }



    }
    private void SwitchIcon(int switchID)
    {
        for (int i = 0; i < switchableItems.Count; i++)
        {
            
           
           switchableItems[i].icon.gameObject.SetActive(i == switchID);
            
        }
    }
}

[Serializable]
public class SwitchableItem
{
    [field:SerializeField] public Button switchButton { get; private set; }
    [field:SerializeField] public GameObject icon {  get; private set; }
}
    