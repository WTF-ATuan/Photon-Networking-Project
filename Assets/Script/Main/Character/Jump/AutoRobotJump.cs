using System.Collections;
using System.Linq;
using Script.Main.Character.Interface;
using Script.Main.Enemy.Extension;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Main.Character.Jump{
	[RequireComponent(typeof(Rigidbody2D))]
	public class AutoRobotJump : MonoBehaviour, IJump{
		private Rigidbody2D _rigidbody2D;

		[SerializeField] private float coldDown = 12f;
		
		[Header("ViewObject")] [SerializeField]
		private GameObject robotViewPrefab;

		private GameObject _robotObject;

		private Enemy.Enemy _robot;

		private ColdDownTimer _timer;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_robotObject = Instantiate(robotViewPrefab, transform.position, Quaternion.identity);
			_robot = _robotObject.GetComponent<Enemy.Enemy>();
			_timer = new ColdDownTimer(coldDown);
			DestroyRobot();
		}

		private void DestroyRobot(){
			_robotObject.transform.position = Vector3.zero;
			_robotObject.SetActive(false);
		}

		public bool CanJump(IGround groundCondition){
			var isGrounded = groundCondition.IsGrounded();
			return isGrounded;
		}

		public void Jump(float directionX, float jumpForce){
			if(_timer.CanInvoke()){
				ActiveRobot();
			}
			var jumpDirection = new Vector2(directionX, 1f) * jumpForce;
			_rigidbody2D.AddForce(jumpDirection, ForceMode2D.Impulse);
		}

		private Coroutine _activating;

		private void ActiveRobot(){
			_robotObject.transform.position = transform.position + Vector3.up;
			_robotObject.SetActive(true);
			if(_activating != null){
				StopCoroutine(_activating);
			}

			_activating = StartCoroutine(Activating());
			_timer.Reset();
		}

		private IEnumerator Activating(){
			var times = 0;
			while(times <= 14){
				var enemies = _robot.Detect<Enemy.Enemy>();
				var enemiesIsEmpty = enemies.Count < 1;
				if(!enemiesIsEmpty){
					var firstEnemy = enemies.GetClosestTarget(transform.position);
					_robot.Attack(firstEnemy.transform);
				}

				times++;
				yield return new WaitForSeconds(0.5f);
			}

			DestroyRobot();
		}
	}
}