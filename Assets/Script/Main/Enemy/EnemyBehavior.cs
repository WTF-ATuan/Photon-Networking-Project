using Script.Main.Character;
using Script.Main.Utility;

namespace Script.Main.Enemy{
	public class EnemyBehavior{
		private EnemyRepository _enemyRepository;
		private CharacterRepository _characterRepository;

		public EnemyBehavior(){
			_enemyRepository = SingleRepository.Query<EnemyRepository>();
			_characterRepository = SingleRepository.Query<CharacterRepository>();
		}
	}
}