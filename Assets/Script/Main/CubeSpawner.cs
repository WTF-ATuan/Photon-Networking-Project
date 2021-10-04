
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Main{
	public class CubeSpawner : MonoBehaviour{

		[SerializeField] private GameObject cubePrefab;

		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			PhotonNetwork.Instantiate(cubePrefab.name, randomPosition, Quaternion.identity);
		}
	}
}