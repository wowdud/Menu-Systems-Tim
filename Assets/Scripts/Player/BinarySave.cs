using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BinarySave
{
    //public string playerName;
    public int level;
    public float maxHealth, maxMana, maxStamina;
    public float currHealth, currMana, currStamina;
    public float pX, pY, pZ, rX, rY, rZ, rW;
    public BinarySave (PlayerHandler player)
    {
        //playerName = player.name;
        level = 0;
        maxHealth = player.attributes[0].maxValue;
        maxMana = player.attributes[1].maxValue;
        maxStamina = player.attributes[2].maxValue;
        currHealth = player.attributes[0].currentValue;
        currMana = player.attributes[1].currentValue;
        currStamina = player.attributes[2].currentValue;
        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;
        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }
}
