using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBase : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] int itemId;

    public ItemBase(string itemName, int itemId)
    {
        this.itemName = itemName;
        this.itemId = itemId;
    }

    public int GetItemId() => itemId;

    public string GetItemName() => itemName;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(2, 4)), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Inventory inv = collision.collider.GetComponent<Inventory>();
            inv.AddItem(this, Random.Range(1, 3));
            Destroy(gameObject);
        }
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as ItemBase);
    }

    public bool Equals(ItemBase other)
    {
        return this.itemName == other.itemName;
    }

    public override int GetHashCode()
    {
        return this.itemId;
    }
}

