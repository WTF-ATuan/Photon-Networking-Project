using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Enemy.Detector{
	public class TargetList<T> where T : Component{
		private readonly List<T> _targetList = new List<T>();
		public int Count => _targetList.Count;

		public void SaveTarget(T target){
			_targetList.Add(target);
		}

		public void RemoveTarget(T target){
			var contains = _targetList.Contains(target);
			if(contains)
				_targetList.Remove(target);
		}

		public T GetClosestTarget(Vector3 position){
			var minDistance = float.PositiveInfinity;
			T closestTarget = null;
			foreach(var target in _targetList){
				var targetPosition = target.transform.position;
				var distance = Vector3.Distance(position, targetPosition);
				if(!(distance < minDistance)) continue;
				closestTarget = target;
				minDistance = distance;
			}

			return closestTarget;
		}
	}
}