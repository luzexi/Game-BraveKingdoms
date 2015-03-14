using UnityEngine;
using System.Collections;


namespace StateMachine{
	public class UnityEventHandler : MonoBehaviour {
		public delegate void OnLevelWasLoadedDel(int level);
		public event OnLevelWasLoadedDel onLevelWasLoaded;
		private void OnLevelWasLoaded(int level) {
			if (onLevelWasLoaded != null) {
				onLevelWasLoaded(level);			
			}
		}

		#region Deprecated
		public delegate void Trigger(GameObject other);
		public event Trigger onTriggerEnter;
		public event Trigger onTriggerExit;
		public event Trigger onTriggerStay;
		public event Trigger onCollisionEnter;
		public event Trigger onCollisionExit;
		public event Trigger onCollisionStay;

		private void OnTriggerEnter (Collider other) {
			if (onTriggerEnter != null) {
				onTriggerEnter (other.gameObject);
			}
		}

		private void OnTriggerExit(Collider other) {
			if (onTriggerExit != null) {
				onTriggerExit (other.gameObject);
			}
		}

		private void OnTriggerStay(Collider other) {
			if (onTriggerStay != null) {
				onTriggerStay (other.gameObject);
			}
		}

		private void OnCollisionEnter(Collision collision) {
			if (onCollisionEnter != null) {
				onCollisionEnter (collision.gameObject);
			}
		}

		private void OnCollisionExit(Collision collision) {
			if (onCollisionExit!= null) {
				onCollisionExit (collision.gameObject);
			}
		}

		private void OnCollisionStay(Collision collision) {
			if (onCollisionStay != null) {
				onCollisionStay (collision.gameObject);
			}
		}

		private void OnTriggerEnter2D (Collider2D other) {
			if (onTriggerEnter != null) {
				onTriggerEnter (other.gameObject);
			}
		}

		private void OnTriggerExit2D (Collider2D other) {
			if (onTriggerExit != null) {
				onTriggerExit(other.gameObject);
			}
		}

		private void OnTriggerStay2D (Collider2D other) {
			if (onTriggerStay != null) {
				onTriggerStay(other.gameObject);
			}
		}
		#endregion
	}
}