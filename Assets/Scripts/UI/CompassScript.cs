using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    public Transform playerPos;
    public RawImage scrollTexture;

    void Update()
    {
        scrollTexture.uvRect = new Rect(playerPos.localEulerAngles.y/360, 0,1,1);
    }
}
