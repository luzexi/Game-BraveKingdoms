using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Simple example script of how a button can be scaled visibly when the mouse hovers over it or it gets pressed.
/// </summary>
public class UI_ButtonScale : MonoBehaviour
{
    public Transform tweenTarget;
    public Vector3 hover = Vector3.one;
    public Vector3 pressed = new Vector3(0.95f, 0.95f, 0.95f);
    public float duration = 0f;

    Vector3 mScale;
    bool mStarted = false;

    void Start ()
    {
        if (!mStarted)
        {
            mStarted = true;
            if (tweenTarget == null) tweenTarget = transform;
            mScale = tweenTarget.localScale;
            var ev = UI_Event.Get(tweenTarget);
            ev.onClick += OnClick;
        }
    }

    void OnDisable ()
    {
        if (mStarted && tweenTarget != null)
        {
            // iTween.Stop(tweenTarget.gameObject);
            // tweenTarget.localScale = mScale;
        }
    }

    void OnClick ( PointerEventData eventData , GameObject go , string[] args )
    {
        if (enabled)
        {
            if (!mStarted) Start();
            iTween.ScaleTo( tweenTarget.gameObject , iTween.Hash( "scale" , pressed , "time" , duration ,
                "oncomplete" , (System.Action)(()=>{
                iTween.ScaleTo( tweenTarget.gameObject , mScale , duration );
            })) );
        }
    }
}
