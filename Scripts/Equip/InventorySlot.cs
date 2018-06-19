using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image image;

    public event Action<Item> OnInventoryClickEvent;

    private EquipState item;

    public EquipState Item
    {
        get { return item; }
        set
        {
            item = value;

            if (item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = item.icon;
                image.enabled = true;
            }

        }
    }

    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (Item != null && OnInventoryClickEvent != null)
                OnInventoryClickEvent(Item);
        }
    }
}
