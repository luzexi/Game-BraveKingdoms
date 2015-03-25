

using UnityEngine;

//  StateControl.cs
//  Auth: Lu Zexi
//  2013-11-21


/// <summary>
/// 状态控制
/// </summary>
public class StateControl
{
    private StateBase m_cCurrentState;      //当前状态
    private StateWrap m_cStateWrap;         //状态包对象

    /// <summary>
    /// 状态包
    /// </summary>
    private class StateWrap
    {
        public IdleState m_cIdleState;      //空闲状态
        public AttackState m_cAttackState;  //攻击状态
        public MoveState m_cMoveState;      //移动状态
        public MoveBackState m_cMoveBackState;  //回退状态
        public HurtState m_cHurtState;      //受伤状态
        public SkillState m_cSkillState;    //技能状态
        public DieState m_cDieState;    //死亡状态

        public StateWrap(GfxObject obj)
        {
            this.m_cIdleState = new IdleState(obj);
            this.m_cAttackState = new AttackState(obj);
            this.m_cMoveState = new MoveState(obj);
            this.m_cMoveBackState = new MoveBackState(obj);
            this.m_cHurtState = new HurtState(obj);
            this.m_cSkillState = new SkillState(obj);
            this.m_cDieState = new DieState(obj);
        }
    }

    public StateControl(GfxObject obj)
    {
        this.m_cStateWrap = new StateWrap(obj);
        this.m_cCurrentState = null;
    }

    /// <summary>
    /// 获取当前状态
    /// </summary>
    /// <returns></returns>
    public StateBase GetCurrentState()
    {
        return this.m_cCurrentState;
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public bool Update()
    {
        //状态更新
        if ( this.m_cCurrentState != null)
        {
            if (!this.m_cCurrentState.Update())
            {
                Idle();
            }
        }
        return true;
    }

    /// <summary>
    /// 死亡状态
    /// </summary>
    public void Die()
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cCurrentState = this.m_cStateWrap.m_cDieState;
        this.m_cCurrentState.OnEnter();
    }

    //move from position to anthor position
    public void Move( Vector3 from , Vector3 to , float costTime )
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cStateWrap.m_cMoveState.Set(from , to, costTime);
        this.m_cCurrentState = this.m_cStateWrap.m_cMoveState;
        this.m_cCurrentState.OnEnter();
    }

    //move back
    public void MoveBack(Vector3 pos, float costTime)
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cStateWrap.m_cMoveBackState.Set(pos, costTime);
        this.m_cCurrentState = this.m_cStateWrap.m_cMoveBackState;
        this.m_cCurrentState.OnEnter();
    }

    //idle
    public void Idle()
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cCurrentState = this.m_cStateWrap.m_cIdleState;
        this.m_cCurrentState.OnEnter();
    }

    //hurt
    public void Hurt()
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cCurrentState = this.m_cStateWrap.m_cHurtState;
        this.m_cCurrentState.OnEnter();
    }

    //attack
    public void Attack( GfxObject target , Vector3 pos , float[] hit_time1 , float[] hit_time2 , int[] damage , bool ismove )
    {
        if (this.m_cCurrentState != null &&
            this.m_cCurrentState.GetStateType() == STATE_TYPE.STATE_ATTACK)
            return;
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cStateWrap.m_cAttackState.Set(target , pos , hit_time1 , hit_time2 , damage , ismove);
        this.m_cCurrentState = this.m_cStateWrap.m_cAttackState;
        this.m_cCurrentState.OnEnter();
    }


    //skill
    public void Skill()
    {
        if (this.m_cCurrentState != null)
            this.m_cCurrentState.OnExit();

        this.m_cCurrentState = this.m_cStateWrap.m_cSkillState;
        this.m_cCurrentState.OnEnter();
    }
}
