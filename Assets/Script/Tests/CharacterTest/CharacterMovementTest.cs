using System.Collections;
using NUnit.Framework;
using Script.Main.Character;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Script.Tests.CharacterTest{
	public class CharacterMovementTest{

		[Test]
		public void MoveVelocity(){
			var gameObject = new GameObject();
			var movement = gameObject.AddComponent<CharacterMovement>();
		}

	}
}