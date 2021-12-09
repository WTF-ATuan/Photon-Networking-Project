using System.Collections;
using System.Linq;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character.Jump{
	[RequireComponent(typeof(Rigidbody2D))]
	public class AutoRobotJump : MonoBehaviour, IJump{
		private Rigidbody2D _rigidbody2D;

		[Header("ViewObject")] [SerializeField]
		private GameObject robotViewPrefab;

		private GameObject _robotObject;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_robotObject = Instantiate(robotViewPrefab, transform.position, Quaternion.identity);
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
			ActiveRobot();
			var jumpDirection = new Vector2(directionX, 1f) * jumpForce;
			_rigidbody2D.AddForce(jumpDirection, ForceMode2D.Impulse);
		}

		private Coroutine _activating;

		private void ActiveRobot(){
			_robotObject.transform.position = transform.position;
			_robotObject.SetActive(true);
			if(_activating != null){
				StopCoroutine(_activating);
			}
			
			_activating = StartCoroutine(Activating());
		}

		private IEnumerator Activating(){
			var times = 0;
			var robot = _robotObject.GetComponent<Enemy.Enemy>();
			while(times <= 14){
				var enemies = robot.Detect<Enemy.Enemy>();
				var firstEnemy = enemies.GetClosestTarget(transform.position);
				robot.SetTarget(firstEnemy.transform);
				robot.Attack();
				times++;
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}