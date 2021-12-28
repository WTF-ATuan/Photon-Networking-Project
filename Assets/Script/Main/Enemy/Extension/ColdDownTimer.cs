﻿using UnityEngine;

namespace Script.Main.Enemy.Extension{
	public class ColdDownTimer{
		private float During{ get; set; }
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

		public void ResetColdDown(){
			var currentTime = Time.time;
			TrackTime = currentTime + During;
		}
	}
}