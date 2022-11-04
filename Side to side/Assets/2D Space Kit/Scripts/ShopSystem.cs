using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _nonShopObjects;
    [SerializeField] private GameObject[] _shopObjects;

    public void OpenShop()
    {
        for (int i = 0; i < _nonShopObjects.Length; i++)
        {
            _nonShopObjects[i].SetActive(false);
        }

        for (int i = 0; i < _shopObjects.Length; i++)
        {
            _shopObjects[i].SetActive(true);
        }
    }
    
    public void CloseShop()
    {
        for (int i = 0; i < _nonShopObjects.Length; i++)
        {
            _nonShopObjects[i].SetActive(true);
        }

        for (int i = 0; i < _shopObjects.Length; i++)
        {
            _shopObjects[i].SetActive(false);
        }
    }
}
