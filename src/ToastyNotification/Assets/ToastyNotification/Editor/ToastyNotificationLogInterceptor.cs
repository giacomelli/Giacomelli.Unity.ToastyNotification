using UnityEditor;
using UnityEngine;

/// <summary>
/// Toasty notification log interceptor that raise a Toasty notification every time an error or an exception are registered on log.
/// </summary>
/// <remarks>
/// https://github.com/giacomelli/Giacomelli.Unity.ToastyNotification
/// </remarks>
[InitializeOnLoad]
public static class ToastyNotificationLogInterceptor
{
    static ToastyNotificationLogInterceptor()
    {
        Application.logMessageReceived += HandleLogMessageReceived;
    }

    static void HandleLogMessageReceived(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            ToastyNotification.Notify();
        }
    }
}