using System;
using System.Collections.Generic;
using Photon.Bolt;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Character.Attack{
	public class SkillEntityPool{
		private readonly List<BoltEntity> _entities = new List<BoltEntity>();

		public SkillEntityPool(GameObject prefab, Vector3 spawnPosition, Quaternion rotation, int maxCount){
			for(var i = 0; i < maxCount; i++){
				var skillObjectClone = BoltNetwork.Instantiate(prefab, spawnPosition, rotation);
				skillObjectClone.gameObject.SetActive(false);
				_entities.Add(skillObjectClone);
			}
		}

		public void SubscribeSkillTriggered(Action<BoltEntity> skillEntity){
			foreach(var boltEntity in _entities){
				boltEntity.OnTriggerEnter2DAsObservable()
						.Subscribe(x => skillEntity(boltEntity))
						.AddTo(boltEntity.gameObject);
			}
		}
	}
}