using StepanovAlexandrKt_41_21.Models;
namespace StepanovAlexandrKt_41_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-31-20"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}