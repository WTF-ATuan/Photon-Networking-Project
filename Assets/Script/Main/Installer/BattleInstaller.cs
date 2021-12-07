using Script.Main.Character;
using Script.Main.Enemy;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Installer{
	public class BattleInstaller : MonoBehaviour{
		private void Awake(){
			SingleRepository.Create<CharacterRepository>();
			SingleRepository.Create<CharacterEventHandler>();
			SingleRepository.Create<EnemyRepository>();
		}
	}
}