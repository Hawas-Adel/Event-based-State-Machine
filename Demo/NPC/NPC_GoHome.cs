using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC_GoHome : MonoBehaviour
{
	[SerializeField] private Transform Home = default;
	[SerializeField] [Min(0)] private float WaitTime = default;
	private NavMeshAgent NMA;

	private void Start() => NMA = GetComponent<NavMeshAgent>();

	public void HeadHome() => NMA.SetDestination(Home.position);

	public bool ReachedDestination() => NMA.remainingDistance <= NMA.stoppingDistance;
	public bool IsDoneWaiting(SM_State state) => state.CompareActiveDuration(WaitTime);
}
