using System;
using System.Collections;
using System.Collections.Generic;
using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyBehavior : MonoBehaviour, IState{
		private readonly Dictionary<EnemyStateType, Action<bool>> _stateTriggerList =
				new Dictionary<EnemyStateType, Action<bool>>();

		private Enemy _enemy;

		private void Start(){
			_enemy = GetComponent<Enemy>();
			RegisterStateTrigger();
		}

		private void RegisterStateTrigger(){
			_stateTriggerList.Add(EnemyStateType.Dizzy, Dizzy);
		}

		private void FixedUpdate(){
			EnemyCommand();
		}

		private void EnemyCommand(){
			if(_isDizzy) return;
			var targetList = _enemy.Detect<Character.Character>();
			var targetCount = targetList.Count;
			if(targetCount < 1){
				_enemy.Move(true);
			}
			else{
				var closestTarget = targetList.GetClosestTarget(transform.position);
				var targetTransform = closestTarget.transform;
				_enemy.Move(false);
				_enemy.SetTarget(targetTransform);
				_enemy.Attack();
			}
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

		private bool _isDizzy;

		private void Dizzy(bool enable){
			_isDizzy = enable;
			Debug.Log(enable ? $"Dizzy Enable" : $"DIzzy Disable");
		}
	}
}