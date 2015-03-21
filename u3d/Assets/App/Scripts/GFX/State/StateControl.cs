

using UnityEngine;

//  StateControl.cs
//  Auth: Lu Zexi
//  2013-11-21

namespace Game.Gfx
{

    /// <summary>
    /// 状态控制
    /// </summary>
    public class StateControl
    {
        private StateBase m_cCurrentState;      //当前状态
        //private CmdStateBase m_cCurrentCmdState;//当前命令状态
        private StateWrap m_cStateWrap;         //状态包对象
        //private CmdStateWrap m_cCmdWrap;        //命令状态包对象

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

        ///// <summary>
        ///// 命令状态包
        ///// </summary>
        //private class CmdStateWrap
        //{
        //    public CmdIdleState m_cIdleState;       //空闲命令状态
        //    public CmdAttackState m_cAttackState;   //攻击命令状态
        //    public CmdMoveState m_cMoveState;       //移动命令状态
        //    public CmdHurtState m_cHurtState;       //受伤命令状态

        //    public CmdStateWrap(GfxObject obj, StateControl control)
        //    {
        //        this.m_cIdleState = new CmdIdleState(obj, control);
        //        this.m_cMoveState = new CmdMoveState(obj, control);
        //        this.m_cAttackState = new CmdAttackState(obj, control);
        //        this.m_cHurtState = new CmdHurtState(obj, control);
        //    }
        //}

        public StateControl(GfxObject obj)
        {
            this.m_cStateWrap = new StateWrap(obj);
            //this.m_cCmdWrap = new CmdStateWrap(obj ,this);
            this.m_cCurrentState = null;
            //this.m_cCurrentCmdState = null;
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        public StateBase GetCurrentState()
        {
            return this.m_cCurrentState;
        }

        ///// <summary>
        ///// 获取当前命令状态
        ///// </summary>
        ///// <returns></returns>
        //public CmdStateBase GetCurrentCmdState()
        //{
        //    return this.m_cCurrentCmdState;
        //}

        /// <summary>
        /// 逻辑更新
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            ////命令状态更新
            //if (this.m_cCurrentCmdState != null)
            //{
            //    if (!this.m_cCurrentCmdState.Update())
            //    {
            //        this.m_cCurrentCmdState = null;
            //    }
            //}

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

        ///// <summary>
        ///// 移动命令
        ///// </summary>
        ///// <param name="pos"></param>
        ///// <param name="costTime"></param>
        //public void CmdMoveTo(Vector3 pos , float costtime)
        //{
        //    this.m_cCmdWrap.m_cMoveState.Set(pos , costtime);
        //    this.m_cCurrentCmdState = this.m_cCmdWrap.m_cMoveState;
        //    this.m_cCurrentCmdState.OnEnter();
        //}

        ///// <summary>
        ///// 空闲命令
        ///// </summary>
        //public void CmdIdle()
        //{
        //    this.m_cCurrentCmdState = this.m_cCmdWrap.m_cIdleState;
        //    this.m_cCurrentCmdState.OnEnter();
        //}

        ///// <summary>
        ///// 受伤命令状态
        ///// </summary>
        //public void CmdHurt( int hurNum )
        //{
        //    this.m_cCurrentCmdState = this.m_cCmdWrap.m_cHurtState;
        //    this.m_cCurrentCmdState.OnEnter();
        //}

        ///// <summary>
        ///// 攻击命令
        ///// </summary>
        //public void CmdAttack( )
        //{
        //    //this.m_cCmdWrap.m_cAttackState.Set(obj);
        //    this.m_cCurrentCmdState = this.m_cCmdWrap.m_cAttackState;
        //    this.m_cCurrentCmdState.OnEnter();
        //}

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

        /// <summary>
        /// 移动状态
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="costTime"></param>
        public void Move( Vector3 pos , float costTime )
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cStateWrap.m_cMoveState.Set(pos, costTime);
            this.m_cCurrentState = this.m_cStateWrap.m_cMoveState;
            this.m_cCurrentState.OnEnter();
        }

        /// <summary>
        /// 回退
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="costTime"></param>
        public void MoveBack(Vector3 pos, float costTime)
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cStateWrap.m_cMoveBackState.Set(pos, costTime);
            this.m_cCurrentState = this.m_cStateWrap.m_cMoveBackState;
            this.m_cCurrentState.OnEnter();
        }

        /// <summary>
        /// 空闲状态
        /// </summary>
        public void Idle()
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cCurrentState = this.m_cStateWrap.m_cIdleState;
            this.m_cCurrentState.OnEnter();
        }

        //受伤状态
        public void Hurt()
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cCurrentState = this.m_cStateWrap.m_cHurtState;
            this.m_cCurrentState.OnEnter();
        }

        /// <summary>
        /// 攻击状态
        /// </summary>
        /// <param name="targetObj"></param>
        public void Attack()
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cCurrentState = this.m_cStateWrap.m_cAttackState;
            this.m_cCurrentState.OnEnter();
        }


        /// <summary>
        /// 技能状态
        /// </summary>
        public void Skill()
        {
            if (this.m_cCurrentState != null)
                this.m_cCurrentState.OnExit();

            this.m_cCurrentState = this.m_cStateWrap.m_cSkillState;
            this.m_cCurrentState.OnEnter();
        }
    }

}