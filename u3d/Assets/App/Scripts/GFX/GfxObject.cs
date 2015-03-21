using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Gfx;

//  GfxObject.cs
//  Author: Lu Zexi
//  2013-11-21



/// <summary>
/// 图形渲染类
/// </summary>
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
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Start()
    {
        this.m_cStateControl.Idle();
    }

    /// <summary>
    /// 销毁
    /// </summary>
    public virtual void Destory()
    {
        GameObject.Destroy(this.gameObject);
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    public virtual void Update()
    {
        this.m_cStateControl.Update();
    }
    ////////////////////////////////////////// 状态控制 ////////////////////////////////////

    /// <summary>
    /// 攻击状态
    /// </summary>
    public void AttackState()
    {
        this.m_cStateControl.Attack();
    }

    /// <summary>
    /// 空闲状态
    /// </summary>
    public void IdleState()
    {
        this.m_cStateControl.Idle();
    }

    /// <summary>
    /// 移动状态
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="costTime"></param>
    public void MoveState( Vector3 pos , float costTime )
    {
        this.m_cStateControl.Move(pos, costTime);
    }

    /// <summary>
    /// 受伤状态
    /// </summary>
    public void HurtState()
    {
        this.m_cStateControl.Hurt();
    }

    /// <summary>
    /// 技能状态
    /// </summary>
    public void SkillState()
    {
        this.m_cStateControl.Skill();
    }

    //////////////////////////////////////////////////  坐标朝向转换 API ///////////////////////////////

    ////////////////////////////////////////////  动画 API /////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////

}

