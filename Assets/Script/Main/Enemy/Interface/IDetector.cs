using System.Collections.Generic;

namespace Script.Main.Enemy.Interface{
	public interface IDetector{
		List<T> Detect<T>();
	}
}