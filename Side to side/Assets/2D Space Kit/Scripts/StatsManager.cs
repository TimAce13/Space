using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private DataPersistenceManager _dataPersistenceManager;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private int level;
    public void LoadData(GameData data)
    {
        this.level = data.level;
    }

    public void SaveData(GameData data)
    {
        data.level = this.level;
    }

    private void Update()
    {
        _levelText.text = "Level " + level;
    }
}
