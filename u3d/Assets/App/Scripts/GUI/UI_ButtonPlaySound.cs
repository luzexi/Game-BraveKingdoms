using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Game.Media;


/// <summary>
/// Plays the specified sound.
/// </summary>
[AddComponentMenu("uGUI/Button PlaySound")]
public class UI_ButtonPlaySound : MonoBehaviour
{
    public AudioClip audioClip;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(0f, 2f)] public float pitch = 1f;

    bool mStarted = false;

    void Start()
    {
        if(!mStarted)
        {
            mStarted = true;
            var ev = UI_Event.Get(this);
            ev.onClick += OnClick;
        }
    }

    void OnClick (PointerEventData eventData , GameObject go , string[] args)
    {
        if(audioClip != null)
            MediaMgr.sInstance.PlaySE(audioClip);
    }
}
