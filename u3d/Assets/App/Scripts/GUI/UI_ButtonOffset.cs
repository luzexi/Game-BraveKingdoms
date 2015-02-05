using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Simple example script of how a button can be offset visibly when the mouse hovers over it or it gets pressed.
/// </summary>
public class UI_ButtonOffset : MonoBehaviour
{
    public Transform tweenTarget;
    public Vector3 hover = Vector3.zero;
    public Vector3 pressed = new Vector3(2f, -2f);
    public float duration = 0;

    Vector3 mPos;
    bool mStarted = false;

    void Start ()
    {
        if (!mStarted)
        {
            mStarted = true;
            if (tweenTarget == null) tweenTarget = transform;
            mPos = tweenTarget.localPosition;
            var ev = UI_Event.Get(tweenTarget);
            ev.onClick += OnClick;
        }
    }

    void OnEnable ()
    {
        // if (mStarted) OnHover(UICamera.IsHighlighted(gameObject));
    }

    void OnDisable ()
    {
        if (mStarted && tweenTarget != null)
        {
            // TweenPosition tc = tweenTarget.GetComponent<TweenPosition>();

            // if (tc != null)
            // {
            //     tc.value = mPos;
            //     tc.enabled = false;
            // }
        }
    }

    void OnClick (PointerEventData eventData , GameObject go , string[] args)
    {
        if (enabled)
        {
            if (!mStarted) Start();
            iTween.MoveTo( tweenTarget.gameObject , iTween.Hash( "position" , mPos+pressed , "time" , duration , "easetype" , "linear" ,
                "oncomplete" , (System.Action)(()=>{
                    iTween.MoveTo(tweenTarget.gameObject , mPos , duration);
                    })
             ) );
            // TweenPosition.Begin(tweenTarget.gameObject, duration, isPressed ? mPos + pressed :
            //     (UICamera.IsHighlighted(gameObject) ? mPos + hover : mPos)).method = UITweener.Method.EaseInOut;
        }
    }
}
