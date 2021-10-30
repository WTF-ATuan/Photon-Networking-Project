using NUnit.Framework;
using Script.Main.Utility;

namespace Script.Tests{
	public class SingleRepositoryTest{
		public int TestValue;

		[Test]
		public void Query_Should_Create_New_Instance(){
			var current = SingleRepository.QueryObject<SingleRepositoryTest>();
			Assert.NotNull(current);
		}

		[Test]
		public void Repeatedly_Query_ShouldBe_Same_instance(){
			var firstQuery = SingleRepository.QueryObject<SingleRepositoryTest>();
			firstQuery.TestValue = 5;
			var secondQuery = SingleRepository.QueryObject<SingleRepositoryTest>();
			Assert.AreEqual(firstQuery.TestValue, secondQuery.TestValue);
		}
	}
}