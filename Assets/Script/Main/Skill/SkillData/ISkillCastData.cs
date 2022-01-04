namespace Script.Main.Skill{
	public interface ISkillCastData{
		string SkillName{ get; }
		void CastSkill(SkillSpawnInfo spawnInfo);
	}
}