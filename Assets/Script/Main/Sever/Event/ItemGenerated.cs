using UnityEngine;

namespace Script.Main.Event{
	public class ItemGenerated{
		public string OwnerId{ get; }
		public GameObject Item{ get; }

		public ItemGenerated(string ownerId , GameObject item){
			OwnerId = ownerId;
			Item = item;
		}
	}
}