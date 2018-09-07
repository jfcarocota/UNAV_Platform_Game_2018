using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    [SerializeField]
    float posX;
    [SerializeField]
    float posY;

    public GameData() { }

    public GameData(float posX, float posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}
