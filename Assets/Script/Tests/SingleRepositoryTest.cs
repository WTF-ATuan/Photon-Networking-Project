using NUnit.Framework;
using Script.Main.Utility;

namespace Script.Tests{
	public class SingleRepositoryTest{
		public int TestValue;

		[Test]
		public void Query_Should_Create_New_Instance(){
			SingleRepository.Create<SingleRepositoryTest>();
			var current = SingleRepository.Query<SingleRepositoryTest>();
			Assert.NotNull(current);
		}

		[Test]
		public void Should_Create_New_Instance(){
			SingleRepository.Create<SingleRepositoryTest>();
			var current = SingleRepository.Query<SingleRepositoryTest>();
			Assert.NotNull(current);
		}

		[Test]
		public void Repeatedly_Query_ShouldBe_Same_instance(){
			SingleRepository.Create<SingleRepositoryTest>();
			var firstQuery = SingleRepository.Query<SingleRepositoryTest>();
			firstQuery.TestValue = 5;
			var secondQuery = SingleRepository.Query<SingleRepositoryTest>();
			Assert.AreEqual(firstQuery.TestValue, secondQuery.TestValue);
		}
	}
}