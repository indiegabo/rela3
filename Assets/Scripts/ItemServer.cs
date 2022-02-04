using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemServer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemsList;
    private static Dictionary<ItemType, GameObject> _items = new Dictionary<ItemType, GameObject>();

    private void Awake()
    {
        this._itemsList.ForEach(AddItemIntoDictionary);
    }

    private void AddItemIntoDictionary(GameObject item)
    {
        ItemType itemType = item.GetComponent<Item>().type;
        _items.Add(itemType, item);
    }

    public static GameObject GetItemOfType(ItemType itemType)
    {
        GameObject item;
        return _items.TryGetValue(itemType, out item) ? item : null;
    }
}