using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = System.Object;

namespace Script.Main{
	public class EventBus : MonoBehaviour{
		private static readonly Dictionary<Type, List<Action<object>>> NonCallbackActions =
				new Dictionary<Type, List<Action<object>>>();

		private static readonly Dictionary<Type, List<object>> DynamicPostBuffer =
				new Dictionary<Type, List<object>>();

		private static readonly Dictionary<Type, List<Func<object, object>>> CallbackActions =
				new Dictionary<Type, List<Func<object, object>>>();

		public static void Subscribe<T>(Action<T> callback){
			var type = typeof(T);
			var containsKey = NonCallbackActions.ContainsKey(type);
			if(containsKey){
				var actions = NonCallbackActions[type];
				actions.Add(o => callback((T)o));
			}
			else{
				var actions = new List<Action<object>>{ o => callback((T)o) };
				NonCallbackActions.Add(type, actions);
			}
		}

		public static void InvokePostBuffer<T>(Action<T> callback){
			var type = typeof(T);
			var containsKey = DynamicPostBuffer.ContainsKey(type);
			if(!containsKey) return;
			var bufferObject = DynamicPostBuffer[type];
			foreach(T obj in bufferObject){
				callback.Invoke(obj);
			}
		}

		public static void Subscribe<T, TResult>(Func<T, TResult> callback){
			var type = typeof(T);
			var containsKey = CallbackActions.ContainsKey(type);
			if(containsKey){
				var callbackAction = CallbackActions[type];
				callbackAction.Add(o => callback((T)o));
			}
			else{
				var func = new List<Func<object, object>>{ o => callback((T)o) };
				CallbackActions.Add(type, func);
			}
		}

		public static void Post<T>(T obj){
			var type = typeof(T);
			var containsKey = NonCallbackActions.ContainsKey(type);
			if(containsKey){
				var actions = NonCallbackActions[type];
				actions.ForEach(o => o.Invoke(obj));
			}
			else{
				var fullName = type.Name;
				Debug.Log($" Type {fullName}  is not Contain in EventBus");
			}
		}

		public static void DynamicPost<T>(T obj){
			var type = typeof(T);
			var containsKey = NonCallbackActions.ContainsKey(type);
			if(containsKey){
				var actions = NonCallbackActions[type];
				actions.ForEach(o => o.Invoke(obj));
			}
			else{
				var bufferContain = DynamicPostBuffer.ContainsKey(type);
				if(bufferContain){
					var postObject = DynamicPostBuffer[type];
					postObject.Add(obj);
				}
				else{
					var postList = new List<object>{ obj };
					DynamicPostBuffer.Add(type, postList);
				}
			}
		}

		public static TResult Post<T, TResult>(T obj){
			var type = typeof(T);
			var containsKey = CallbackActions.ContainsKey(type);
			if(containsKey){
				var callbackAction = CallbackActions[type];
				foreach(var returnValue in callbackAction.Select(func => func.Invoke(obj))){
					return (TResult)returnValue;
				}
			}
			else{
				var fullName = type.Name;
				Debug.Log($" Type {fullName}  is not Contain in EventBus");
			}

			return default;
		}


		private void OnDisable(){
			NonCallbackActions.Clear();
			CallbackActions.Clear();
		}
	}
}