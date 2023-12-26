using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	[SerializeField] List<PlayerItem> inventory = null;

    public PlayerItem this[int index] => inventory[index];
    public PlayerItem GetItem(int index) => inventory[index];

    /// <summary>
    /// change item at current index of inventory
    /// </summary>
    public void SetItem(int index, PlayerItem item)
    {
        if(inventory.Count <= index)
            return;

        inventory[index] = item;
    }

    /// <summary>
    /// add item into end of inventory
    /// </summary>
    /// <returns>index that point added item</returns>
    public int AddItem(PlayerItem item)
    {
        inventory.Add(item);
        return (inventory.Count - 1);
    }

    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.L))
    //         GetItem(0).Operate(gameObject);
    // }
}
