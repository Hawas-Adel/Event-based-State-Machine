using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("State Machine/Transition Manager")]
public class TransitionManager : MonoBehaviour
{
	[SerializeField, Min(0)]
	[Tooltip("Time between each transition condition check, 0 means conditions are checked every frame")]
	private float PollTime = 0.5f;

	private Transition[] Transitions;
	private Coroutine PollCOR;

	private void OnEnable()
	{
		Transitions = GetComponents<Transition>();
		PollCOR = StartCoroutine(ConditionsPolling());
	}
	private void OnDisable()
	{
		Transitions = null;
		StopCoroutine(PollCOR);
		PollCOR = null;
	}

	private void CheckTransitionConditions()
	{
		foreach (var transition in Transitions)
		{
			if (transition.Condition.Invoke())
			{
				GetComponentInParent<ITransitionResponder>()?.OnTransitionPass(transition.TargetState);
				break;
			}
		}
	}
	private IEnumerator ConditionsPolling()
	{
		for ( ; ; )
		{
			if (PollTime == 0)
			{
				yield return new WaitForEndOfFrame();
			}
			else
			{
				yield return new WaitForSeconds(PollTime);
			}
			CheckTransitionConditions();
		}
	}

	[ContextMenu("Debug Order")]
	private void DebugOrder()
	{
		foreach (var item in GetComponents<Transition>())
		{
			Debug.Log(item.TargetState.name);
		}
	}
}

public interface ITransitionResponder
{
	void OnTransitionPass(SM_State TargetState);
}
