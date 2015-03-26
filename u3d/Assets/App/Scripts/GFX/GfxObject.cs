using System;
using System.Collections.Generic;
using UnityEngine;

//  GfxObject.cs
//  Author: Lu Zexi
//  2013-11-21



/// <summary>
/// 图形渲染类
/// </summary>
[CustomLuaClassAttribute]
public partial class GfxObject : MonoBehaviour
{
    public StateControl m_cStateControl = null; //状态控制类
    public Animation m_cAni = null; //animation

    public XorInt Hp;   //hp
    public XorInt MaxHp;    //max hp
    public XorInt Mp;   //mp
    public XorInt MaxMp;    //max mp

    public XorInt Atk;  //atk
    public XorInt Def;  //def
    public XorInt Hit;  //hit

    public virtual void Awake()
    {
        this.m_cAni = this.GetComponent<Animation>();
        this.m_cStateControl = new StateControl(this);
        this.m_cStateControl.Idle();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Start()
    {
        //
    }

    //destory
    public virtual void Destory()
    {
        GameObject.Destroy(this.gameObject);
    }

    //update
    public void Update()
    {
        this.m_cStateControl.Update();
    }

    //is die or idle
    public bool IsDieOrIdle()
    {
        if( this.m_cStateControl.GetCurrentState() == null ||
            this.m_cStateControl.GetCurrentState().GetStateType() == STATE_TYPE.STATE_IDLE ||
            this.m_cStateControl.GetCurrentState().GetStateType() == STATE_TYPE.STATE_DIE
            )
            return true;
        return false;
    }
    ////////////////////////////////////////// state ////////////////////////////////////

    //attack state
    public void AttackState( GfxObject target , Vector3 pos , int target_index , int self_index , 
        float[] hit_time1 , float[] hit_time2 , float[] hit_rate ,
        System.Action<int,int,float,bool> callback , System.Action<int> over_callback , bool ismove = false )
    {
        this.m_cStateControl.Attack( target , pos , target_index , self_index ,
            hit_time1 , hit_time2 , hit_rate , callback , over_callback , ismove);
    }

    //idle state
    public void IdleState()
    {
        this.m_cStateControl.Idle();
    }

    //move from position to another position
    public void MoveState( Vector3 from , Vector3 to , float costTime )
    {
        this.m_cStateControl.Move(from , to, costTime);
    }

    //hurt state
    public void HurtState()
    {
        this.m_cStateControl.Hurt();
    }

    //skill state
    public void SkillState()
    {
        this.m_cStateControl.Skill();
    }
}

