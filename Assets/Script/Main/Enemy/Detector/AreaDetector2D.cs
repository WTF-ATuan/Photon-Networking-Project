using Script.Main.Enemy.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Enemy.Detector{
	public class AreaDetector2D : MonoBehaviour, IDetector{
		[SerializeField] private float detectRange;
		[SerializeField] private float centerPointOffsetY = 1f;
		[SerializeField] private float boxRaySizeOffsetY = 1f;


		[SerializeField] [ReadOnly] private Vector2 detectLimitPointLeft;
		[SerializeField] [ReadOnly] private Vector2 detectLimitPointRight;

		private Vector3 _centerPosition;

		public void ProgressLimitPoint(){
			var detectOffset = detectRange / 2;
			var position = transform.position;
			_centerPosition = new Vector3(position.x, position.y + centerPointOffsetY, position.z);
			detectLimitPointLeft = new Vector2(_centerPosition.x - detectOffset, _centerPosition.y);
			detectLimitPointRight = new Vector2(_centerPosition.x + detectOffset, _centerPosition.y);
		}

		public TargetList<T> Detect<T>() where T : Component{
			ProgressLimitPoint();
			var targetList = new TargetList<T>();
			var offsetX = Vector2.Distance(detectLimitPointRight, detectLimitPointLeft);
			// ReSharper disable once Unity.PreferNonAllocApi
			var raycastHit2D = Physics2D.BoxCastAll(_centerPosition, new Vector2(offsetX, boxRaySizeOffsetY), 0,
				Vector2.zero);
			foreach(var raycastHit in raycastHit2D){
				var hitCollider = raycastHit.collider;
				var target = hitCollider.GetComponent<T>();
				if(target != null)
					targetList.SaveTarget(target);
			}

			var selfComponent = GetComponent<T>();
			if(selfComponent) targetList.RemoveTarget(selfComponent);

			return targetList;
		}

		private void OnDrawGizmos(){
			var detectObject = Detect<Transform>();
			var lineColor = detectObject.Count > 0 ? Color.red : Color.green;
			Gizmos.color = lineColor;
			var offsetX = Vector2.Distance(detectLimitPointRight, detectLimitPointLeft);
			Gizmos.DrawWireCube(_centerPosition, new Vector3(offsetX, boxRaySizeOffsetY , 0));
		}
	}
}