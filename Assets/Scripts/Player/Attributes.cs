using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerResources
    {
        public string name;
        public float currentValue;
        public float maxValue;
        //how quickly given resource passively regenerates, or from outside sources
        public float regenValue;
        public Image displayImage;
    }
    public PlayerResources[] attributes = new PlayerResources[3];
}
