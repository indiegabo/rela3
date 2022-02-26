using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;
namespace IndieGabo.Rela3.Items
{
    public class ItemProvider : MonoBehaviour
    {
        [SerializeField] private List<Item> _itemsList;
        private List<ItemType> _itemTypes = new List<ItemType>();
        private static Dictionary<ItemType, Item> _items = new Dictionary<ItemType, Item>();
        private Random _random = new Random();

        public void Initialize()
        {
            this._itemsList.ForEach(InitializeLists);
        }

        private void InitializeLists(Item item)
        {
            ItemType itemType = item.GetComponent<Item>().type;
            _items.Add(itemType, item);
            this._itemTypes.Add(itemType);
        }

        public static Item GetItemOfType(ItemType itemType)
        {
            Item item;
            return _items.TryGetValue(itemType, out item) ? item : null;
        }

        public InstantiableItem GetRandomItem()
        {
            ItemType itemType = this.RandomItemType();
            Item item = _items.TryGetValue(itemType, out item) ? item : null;

            return new InstantiableItem(item, itemType);
        }

        public InstantiableItem GetRandomItem(List<ItemType> blockedTypes)
        {
            ItemType itemType = this.RandomItemType(blockedTypes);
            Item item = _items.TryGetValue(itemType, out item) ? item : null;

            return new InstantiableItem(item, itemType);
        }

        private ItemType RandomItemType()
        {
            return this._itemTypes.ToArray()[this._random.Next(this._itemTypes.Count)];
        }

        private ItemType RandomItemType(List<ItemType> blockedTypes)
        {
            Random random = new Random();
            ItemType[] allowedItemTypes = this._itemTypes.Where(blockedType => blockedTypes.Contains(blockedType) == false).ToArray<ItemType>();
            return (ItemType)allowedItemTypes.GetValue(this._random.Next(allowedItemTypes.Length));
        }
    }

    public class InstantiableItem
    {
        public Item itemPrefab { get; private set; }
        public ItemType itemType { get; private set; }

        public InstantiableItem(Item itemPrefab, ItemType itemType)
        {
            this.itemPrefab = itemPrefab;
            this.itemType = itemType;
        }
    }
}
