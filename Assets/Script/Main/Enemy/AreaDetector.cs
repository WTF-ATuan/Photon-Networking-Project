using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Enemy{
	public class AreaDetector : MonoBehaviour{
		[SerializeField] private float detectRange;

		[SerializeField] [ReadOnly] private Vector2 detectLimitPointLeft;
		[SerializeField] [ReadOnly] private Vector2 detectLimitPointRight;

		private void Start(){
			ProgressLimitPoint();
		}
		
		public void ProgressLimitPoint(){
			var detectOffset = detectRange / 2;
			var position = transform.position;
			detectLimitPointLeft = new Vector2(position.x - detectOffset, position.y);
			detectLimitPointRight = new Vector2(position.x + detectOffset, position.y);
		}

		public List<T> Detect<T>(){
			var targetList = new List<T>();
			// ReSharper disable once Unity.PreferNonAllocApi
			var raycastHit2D = Physics2D.LinecastAll(detectLimitPointLeft, detectLimitPointRight);
			foreach(var raycastHit in raycastHit2D){
				var hitCollider = raycastHit.collider;
				var target = hitCollider.GetComponent<T>();
				if(target != null)
					targetList.Add(target);
			}

			return targetList;
		}

		private void OnDrawGizmos(){
			var detectObject = Detect<GameObject>();
			var lineColor = detectObject.Count > 0 ? Color.red : Color.green;
			Gizmos.color = lineColor;
			Gizmos.DrawLine(detectLimitPointLeft + (Vector2.up), detectLimitPointLeft);
			Gizmos.DrawLine(detectLimitPointRight + Vector2.up, detectLimitPointRight);
		}
	}
}