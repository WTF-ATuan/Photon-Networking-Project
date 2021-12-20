using UnityEngine;

namespace Script.Main.Server.Event{
	public class EntityAttached{
		public string EntityID{ get; }
		public GameObject Entity{ get; }

		public EntityAttached(string entityID, GameObject entity){
			EntityID = entityID;
			Entity = entity;
		}
	}
}