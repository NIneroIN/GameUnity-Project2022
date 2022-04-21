using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    protected List<InventoryItem> _items = new List<InventoryItem>();

    public void AddItem(ItemBase _item, int _count)
    {
        List<ItemBase> _itemBases = new List<ItemBase>();
        int index = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            _itemBases.Add(_items[i].GetItemBase());
            if (_items[i].GetItemBase() == _item)
            {
                index = i;
            }
        }

        
        if (_itemBases.Contains(_item))
        {
            _items[index].AddCount(_count); // Добавление "count" в новый предмет
        }
        else
        {
            _items.Add(new InventoryItem(_item, _count));
        }
    }
}

public class InventoryItem
{
    ItemBase _item;
    int _count;

    public InventoryItem(ItemBase _item, int count)
    {
        this._item = _item;
        this._count = count;
    }

    public ItemBase GetItemBase() => _item;

    public void AddCount(int count) => _count += count;
}
