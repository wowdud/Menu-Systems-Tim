using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    #region Variables
    //ID
    private int id;
    //Name
    private string name;
    //Description
    private string description;
    //Amount
    private int amount;
    //Value
    private int _value;
    //Stats
    private int stat;
    //Icon
    private Texture2D icon;
    //Mesh
    private GameObject mesh;
    //Type
    private ItemType type;
    //Rarity
    private string rarity;
    #endregion

    #region Properties
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Stat
    {
        get { return stat; }
        set { stat = value; }
    }
    public Texture2D IconName
    {
        get { return icon; }
        set { icon = value; }
    }
    public GameObject MeshName
    {
        get { return mesh; }
        set { mesh = value; }
    }
    public ItemType ItemType
    {
        get { return type; }
        set { type = value; }
    }
    public string Rarity
    {
        get { return rarity; }
        set { rarity = value; }
    }

    #endregion
}

public enum ItemType
{
    Armour,
    Trinket,
    Weapon,
    Scroll,
    Potion,
    Food,
    Ingredient,
    Material,
    Misc,
    Money
}