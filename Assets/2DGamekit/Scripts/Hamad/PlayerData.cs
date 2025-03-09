using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    public float[] playerLocation = new float[] { 0, 0, 0 };
    public int health;

    public PlayerData()
    {

    }

    public void SetPlayerPosition(Vector3 location)
    {
        playerLocation[0] = location.x;
        playerLocation[1] = location.y;
        playerLocation[2] = location.z;
    }

    public void SetHealth(int _health)
    {
        _health = health;
    }

    public int ReturnHealth()
    {
        return health;
    }

    public Vector3 ReturnPlayerPosition()
    {
        return new Vector3(playerLocation[0], playerLocation[1], playerLocation[2]);
    }

    /*
    public string ReturnSaveData()
    {
        string returnData = "Health: " + health;
        return returnData;
    }
    */

}
