using System;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    void OnGUI()
    {
        if (GUILayout.Button("Log debug"))
        {
            Debug.Log("Sample error");
        }

        if (GUILayout.Button("Log warning"))
        {
            Debug.LogWarning("Sample warning");
        }

        if (GUILayout.Button("Log error"))
        {
            Debug.LogError("Sample error");
        }

        if (GUILayout.Button("Log exception"))
        {
            Debug.LogException(new Exception("Sample exception"));
        }
    }
}
