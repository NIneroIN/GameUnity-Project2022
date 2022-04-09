using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // ����, �������� ��� �������� � ����
}

[System.Serializable] // ���� ������ � ��������� ������� � ������ ����� Unity

public class Item
{
    public int id; // ID ��������
    public string name; // �������� ��������
    public Sprite img; // ����������� ��������
}
