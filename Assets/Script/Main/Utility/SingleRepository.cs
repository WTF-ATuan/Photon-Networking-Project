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
				var singletonObject = new TReturn();
				SingletonObjects.Add(type, singletonObject);
				return singletonObject;
			}
		}

	}
}