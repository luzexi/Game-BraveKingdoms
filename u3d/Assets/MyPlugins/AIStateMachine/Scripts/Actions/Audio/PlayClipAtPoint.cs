using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Plays an AudioClip at a given position in world space.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.PlayClipAtPoint.html")]
	[System.Serializable]
	public class PlayClipAtPoint : StateAction {
		[ObjectType(typeof(AudioClip))]
		[Tooltip("Audio data to play.")]
		public ObjectParameter clip;
		[Tooltip("Position in world space from which sound originates.")]
		public Vector3Parameter position;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("Optional plays at targets position.")]
		public ObjectParameter target;
		[Tooltip("Playback volume.")]
		public FloatParameter volume;

		public override void OnEnter ()
		{
			if (target != null && !target.isNone && target.Value != null) {
				AudioSource.PlayClipAtPoint ((AudioClip)clip.Value, ((GameObject)target.Value).transform.position, volume.Value);
			} else {
				AudioSource.PlayClipAtPoint ((AudioClip)clip.Value, position.Value, volume.Value);
			}

			Finish ();
		}
	}
}