
using UnityEngine;

//  MoveState.cs
//  Auth: Lu Zexi
//  2013-11-21


/// <summary>
/// 移动状态
/// </summary>
public class MoveState : StateBase
{
    private Vector3 m_vecTargetPos;     //目标点
    private float m_fCostTime;          //花费时间
    private float m_fLastTime;          //最近时间
    private Vector3 m_vecLastPos;       //最近坐标

    public MoveState(GfxObject obj)
        : base(obj)
    { 
    }

    /// <summary>
    /// 获取状态类型
    /// </summary>
    /// <returns></returns>
    public override STATE_TYPE GetStateType()
    {
        return STATE_TYPE.STATE_MOVE;
    }

    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="costTime"></param>
    public void Set( Vector3 from , Vector3 to, float costTime)
    {
        this.m_vecLastPos = from;
        this.m_vecTargetPos = to;
        this.m_fCostTime = costTime;
        this.m_fLastTime = Time.time;
    }

    /// <summary>
    /// 进入状态
    /// </summary>
    /// <returns></returns>
    public override bool OnEnter()
    {
        this.m_cObj.transform.localPosition = this.m_vecLastPos;
        if( this.m_cObj.m_cAni["move"] == null )
        {
            this.m_cObj.m_cAni["idle"].wrapMode = WrapMode.Loop;
            this.m_cObj.m_cAni.Play("idle");
        }
        else
        {
            float rate = this.m_cObj.m_cAni["move"].length / this.m_fCostTime;
            this.m_cObj.m_cAni["move"].speed = rate;
            this.m_cObj.m_cAni["move"].wrapMode = WrapMode.Once;
            this.m_cObj.m_cAni.Play("move");
        }
        return true;
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public override bool Update()
    {
        float disTime = Time.fixedTime - this.m_fLastTime;

        if (disTime >= this.m_fCostTime)
        {
            this.m_cObj.transform.localPosition = this.m_vecTargetPos;
            return false;
        }
        else
        {
            Vector3 pos = Vector3.Lerp(this.m_vecLastPos, this.m_vecTargetPos, disTime / this.m_fCostTime);
            this.m_cObj.transform.localPosition = pos;
        }

        return true;
    }

}
