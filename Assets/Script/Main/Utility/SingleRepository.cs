using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Utility{
	public class SingleRepository : MonoBehaviour{
		private static readonly Dictionary<Type, object> SingletonObjects = new Dictionary<Type, object>();

		public static TReturn Query<TReturn>() where TReturn : new(){
			var type = typeof(TReturn);
			var containsKey = SingletonObjects.ContainsKey(type);
			if(!containsKey) throw new Exception($"{type.Name} is not in SingletonLists must create first");
			var singletonObject = SingletonObjects[type];
			return (TReturn)singletonObject;
		}

		public static void Create<T>() where T : new(){
			var type = typeof(T);
			var containsKey = SingletonObjects.ContainsKey(type);
			var singletonObject = new T();
			if(containsKey){
				SingletonObjects[type] = singletonObject;
			}
			else{
				SingletonObjects.Add(type, singletonObject);
			}
		}

		private void OnDisable(){
			SingletonObjects.Clear();
		}
	}
}