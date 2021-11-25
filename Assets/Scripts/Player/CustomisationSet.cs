using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationSet : Stats
{
    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>(); //1
    public List<Texture2D> mouth = new List<Texture2D>(); //2
    public List<Texture2D> eyes = new List<Texture2D>(); //3
    public List<Texture2D> hair = new List<Texture2D>(); //4
    public List<Texture2D> clothes = new List<Texture2D>();//5
    public List<Texture2D> armour = new List<Texture2D>(); //6
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int mouthIndex, eyesIndex, hairIndex, clothesIndex, armourIndex, helmIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    // public MeshRenderer characterMesh;
    public Renderer character;
    public Renderer helm;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int mouthMax, eyesMax, hairMax, clothesMax, armourMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string characterName;
    public string[] materialNames = new string[7] { "Skin","Mouth","Eyes","Hair","Clothes","Armour","Helm"};
    public string[] attributeName = new string[3] { "Health", "Stamina", "Mana"};
    public string[] statName = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"};

    public Dropdown classDrop;
    public Dropdown raceDrop;

    //public Button statUp;
    //public Button statDown;

    /*
    public Button skinTextureUp;

    public Button mouthTextureUp;

    public Button eyesTextureUp;

    public Button hairTextureUp;

    public Button clothesTextureUp;

    public Button armourTextureUp;
    
    
    public Button strengthUp;
    public Button strengthDown;
    public Button dexUp;
    public Button dexDown;
    public Button conUp;
    public Button conDown;
    public Button intUp;
    public Button intDown;
    public Button wisdUp;
    public Button wisdDown;
    public Button charismaUp;
    public Button charismaDown;
    */

    public int bonusStats = 6;
    public Text pointsLeft;

    public Text strength;

    public Text dex;

    public Text con;

    public Text intel;

    public Text wisd;

    public Text charisma;

    #endregion

    #region Start
    //in start we need to set up the following
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (int i = 0; i < attributeName.Length; i++)
        {
            attributes[i].name = attributeName[i];
        }
        for (int i = 0; i < statName.Length; i++)
        {
            charStats[i].name = statName[i];    
        }

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_"+i)as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            mouth.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            eyes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            hair.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            clothes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            armour.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<Renderer>();
        helm = GameObject.Find("cap").GetComponent<Renderer>();
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing

    public void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints; index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        Renderer curRend = new Renderer();
        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
        switch(type)
        {
            #region Skin
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number
                matIndex = 1;
                curRend = character;
                //end case
                break;
            #endregion
            #region Mouth
            //case Mouth
            case "Mouth":
                //index is the same as our Mouth index
                index = mouthIndex;
                //max is the same as our Mouth max
                max = mouthMax;
                //textures is our Mouth list .ToArray()
                textures = mouth.ToArray();
                //material index element number
                matIndex = 2;
                curRend = character;

                //end case
                break;
            #endregion
            #region Eyes
            //case Eyes
            case "Eyes":
                //index is the same as our Eyes index
                index = eyesIndex;
                //max is the same as our Eyes max
                max = eyesMax;
                //textures is our Eyes list .ToArray()
                textures = eyes.ToArray();
                //material index element number
                matIndex = 3;
                curRend = character;
                //end case
                break;
            #endregion
            #region Hair
            case "Hair":
                index = hairIndex;
                //index is the same as our  index
                max = hairMax;
                //max is the same as our  max
                textures = hair.ToArray();
                //textures is our  list .ToArray()
                matIndex = 4;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Clothes
            case "Clothes":
                index = clothesIndex;
                //index is the same as our  index
                max = clothesMax;
                //max is the same as our max
                textures = clothes.ToArray();
                //textures is our  list .ToArray()
                matIndex = 5;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Armour
            case "Armour":
                index = armourIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 6;
                curRend = character;
                //material index element number
                break;
            //break
            case "Helm":
                index = helmIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 1;
                curRend = helm;
                //material index element number
                break;
                //break
                #endregion
        }
        #endregion       
        //outside our switch statement
        #region Assign Direction
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = curRend.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        curRend.materials = mat;
        #endregion
        //create another switch that is goverened by the same string name of our material
        #region Set Material Switch
        switch (type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Helm":
                helmIndex = index;
                break;
        }
        #endregion
    }
    #endregion

    #region Canvas UI

    public void SkinTextureUp()
    {
        SetTexture(materialNames[0], 1);
    }
    public void MouthTextureUp()
    {
        SetTexture(materialNames[1], 1);
    }
    public void EyesTextureUp()
    {
        SetTexture(materialNames[2], 1);
    }
    public void HairTextureUp()
    {
        SetTexture(materialNames[3], 1);
    }
    public void ClothesTextureUp()
    {
        SetTexture(materialNames[4], 1);
    }
    public void ArmourTextureUp()
    {
        SetTexture(materialNames[5], 1);
    }

    public void StrengthUp()
    {
        if (bonusStats > 0)
        {
            charStats[0].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }
    public void DexUp()
    {
        if (bonusStats > 0)
        {
            charStats[1].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }
    public void ConUp()
    {
        if (bonusStats > 0)
        {
            charStats[2].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }
    public void IntUp()
    {
        if (bonusStats > 0)
        {
            charStats[3].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }
    public void WisUp()
    {
        if (bonusStats > 0)
        {
            charStats[4].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }
    public void CharUp()
    {
        if (bonusStats > 0)
        {
            charStats[5].lvlTempValue += 1;
            bonusStats -= 1;
        }
    }


    public void StrengthDown()
    {
        if (bonusStats < 6 && charStats[0].lvlTempValue > 0)
        {
            charStats[0].lvlTempValue -= 1;
            bonusStats += 1;
        }
    }
    public void DexDown()
    {
        if (bonusStats < 6 && charStats[1].lvlTempValue > 0)
        {
            charStats[1].lvlTempValue -= 1;
            bonusStats += 1;
        }
    }
    public void ConDown()
    {
        if (bonusStats < 6 && charStats[2].lvlTempValue > 0)
        {
            charStats[2].lvlTempValue--;
            bonusStats++;
        }
    }
    public void IntDown()
    {
        if (bonusStats < 6 && charStats[3].lvlTempValue > 0)
        {
            charStats[3].lvlTempValue--;
            bonusStats++;
        }
    }
    public void WisDown()
    {
        if (bonusStats < 6 && charStats[4].lvlTempValue > 0)
        {
            charStats[4].lvlTempValue--;
            bonusStats++;
        }
    }
    public void CharDown()
    {
        if (bonusStats < 6 && charStats[5].lvlTempValue > 0)
        {
            charStats[5].lvlTempValue--;
            bonusStats++;
        }
    }

    public void RandomAppearance()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
        SetTexture("Helm", Random.Range(0, armourMax - 1));
    }    
    public void ResetAppearance()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Helm", helmIndex = 0);
    }

    public void ClassDropdown(Dropdown classDrop)
    {
        ChooseClass(classDrop.value);
    }
    public void RaceDropdown(Dropdown raceDrop)
    {
        ChooseRace(raceDrop.value);
    }

    #endregion

    #region Stats/Class
    void ChooseRace(int raceIndex)
    {
        switch (raceIndex)
        {
            case 0:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 0;
                characterRace = CharacterRace.None;
                break;
            case 1:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 1;
                charStats[4].raceBonus = 1;
                charStats[5].raceBonus = 1;
                characterRace = CharacterRace.Human;
                break;
            case 2:
                charStats[0].raceBonus = 1;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 2;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 0;
                characterRace = CharacterRace.Dwarf;
                break;
            case 3:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 2;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 1;
                charStats[5].raceBonus = 0;
                characterRace = CharacterRace.Elf;
                break;
            case 4:
                charStats[0].raceBonus = 2;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 1;
                characterRace = CharacterRace.Dragonborn;
                break;
            case 5:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 2;
                charStats[4].raceBonus = 1;
                charStats[5].raceBonus = 0;
                characterRace = CharacterRace.Gnome;
                break;
            case 6:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 1;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 2;
                characterRace = CharacterRace.HalfElf;
                break;
            case 7:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 2;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 1;
                characterRace = CharacterRace.Halfling;
                break;
            case 8:
                charStats[0].raceBonus = 0;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 1;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 2;
                characterRace = CharacterRace.Tiefling;
                break;
            case 9:
                charStats[0].raceBonus = 2;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 1;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 0;
                characterRace = CharacterRace.HalfOrc;
                break;
            default:
                charStats[0].raceBonus = 2;
                charStats[1].raceBonus = 0;
                charStats[2].raceBonus = 0;
                charStats[3].raceBonus = 0;
                charStats[4].raceBonus = 0;
                charStats[5].raceBonus = 1;
                characterRace = CharacterRace.Dragonborn;
                break;
        }
    }

    void ChooseClass(int classIndex)
    {
        switch (classIndex)
        {
            case 0:
                charStats[0].baseValue = 0;
                charStats[1].baseValue = 0;
                charStats[2].baseValue = 0;
                charStats[3].baseValue = 0;
                charStats[4].baseValue = 0;
                charStats[5].baseValue = 0;
                characterClass = CharacterClass.None;
                break;
            case 1:
                charStats[0].baseValue = 15;
                charStats[1].baseValue = 13;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 8;
                charStats[4].baseValue = 12;
                charStats[5].baseValue = 10;
                characterClass = CharacterClass.Barbarian;
                break;
            case 2:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 14;
                charStats[2].baseValue = 13;
                charStats[3].baseValue = 12;
                charStats[4].baseValue = 10;
                charStats[5].baseValue = 15;
                characterClass = CharacterClass.Bard;
                break;
            case 3:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 15;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 10;
                charStats[4].baseValue = 13;
                charStats[5].baseValue = 12;
                characterClass = CharacterClass.Rogue;
                break;
            case 4:
                charStats[0].baseValue = 14;
                charStats[1].baseValue = 11;
                charStats[2].baseValue = 15;
                charStats[3].baseValue = 11;
                charStats[4].baseValue = 10;
                charStats[5].baseValue = 10;
                characterClass = CharacterClass.Warrior;
                break;
            case 5:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 13;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 12;
                charStats[4].baseValue = 10;
                charStats[5].baseValue = 15;
                characterClass = CharacterClass.Warlock;
                break;
            case 6:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 13;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 15;
                charStats[4].baseValue = 12;
                charStats[5].baseValue = 10;
                characterClass = CharacterClass.Wizard;
                break;
            case 7:
                charStats[0].baseValue = 15;
                charStats[1].baseValue = 8;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 10;
                charStats[4].baseValue = 13;
                charStats[5].baseValue = 12;
                characterClass = CharacterClass.Fighter;
                break;
            case 8:
                charStats[0].baseValue = 10;
                charStats[1].baseValue = 13;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 12;
                charStats[4].baseValue = 15;
                charStats[5].baseValue = 8;
                characterClass = CharacterClass.Druid;
                break;
            case 9:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 13;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 12;
                charStats[4].baseValue = 10;
                charStats[5].baseValue = 15;
                characterClass = CharacterClass.Sorcerer;
                break;
            case 10:
                charStats[0].baseValue = 15;
                charStats[1].baseValue = 8;
                charStats[2].baseValue = 13;
                charStats[3].baseValue = 10;
                charStats[4].baseValue = 12;
                charStats[5].baseValue = 14;
                characterClass = CharacterClass.Paladin;
                break;
            case 11:
                charStats[0].baseValue = 12;
                charStats[1].baseValue = 15;
                charStats[2].baseValue = 14;
                charStats[3].baseValue = 10;
                charStats[4].baseValue = 13;
                charStats[5].baseValue = 8;
                characterClass = CharacterClass.Monk;
                break;
            case 12:
                charStats[0].baseValue = 8;
                charStats[1].baseValue = 14;
                charStats[2].baseValue = 13;
                charStats[3].baseValue = 12;
                charStats[4].baseValue = 15;
                charStats[5].baseValue = 10;
                characterClass = CharacterClass.Cleric;
                break;

        }
    }

    #endregion

    private void Update()
    {
        strength.text = (charStats[0].baseValue + charStats[0].lvlTempValue + charStats[0].raceBonus).ToString();

        dex.text = (charStats[1].baseValue + charStats[1].lvlTempValue + charStats[1].raceBonus).ToString();

        con.text = (charStats[2].baseValue + charStats[2].lvlTempValue + charStats[2].raceBonus).ToString();

        intel.text = (charStats[3].baseValue + charStats[3].lvlTempValue + charStats[3].raceBonus).ToString();

        wisd.text = (charStats[4].baseValue + charStats[4].lvlTempValue + charStats[4].raceBonus).ToString();

        charisma.text = (charStats[5].baseValue + charStats[5].lvlTempValue + charStats[5].raceBonus).ToString();

        pointsLeft.text = "Points left: " + bonusStats;
    }

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    public void SaveCharacter()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
        PlayerPrefs.SetInt("skinIndex", skinIndex);
        PlayerPrefs.SetInt("hairIndex", hairIndex);
        PlayerPrefs.SetInt("mouthIndex", mouthIndex);
        PlayerPrefs.SetInt("eyesIndex", eyesIndex);
        PlayerPrefs.SetInt("armourIndex", armourIndex);
        PlayerPrefs.SetInt("clothesIndex", clothesIndex);
        PlayerPrefs.SetInt("helmIndex", helmIndex);
        //SetString CharacterName
        PlayerPrefs.SetString("characterName", characterName);
        PlayerPrefs.SetString("characterClass", characterClass.ToString());
        PlayerPrefs.SetString("characterRace", characterRace.ToString());

        for (int i = 0; i < charStats.Length; i++)
        {
            PlayerPrefs.SetInt(charStats[i].name, (charStats[i].lvlTempValue + charStats[i].baseValue + charStats[i].tempValue));
        }
    }

    #endregion
}
