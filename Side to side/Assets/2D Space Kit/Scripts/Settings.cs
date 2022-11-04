using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    void Awake() {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
}
