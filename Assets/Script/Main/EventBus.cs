using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Main{
	public class EventBus : MonoBehaviour{
		private static readonly Dictionary<Type, List<Action<object>>> CallbackActions =
				new Dictionary<Type, List<Action<object>>>();

		public static void Subscribe<T>(Action<T> callback){
			var type = typeof(T);
			var containsKey = CallbackActions.ContainsKey(type);
			if(containsKey){
				var actions = CallbackActions[type];
				actions.Add(o => callback((T)o));
			}
			else{
				var actions = new List<Action<object>>{ o => callback((T)o) };
				CallbackActions.Add(type, actions);
			}
		}

		public static void Post<T>(T obj){
			var type = typeof(T);
			var containsKey = CallbackActions.ContainsKey(type);
			if(containsKey){
				var actions = CallbackActions[type];
				actions.ForEach(o => o.Invoke(obj));
			}
			else{
				var fullName = type.Name;
				Debug.Log($" Type {fullName}  is not Contain in EventBus");
			}
		}


		private void OnDisable(){
			CallbackActions.Clear();
		}
	}
}