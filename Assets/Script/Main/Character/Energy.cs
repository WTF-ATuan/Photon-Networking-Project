namespace Script.Main.Character{
	public class Energy{
		public string OwnerID{ get; }
		private float EnergyValue{ get; set; }


		public Energy(string ownerID , float energyValue){
			OwnerID = ownerID;
			EnergyValue = energyValue;
		}
		
		public void ModifyEnergyValue(float amount){
			EnergyValue -= amount;
		}

		public float GetCurrentEnergyValue(){
			return EnergyValue;
		}
	}
}