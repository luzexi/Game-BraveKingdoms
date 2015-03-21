
using UnityEngine;

//  MoveState.cs
//  Auth: Lu Zexi
//  2013-11-21

namespace Game.Gfx
{
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
        public void Set(Vector3 pos, float costTime)
        {
            this.m_vecTargetPos = pos;
            this.m_fCostTime = costTime;
            this.m_fLastTime = Time.fixedTime;
            this.m_vecLastPos = this.m_cObj.transform.localPosition;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        /// <returns></returns>
        public override bool OnEnter()
        {
            float rate = this.m_cObj.m_cAni["move"].length / this.m_fCostTime;
            this.m_cObj.m_cAni["move"].speed = rate;
            this.m_cObj.m_cAni["move"].wrapMode = WrapMode.Once;
            this.m_cObj.m_cAni.Play("move");
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
                //if (!this.m_cObj.IsPlay("move"))
                //{
                //    return false;
                //}
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
}

