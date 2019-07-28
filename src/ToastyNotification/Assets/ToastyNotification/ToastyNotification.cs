using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toasty notification.
/// </summary>
/// <remarks>
/// https://github.com/giacomelli/Giacomelli.Unity.ToastyNotification
/// </remarks>
public class ToastyNotification : MonoBehaviour
{
    [SerializeField]
    float _timeToHide = 2f;

    AudioSource _audio;
    Image _image;
   
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _image = GetComponentInChildren<Image>();
    }

    /// <summary>
    /// Shows the notification.
    /// </summary>
    /// <remarks>
    /// The notification will be hide after the time defined on "Time to Hide".
    /// </remarks>
    void Show()
    {
        if (!_image.enabled)
        {
            _audio.Play();
            _image.enabled = true;
            StartCoroutine(WaitToHide());
        }
    }

    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(_timeToHide);
        _image.enabled = false;
    }

    /// <summary>
    /// Performs a Toasty notification.
    /// </summary>
    /// <remarks>
    /// It will create a game object with the ToastyNotificationPrefab if it not exists yet.
    /// </remarks>
    public static void Notify()
    {
        var go = GameObject.Find("ToastyNotification");

        if (go == null)
        {
            go = Instantiate(Resources.Load("ToastyNotificationPrefab")) as GameObject;
            go.name = "ToastyNotification";
        }

        go.GetComponent<ToastyNotification>().Show();
    }
}
