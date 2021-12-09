using System;
using System.Collections;
using System.Collections.Generic;
using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyBehavior : MonoBehaviour, IState{
		private readonly Dictionary<EnemyStateType, Action<bool>> _stateTriggerList =
				new Dictionary<EnemyStateType, Action<bool>>();

		private void Start(){
			_stateTriggerList.Add(EnemyStateType.Dizzy, Dizzy);
		}

		private Coroutine _stateActivating;

		public void SetState(EnemyStateType state, float time){
			var containsKey = _stateTriggerList.ContainsKey(state);
			if(!containsKey) throw new Exception($"{state} is not in TriggerList");
			var trigger = _stateTriggerList[state];
			if(_stateActivating != null){
				StopCoroutine(_stateActivating);
			}

			_stateActivating = StartCoroutine(StateActivating(trigger, time));
		}

		private IEnumerator StateActivating(Action<bool> stateTrigger, float activateTime){
			stateTrigger.Invoke(true);
			yield return new WaitForSeconds(activateTime);
			stateTrigger.Invoke(false);
		}

		private void Dizzy(bool enable){
			Debug.Log(enable ? $"Dizzy Enable" : $"DIzzy Disable");
		}
	}
}