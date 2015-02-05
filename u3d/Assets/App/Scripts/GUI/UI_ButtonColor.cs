using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Simple example script of how a button can be colored when the mouse hovers over it or it gets pressed.
/// </summary>
public class UI_ButtonColor : MonoBehaviour
{
    /// <summary>
    /// Target with a widget, renderer, or light that will have its color tweened.
    /// </summary>

    public GameObject tweenTarget;

    /// <summary>
    /// Color to apply on hover event (mouse only).
    /// </summary>
    public Color hover = Color.white;

    /// <summary>
    /// Color to apply on the pressed event.
    /// </summary>
    public Color pressed = new Color(0.75f, 0.75f, 0.75f, 1f);

    /// <summary>
    /// Duration of the tween process.
    /// </summary>

    public float duration = 0.2f;

    protected Color mColor;
    protected bool mStarted = false;
    // protected UIWidget mWidget;

    /// <summary>
    /// UIButtonColor's default (starting) color. It's useful to be able to change it, just in case.
    /// </summary>
    public Color defaultColor
    {
        get
        {
            Start();
            return mColor;
        }
        set
        {
            Start();
            mColor = value;
        }
    }

    void Start ()
    {
        if (!mStarted)
        {
            mStarted = true;
            Init();
            var ev = UI_Event.Get(tweenTarget);
            ev.onClick += OnClick;
        }
    }

    void OnDisable ()
    {
        if (mStarted && tweenTarget != null)
        {
            // iTween.Stop(tweenTarget.gameObject);
        }
    }

    void Init ()
    {
        if (tweenTarget == null) tweenTarget = gameObject;
        Image img = tweenTarget.GetComponent<Image>();
        if(img != null)
        {
            mColor = img.color;
        }
    }

    void OnClick ( PointerEventData eventData , GameObject go , string[] args )
    {
        if (enabled)
        {
            if (!mStarted) Start();

            System.Action<Color> onupdate = (System.Action<Color>)((val)=>{
                var img = tweenTarget.GetComponent<Image>();
                if( img != null )
                    img.color = val;
            });

            iTween.Stop(tweenTarget.gameObject);
            iTween.ValueTo( tweenTarget.gameObject , iTween.Hash( "from" , mColor , "to" , pressed , "time" , duration , "easetype" , "linear" ,
                "onupdate" , onupdate , "oncomplete" , (System.Action)(()=>{
                    iTween.ValueTo( tweenTarget.gameObject , iTween.Hash( "from" , pressed , "to" , mColor , "time" , duration , "easetype" , "linear" ,
                        "onupdate" , onupdate));
            }) ) );
        }
    }
}
