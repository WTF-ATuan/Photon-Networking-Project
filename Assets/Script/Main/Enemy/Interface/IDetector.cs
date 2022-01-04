using System.Collections.Generic;
using Script.Main.Enemy.Detector;
using UnityEngine;

namespace Script.Main.Enemy.Interface{
	public interface IDetector{
		TargetList<T> Detect<T>(int layer = default) where T : Component;
	}
}