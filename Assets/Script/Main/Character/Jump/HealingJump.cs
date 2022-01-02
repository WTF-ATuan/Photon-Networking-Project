using System;
using System.Collections;
using System.Collections.Generic;
using Script.Main.Character.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Character.Jump{
	[RequireComponent(typeof(Rigidbody2D))]
	public class HealingJump : MonoBehaviour, IJump{
		private Rigidbody2D _rigidbody2D;

		[Header("ViewObject")] [SerializeField]
		private GameObject healObjectViewPrefab;

		private GameObject _healObject;
		private Character _character;

		private readonly List<Character> _areaCharacters = new List<Character>();

		private void Start(){
			_character = GetComponent<Character>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_healObject = Instantiate(healObjectViewPrefab, transform.position, Quaternion.identity);
			_healObject.OnCollisionEnter2DAsObservable()
					.Subscribe(OnHealAreaEnter)
					.AddTo(_healObject);
			_healObject.OnCollisionExit2DAsObservable()
					.Subscribe(OnHealAreaExit)
					.AddTo(_healObject);

			DestroyHealArea();
		}

		private void OnHealAreaEnter(Collision2D other){
			var character = other.gameObject.GetComponent<Character>();
			if(character)
				_areaCharacters.Add(character);
		}

		private void OnHealAreaExit(Collision2D other){
			var character = other.gameObject.GetComponent<Character>();
			if(character)
				_areaCharacters.Remove(character);
		}

		public bool CanJump(IGround groundCondition){
			var isGrounded = groundCondition.IsGrounded();
			return isGrounded;
		}

		public void Jump(float directionX, float jumpForce){
			var jumpDirection = new Vector2(directionX, 1f) * jumpForce;
			_rigidbody2D.AddForce(jumpDirection, ForceMode2D.Impulse);
			_character.PlayAnimation("Jump", 1);
			ActiveHealArea();
		}

		private Coroutine _healingCoroutine;

		private void ActiveHealArea(){
			_healObject.transform.position = transform.position;
			_healObject.SetActive(true);
			if(_healingCoroutine != null){
				StopCoroutine(_healingCoroutine);
			}

			_healingCoroutine = StartCoroutine(Healing());
		}

		private IEnumerator Healing(){
			var times = 0;
			while(times <= 5){
				foreach(var character in _areaCharacters){
					character?.ModifyHp(+10);
				}

				times++;
				yield return new WaitForSeconds(1);
			}

			DestroyHealArea();
		}

		private void DestroyHealArea(){
			_healObject.transform.position = Vector3.zero;
			_healObject.SetActive(false);
		}
	}
}