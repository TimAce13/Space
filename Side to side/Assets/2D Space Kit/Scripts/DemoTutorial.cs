using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoTutorial : MonoBehaviour, IDataPersistence
{
    [SerializeField] private DataPersistenceManager _dataPersistenceManager;
    
    [SerializeField] private GameObject[] _tuts;
    
    [SerializeField] private bool tutShown;
    [SerializeField] private bool nickSet;
    
    [SerializeField] private TextMeshProUGUI _nickName;
    [SerializeField] private TextMeshProUGUI _profileNickName;
    
    [SerializeField] private GameObject _nickNamePanel;
    [SerializeField] private GameObject _warning;
    private int curSlide = 0;
    private void Start()
    {
        if (!tutShown)
        {
            _tuts[0].SetActive(true);
        }
        else if(!nickSet)
        {
            _nickNamePanel.SetActive(true);
        }
        else
        {
            _profileNickName.text = _nickName.text;
        }
    }

    public void Skip()
    {
        for (int i = 0; i < _tuts.Length; i++)
        {
            _tuts[i].SetActive(false);
        }

        tutShown = true;
        _dataPersistenceManager.SaveGame();
        
        if(!nickSet)
        {
            _nickNamePanel.SetActive(true);
        }
    }

    public void Next()
    {
        if (curSlide == _tuts.Length - 1)
        {
            Skip();
        }
        else
        {
            _tuts[curSlide].SetActive(false);
            curSlide++;
            _tuts[curSlide].SetActive(true);
        }
    }

    public void Done()
    {
        if (_nickName.text.Length < 6 || _nickName.text.Contains(' '))
        {
            _warning.SetActive(true);
        }
        else
        {
            _nickNamePanel.SetActive(false);
            nickSet = true;
            _dataPersistenceManager.SaveGame();
            _profileNickName.text = _nickName.text;
        }
    }

    public void CloseWarning()
    {
        _warning.SetActive(false);
    }
    
    public void LoadData(GameData data)
    {
        this.tutShown = data.tutShown;
        this.nickSet = data.nickSet;
        this._nickName.text = data.nickName;
    }

    public void SaveData(GameData data)
    {
        data.tutShown = this.tutShown;
        data.nickSet = this.nickSet;
        data.nickName = this._nickName.text;
    }
}
