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
			var horizontal = 1;
			var vertical = 1;
			var speed = 10;
			var expect = new Vector2(horizontal, vertical) * speed;
			var current = movement.GetMoveVelocity(horizontal, vertical, speed);
			Assert.AreEqual(expect, current);
		}

		[Test]
		public void RollMove(){
			var gameObject = new GameObject();
			var movement = gameObject.AddComponent<CharacterMovement>();
			var originPosition = new Vector2(1, 1);
			var direction = new Vector2(1, 1);
			var force = 10;
			var expect = originPosition + (direction * 10);
			var current = movement.GetRollTargetPosition(originPosition, direction, force);
			Assert.AreEqual(expect, current);
		}
	}
}