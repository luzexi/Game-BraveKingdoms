
using UnityEngine;

//  AttackState.cs
//  Auth: Lu Zexi
//  2013-11-21



/// <summary>
/// 攻击状态
/// </summary>
public class AttackState : StateBase
{
    private GfxObject m_cTargetObj;
    private float[] m_vecHitTime1;
    private float[] m_vecHitTime2;
    private int[] m_vecDamage;
    private bool m_bIsMove;
    private Vector3 m_cPos;

    public AttackState(GfxObject obj)
        : base(obj)
    { 

    }

    /// <summary>
    /// 获取状态类型
    /// </summary>
    /// <returns></returns>
    public override STATE_TYPE GetStateType()
    {
        return STATE_TYPE.STATE_ATTACK;
    }

    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="target"></param>
    public void Set(GfxObject target ,Vector3 pos, float[] hit_time1 , float[] hit_time2 , int[] damage , bool ismove)
    {
        this.m_cPos = pos;
        this.m_cTargetObj = target;
        this.m_vecHitTime1 = hit_time1;
        this.m_vecHitTime2 = hit_time2;
        this.m_vecDamage = damage;
        this.m_bIsMove = ismove;
    }

    /// <summary>
    /// 进入状态
    /// </summary>
    /// <returns></returns>
    public override bool OnEnter()
    {
        this.m_cObj.m_cAni["attack"].wrapMode = WrapMode.Once;
        this.m_cObj.m_cAni.Play("attack");
        return true;
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public override bool Update()
    {
        if (this.m_cObj != null)
        {
            return this.m_cObj.m_cAni.IsPlaying("attack");
        }
        return false;
    }

}

