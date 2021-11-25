using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour
{
    public static CharacterClass characterClass = CharacterClass.Barbarian;
    public static CharacterRace characterRace = CharacterRace.Dragonborn;
    void Start()
    {
        characterClass = CharacterClass.None;
        characterRace = CharacterRace.None;
    }

}


