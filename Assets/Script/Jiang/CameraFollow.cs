using Script.Main;
using Script.Main.Character.Event;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Jiang{
	public class CameraFollow : MonoBehaviour{
		public Transform player;
		public float smoothing = 5f; //鏡頭平滑移動的速度
		private Vector3 _offset; //相機和主角之間的固定距離

		private void Start(){
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
		}

		private void OnCharacterCreated(CharacterCreated obj){
			var character = obj.Character;
			player = character.transform;
			_offset = transform.position - player.position;
		}

		private void FixedUpdate(){
			if(!player) return;
			var targetCampos = player.position + _offset;
			transform.position =
					Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime); //以一定的速度，從A平滑移動到B
		}
	}
}