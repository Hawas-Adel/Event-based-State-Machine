using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("State Machine/Manager")]
public class SM_Manager : MonoBehaviour, ITransitionResponder
{
	[SerializeField, ReorderableList]
	[Tooltip("List Of States Managed by this component, First state is default state")]
	private List<SM_State> ManagedStates;

	private void Awake()
	{
		for (int i = 1 ; i < ManagedStates.Count ; i++)
		{
			ManagedStates[i].gameObject.SetActive(false);
		}
	}

	public void OnTransitionPass(SM_State TargetState)
	{
		if (ManagedStates.Contains(TargetState))
		{
			SM_State CurrentState = GetComponentInChildren<SM_State>();
			if (CurrentState != TargetState)
			{
				CurrentState.gameObject.SetActive(false);
				TargetState.gameObject.SetActive(true);
			}
		}
		else
		{
			Debug.LogError($"This manager ({name}) is not set to manage target state ({TargetState.name})");
		}
	}


	[ContextMenu("GetChildStates")]
	private void GetChildStates() => ManagedStates = GetComponentsInChildren<SM_State>().ToList();
}
