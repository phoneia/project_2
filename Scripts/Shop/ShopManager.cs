using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Shop shop;
    [SerializeField] Inventory inventory;

    [SerializeField] private CharacterStates state;
    [SerializeField] private float cheakRadius = 5;
    [SerializeField] private LayerMask cheakLayer;

    [SerializeField] private GameObject shopCon;

    private void Awake()
    {
        shop.OnItemRightClickEvent += EquipFromInventory;
        inventory.OnInventoryRightClickEvent += IventoruFromBreak;
    }

    void Start()
    {
        shopCon = transform.Find("Shop Canvas/ShopUI").gameObject;
    }

    void Update()
    {
        Collider[] collier = Physics.OverlapSphere(transform.position, cheakRadius, cheakLayer);

        foreach (Collider player in collier)
        {
            if (player.tag == "Player")
            {
                state = player.GetComponent<CharacterStates>();

            }
        }
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquipState)
        {
            Equip((EquipState)item);
        }
    }

    private void IventoruFromBreak(Item item)
    {
        if (item is EquipState)
        {
            Unequip((EquipState)item);
        }
    }

    public void Equip(EquipState item)
    {

        if (state.CurrentGold < item.buyCost)
            return;

        EquipState prevItem;
        if (inventory.AddItem(item, out prevItem))
        {
            if (prevItem != null)
            {

                //shop.AddItem(prevItem);
            }
            state.CurrentGold -= item.buyCost;
        }
        else
        {
            //shop.AddItem(item);
        }


    }

    public void Unequip(EquipState item)
    {
        if (!shopCon.activeSelf)
            return;

        state.CurrentGold += item.sellCost;
        //// 돈 증가
        //if(!inventory.IsFull() && inventory.RemoveItem(item))
        //{
        //    //shop.AddItem(item);

        //}
        inventory.RemoveItem(item);
    }

}


