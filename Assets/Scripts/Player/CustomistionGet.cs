using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomistionGet : MonoBehaviour
{
    public Renderer character, helm;
    void Start()
    {
        Load();
        SceneChangeScript.isNewCharacter = false;
    }

    void Load()
    {
        SetTexture("Skin", PlayerPrefs.GetInt("skinIndex"));
        SetTexture("Hair", PlayerPrefs.GetInt("hairIndex"));
        SetTexture("Mouth", PlayerPrefs.GetInt("mouthIndex"));
        SetTexture("Eyes", PlayerPrefs.GetInt("eyesIndex"));
        SetTexture("Clothes", PlayerPrefs.GetInt("clothesIndex"));
        SetTexture("Armour", PlayerPrefs.GetInt("armourIndex"));
        SetTexture("Helm", PlayerPrefs.GetInt("helmIndex"));
    }

    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int materialIndex = 0;
        Renderer rend = new Renderer();
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index)as Texture2D;
                materialIndex = 1;
                rend = character;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                materialIndex = 2;
                rend = character;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                materialIndex = 3;
                rend = character;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                materialIndex = 4;
                rend = character;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                materialIndex = 5;
                rend = character;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                materialIndex = 6;
                rend = character;
                break;
            case "Helm":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                materialIndex = 1;
                rend = helm;
                break;
        }
        Material[] mats = rend.materials;
        mats[materialIndex].mainTexture = texture;
        rend.materials = mats;
    }
}
