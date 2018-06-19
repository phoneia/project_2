using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour
{
    [SerializeField] List<EquipState> inventoryItem;
    [SerializeField] Transform inventoryParent;
    [SerializeField] InventorySlot[] inventorySlots;

    public event Action<Item> OnInventoryRightClickEvent;


    void Start()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].OnInventoryClickEvent += OnInventoryRightClickEvent;
        }

        SetEquipItems();
    }

    private void OnValidate()
    {
        if (inventoryParent != null)
            inventorySlots = inventoryParent.GetComponentsInChildren<InventorySlot>();

        SetEquipItems();
    }

    private void SetEquipItems()
    {
        int i = 0;
        for (; i < inventoryItem.Count && i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = inventoryItem[i];
        }

        for (; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = null;
        }


    }

    public bool AddItem(EquipState item, out EquipState prevItem)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item == null)
            {
                prevItem = (EquipState)inventorySlots[i].Item;
                inventorySlots[i].Item = item;
                return true;
            }
        }
        prevItem = null;
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item == item)
            {
                inventorySlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int ItemCount(Item item)
    {
        int number = 0;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item == item)
            {
                number++;
            }
        }
        return number;
    }


    public int CulAtt()
    {
        int at = 0;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item != null)
            {
                at += inventorySlots[i].Item.AP;
            }
        }
        return at;
    }

    public int CulDef()
    {
        int dt = 0;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].Item != null)
            {
                dt += inventorySlots[i].Item.DP;
            }
        }
        return dt;
    }
}
