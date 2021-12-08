namespace Script.Main.Character.Interface{
	public interface IJump{
		bool CanJump(IGround groundCondition);

		void Jump(float directionX , float jumpForce);
	}
}