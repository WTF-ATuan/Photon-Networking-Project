namespace Script.Main.Enemy.Event{
	public class EnemyDead{
		public string EnemyID{ get; }

		public EnemyDead(string enemyID){
			EnemyID = enemyID;
		}
	}
}