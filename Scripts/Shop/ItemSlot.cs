using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Image image;

    public event Action<Item> OnShopClickEvent;

    private Item item;

    public Item Item
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

    public void OnPointerClick(PointerEventData eventData)
    {


        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            // Debug.Log("Item: " + Item);
            // Debug.Log("OnShopClickEvent: " + OnShopClickEvent);

            if (Item != null && OnShopClickEvent != null)
            {
                // Debug.Log("bb");

                OnShopClickEvent(Item);
            }

        }
    }

    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }

}
