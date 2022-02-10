using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ItemProvider : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemsList;
    private List<ItemType> _itemTypes = new List<ItemType>();
    private static Dictionary<ItemType, GameObject> _items = new Dictionary<ItemType, GameObject>();

    public void Initialize()
    {
        this._itemsList.ForEach(InitializeLists);
    }

    private void InitializeLists(GameObject item)
    {
        ItemType itemType = item.GetComponent<Item>().type;
        _items.Add(itemType, item);
        this._itemTypes.Add(itemType);
    }

    public static GameObject GetItemOfType(ItemType itemType)
    {
        GameObject item;
        return _items.TryGetValue(itemType, out item) ? item : null;
    }

    public GameObject GetRandomItem(List<ItemType> blockedTypes)
    {
        GameObject item;
        ItemType itemType = this.RandomItemType(blockedTypes);
        return _items.TryGetValue(itemType, out item) ? item : null;
    }

    private ItemType RandomItemType(List<ItemType> blockedTypes)
    {
        Random random = new Random();
        ItemType[] allowedItemTypes = this._itemTypes.Where(blockedType => blockedTypes.Contains(blockedType) == false).ToArray<ItemType>();
        return (ItemType)allowedItemTypes.GetValue(random.Next(allowedItemTypes.Length));
    }
}
