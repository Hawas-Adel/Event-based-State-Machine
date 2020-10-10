using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("State Machine/State")]
public class SM_State : MonoBehaviour
{
	private float LastTimeBecameActive;
	public UnityEvent BecomeActive;
	public UnityEvent BecomeInactive;

	private void OnEnable()
	{
		BecomeActive.Invoke();
		LastTimeBecameActive = Time.time;
	}
	private void OnDisable() => BecomeInactive.Invoke();

	/// <summary>
	/// compare this states active duration to <paramref name="TargetTime"/>
	/// </summary>
	/// <param name="TargetTime">Value to compare with</param>
	/// <returns>return true if this state has been active longer that <paramref name="TargetTime"/></returns>
	public bool CompareActiveDuration(float TargetTime) => (Time.time - LastTimeBecameActive) >= TargetTime;

	public void DebugActivated() => Debug.Log($"{name} became Active");
	public void DebugDeActivated() => Debug.Log($"{name} became Inactive");
}
