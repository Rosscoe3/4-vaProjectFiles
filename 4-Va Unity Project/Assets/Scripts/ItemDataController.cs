using System;
using System.Linq;
using UnityEngine;

public class ItemDataController : MonoBehaviour
{
    [SerializeField]
    private ItemData[] items;

    public ItemData Get(string key)
    {
        return items.FirstOrDefault(L => L.Key == key);
    }
}

[Serializable]
public struct ItemData
{
    public string Key;
    public string Name;
    public string Description;
    public int Damage;
    //public Sprite sprite; 
}