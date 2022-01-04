using System;
using System.Collections;
using Script.Main.Enemy.Extension;
using Script.Main.Enemy.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Main.Enemy.Attack{
	public class BossAttack : MonoBehaviour, IAttack{
		[SerializeField] private float attackColdDown = 2f;
		[SerializeField] private int attackDamage = 10;
		[SerializeField] private float attackDelay = 1f;
		[SerializeField] private UnityEvent onAttack;

		private ColdDownTimer _timer;
		private Enemy _enemy;

		private void Start(){
			_timer = new ColdDownTimer(attackColdDown);
			_enemy = GetComponent<Enemy>();
		}

		public bool IsReadyAttack(Transform targetTransform){
			var targetPosition = targetTransform.position;
			var position = transform.position;
			var direction = targetPosition - position;
			DetectAttackDirection(direction);
			var canInvoke = _timer.CanInvoke();
			return canInvoke;
		}

		private Coroutine _attackCoroutine;

		public void Attack(){
			onAttack?.Invoke();
			if(_attackCoroutine != null){
				StopCoroutine(_attackCoroutine);
			}

			_attackCoroutine = StartCoroutine(DelayAttack());
			_timer.Reset();
		}

		private IEnumerator DelayAttack(){
			yield return new WaitForSeconds(attackDelay);
			var targetList = _enemy.Detect<Character.Character>();
			var allTarget = targetList.GetAllTarget();
			foreach(var character in allTarget){
				character?.ModifyHp(-attackDamage);
			}
		}

		private void DetectAttackDirection(Vector3 direction){
			if(direction.x > 0) _enemy.SetFacingDirection(true);
			if(direction.x < 0) _enemy.SetFacingDirection(false);
		}
	}
}