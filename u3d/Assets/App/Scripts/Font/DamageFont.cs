

using UnityEngine;




//damage font
public class DamageFont : FontBase
{
    [SerializeField]
    private float duration;


    private float m_fStartTime;

    void Start()
    {
        this.m_fStartTime = Time.time;
    }

    void Update()
    {
        float difTime = Time.time - this.m_fStartTime;
        if( difTime > duration )
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}