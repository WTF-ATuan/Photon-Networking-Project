using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Main{
	public class CubeSpawner : MonoBehaviour{
		[SerializeField] private GameObject cubePrefab;
		[SerializeField] private Sever sever;

		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var id = gameObject.GetInstanceID().ToString();
			sever.GenerateItem(cubePrefab.name, randomPosition, Quaternion.identity, id);
		}
	}
}