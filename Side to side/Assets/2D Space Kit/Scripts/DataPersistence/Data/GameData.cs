using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int shootedBullets;
    public string nickName;
    public bool nickSet;
    public bool tutShown;
    public int level;
    //public SerializableDictionary<int, bool> spaceShips;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        level = 1;
        nickSet = false;
        shootedBullets = 0;
        tutShown = false;
        nickName = "Noname";
        //spaceShips = new SerializableDictionary<int, bool>();
    }
}