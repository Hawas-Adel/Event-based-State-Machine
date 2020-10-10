using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("State Machine/Transition")]
[RequireComponent(typeof(TransitionManager))]
public class Transition : MonoBehaviour
{
	public TransitionCondition Condition;
	public SM_State TargetState;
}

[System.Serializable]
public class TransitionCondition : SerializableCallback<bool> { }