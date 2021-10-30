using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Utility{
	public class SingleRepository : MonoBehaviour{
		private static readonly Dictionary<Type, object> SingletonObjects = new Dictionary<Type, object>();

		public static TReturn QueryObject<TReturn>() where TReturn : new(){
			var type = typeof(TReturn);
			var containsKey = SingletonObjects.ContainsKey(type);
			if(containsKey){
				var singletonObject = SingletonObjects[type];
				return (TReturn)singletonObject;
			}
			else{
				CreateSingleObject<TReturn>();
				var singletonObject = SingletonObjects[type];
				return (TReturn)singletonObject;
			}
		}

		private static void CreateSingleObject<T>() where T : new(){
			var type = typeof(T);
			var singletonObject = new T();
			SingletonObjects.Add(type, singletonObject);
		}

		private void OnDisable(){
			SingletonObjects.Clear();
		}
	}
}