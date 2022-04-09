using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Лист, хранящий все предметы в игре
}

[System.Serializable] // Дает доступ к элементам скрипта с любого места Unity

public class Item
{
    public int id; // ID предмета
    public string name; // Название предмета
    public Sprite img; // Изображение предмета
}
