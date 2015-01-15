using UnityEngine;
using System.Collections;
using StateMachine.Action;

namespace StateMachine{
	public class StateMachineBehaviour: MonoBehaviour {
		public StateMachine stateMachine;
		[HideInInspector]
		public StateMachine executingStateMachine;
		[HideInInspector]
		public AnyState anyState;
		[HideInInspector]
		public State currentState;
		public int group=0;
		public bool start=true;
		public bool debug=true;
		[HideInInspector]
		public bool isPaused=true;
		private bool initialized=false;
		public delegate void CustomEvent(string eventName, object parameter);
		public event CustomEvent onReceiveEvent;

		private void Awake () {
			enabled = (stateMachine != null && stateMachine.states.Count > 0);
			if (enabled) {
				stateMachine.behaviour = this;
				executingStateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				executingStateMachine.owner = gameObject;
				StateMachine.Copy (stateMachine, executingStateMachine, false);
				
				executingStateMachine.Initialize (this);
				executingStateMachine.name = stateMachine.name;
				currentState = executingStateMachine.states.Find (state => state.isDefaultState == true);
				anyState = (AnyState)executingStateMachine.states.Find (state => state.GetType () == typeof(AnyState));
				if (anyState == null) {
					enabled = false;
					return;
				}
				initialized = true;
				if (start) {
					EnableStateMachine ();
				}
			} 
			startedEnter = false;
			
		}

		private State state;
		private bool startedEnter;
		public virtual void Update () {
			if (isPaused) {
				return;
			}
			if (!startedEnter) {
				anyState.DoEnter ();
				if (currentState != null) {
					currentState.DoEnter ();		
				}	
				startedEnter = true;
			} else {
				anyState.DoUpdate ();
				if (currentState != null) {
					currentState.DoUpdate ();
				}
			}
			state = CheckTransition ();
			SetState (state);
			state = null;
		}

		private void FixedUpdate(){
			if (isPaused) {
				return;
			}
			if (!startedEnter) {
				anyState.DoEnter ();
				if (currentState != null) {
					currentState.DoEnter ();		
				}	
				startedEnter = true;
			} else {
				
				anyState.DoFixedUpdate ();
				if (currentState != null) {
					currentState.DoFixedUpdate ();
				}
			}
		}

		private void OnAnimatorIK(int layer) {
			if (isPaused) {
				return;
			}
			anyState.DoOnAnimatorIK (layer);
			if (currentState != null) {
				currentState.DoOnAnimatorIK (layer);
			}
		}

		private void OnAnimatorMove() {
			if (isPaused) {
				return;
			}
			anyState.DoAnimatorMove ();
			if (currentState != null) {
				currentState.DoAnimatorMove ();
			}
		}

		private void OnGUI(){
			if (isPaused) {
				return;
			}
			anyState.DoOnGUI();
			if (currentState != null) {
				currentState.DoOnGUI();			
			}
		}

		public void SetParameter(object[] data){
			executingStateMachine.SetParameter ((string)data [0], data [1]);	
		}

		public NamedParameter GetParameter(string name){
			return executingStateMachine.GetPrameter (name);		
		}

		public void SetStateMachine(StateMachine stateMachine){
			this.stateMachine = stateMachine;
			Awake ();
		}

		public void SetDefaultState(){
			currentState.DoExit();
			currentState= executingStateMachine.states.Find (state => state.isDefaultState == true);
			currentState.DoEnter();
		}

		public void SetState(string _name){
			currentState.DoExit();
			currentState= executingStateMachine.states.Find (state => state.name == _name);
			currentState.DoEnter();
		}

		private State CheckTransition(){
			state = (currentState!= null)? currentState.ValidateTransitions ():null;
			if (state == null) {
				state = anyState.ValidateTransitions ();
			}
			return state;
		}

		public void SetState(State mState){
			if (mState != null) {
				if(currentState != null)
				currentState.DoExit();
				currentState = executingStateMachine.states.Find(x=> x.id==mState.id);
				currentState.DoEnter();
			}
		}

		public void EnableStateMachine(){
			if (!initialized) {
				Awake();			
			}
			isPaused = false;
			/*anyState.DoEnter ();
			if (currentState != null) {
				currentState.DoEnter();		
			}	*/
		}

		public void DisableStateMachine(bool pause){
			if (pause) {
				isPaused = true;
			} else {
				enabled=false;	
			}
		}

		public void SendEvent(string eventName, object parameter){
			if (onReceiveEvent != null) {
				onReceiveEvent (eventName,parameter);
			}
		}
	}
}
