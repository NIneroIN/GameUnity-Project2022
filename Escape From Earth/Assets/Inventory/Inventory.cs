using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Дает возможность перемещать предметы

public class Inventory : MonoBehaviour
{
    public DataBase data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjectShow;

    public GameObject inventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offSet;

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = id;
        items[id].count = count;
        items[id].itemGameObject.GetComponent<Image>().sprite = item.img;
        if (count > 0 && item.id != 0)
        {
            items[id].itemGameObject.GetComponent<Text>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponent<Text>().text = "";
        }
    }

    public void AddItemInventory(int id, ItemInventory ii)
    {
        items[id].id = ii.id;
        items[id].count = ii.count;
        items[id].itemGameObject.GetComponent<Image>().sprite = data.items[ii.id].img;
        if (ii.count > 0 && ii.id != 0)
        {
            items[id].itemGameObject.GetComponent<Text>().text = ii.count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponent<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjectShow, inventoryMainObject.transform) as GameObject; // создание нового предмета в стаке

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObject = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = Vector3.zero;
            rt.localScale = Vector3.one;
            newItem.GetComponent<RectTransform>().localScale = Vector3.one;

            Button tempButton = newItem.GetComponent<Button>(); // перемещение предметов зажатием

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObject.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObject.GetComponentInChildren<Text>().text = "";
            }
            items[i].itemGameObject.GetComponentInChildren<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0);
            movingObject.gameObject.SetActive(false);
        }
        else
        {
            AddItemInventory(currentID, items[int.Parse(es.currentSelectedGameObject.name)]);

            AddItemInventory(int.Parse(es.currentSelectedGameObject.name), currentItem);
            currentID = -1;
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offSet;
        pos.z = inventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory copy = new ItemInventory();
        copy.id = old.id;
        copy.itemGameObject = old.itemGameObject;
        copy.count = old.count;
        return copy;
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id; // ID предмета
    public GameObject itemGameObject; // Игровой предмет для ячейки инвенторя

    public int count; // Количество определенного предмета
}
