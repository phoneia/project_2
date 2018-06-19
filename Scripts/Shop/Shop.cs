using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Item> shopItem;
    [SerializeField] Transform parent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemRightClickEvent;

    void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnShopClickEvent += OnItemRightClickEvent;
        }

        SetShopItems();
    }

    private void OnValidate()
    {
        if (parent != null)
            itemSlots = parent.GetComponentsInChildren<ItemSlot>();

        SetShopItems();
    }


    private void SetShopItems()
    {
        int i = 0;
        for (; i < shopItem.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = shopItem[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    // 같은 아이템이 있으면 리턴 하는것
    // 같은 아이템 중복이 가능 하므로 이것은 필요 없을수도
    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                //itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int ItemCount(Item item)
    {
        int number = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                number++;
            }
        }
        return number;
    }


}
