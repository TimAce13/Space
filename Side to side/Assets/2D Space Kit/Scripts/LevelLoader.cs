using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TextMeshProUGUI _loaderText;

    [SerializeField] private DataPersistenceManager _dataPersistenceManager;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }
    public void LoadLevel(int sceneIndex)
    {
        _dataPersistenceManager.SaveGame();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        _loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _loaderText.text = "SYNCING DATA " + progress * 100f + "%" ;

            yield return null;
        }
    }
}
