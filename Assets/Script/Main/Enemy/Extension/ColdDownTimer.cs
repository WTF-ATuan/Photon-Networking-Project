using UnityEngine;

namespace Script.Main.Enemy.Extension{
	public class ColdDownTimer{
		public float During{ get; private set; }
		private float TrackTime{ get; set; }

		public ColdDownTimer(float during){
			During = during;
			TrackTime = Time.time;
		}

		public void ModifyDuring(float during){
			if(during <= 0) return;
			During = during;
		}

		public bool CanInvoke(){
			var currentTime = Time.time;
			return currentTime > TrackTime;
		}

		public void ResetColdTimer(){
			var currentTime = Time.time;
			TrackTime = currentTime + During;
		}
	}
}