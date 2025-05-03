using KazApi.Common._Log;
using KazApi.Domain._Monster;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Common
{
    public class BattleMetaDataTest
    {
        public BattleMetaDataTest()
        {

        }

        [Fact(DisplayName = "コンストラクタ1")]
        public void UT001()
        {
            BattleMetaData data = new BattleMetaData();
            Assert.True(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ2")]
        public void UT002()
        {
            BattleMetaData data = new BattleMetaData("test message.");

            Assert.Equal("test message.", data.Message);
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ3")]
        public void UT003()
        {
            BattleMetaData data = new BattleMetaData(
                "monster01",
                "test message."
                );
            Assert.Equal("monster01", data.TargetMonsterId);
            Assert.Equal("test message.", data.Message);
            Assert.True(!data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ4_1")]
        public void UT004_1()
        {
            BattleMetaData data = new BattleMetaData(
                true,
                false,
                new Monster
                    (
                        MockMonsterParams.NormalParam,
                        MockSkillSets.AttackOnly,
                        []
                    )
                );
            Assert.True(data.ExistWinner);
            Assert.False(data.AllLoser);
            Assert.True(data.IsStop);
            Assert.True(data.TargetMonsterId == "monster001");
            Assert.True(data.WinnerMonsterId == "monster001");
            Assert.True(data.WinnerMonsterName == "NormalParamMonster");
        }

        [Fact(DisplayName = "コンストラクタ4_2")]
        public void UT004_2()
        {
            BattleMetaData data = new BattleMetaData(
                false,
                false,
                null
                );
            Assert.False(data.ExistWinner);
            Assert.False(data.AllLoser);
            Assert.True(data.IsStop);
            Assert.True(data.TargetMonsterId == "");
            Assert.True(data.WinnerMonsterId == "");
            Assert.True(data.WinnerMonsterName == "");
        }

        [Fact(DisplayName = "コンストラクタ5")]
        public void UT005()
        {
            BattleMetaData data = new BattleMetaData(
                "targetMonsterId",
                "skillId",
                1000,
                "message."
                );
            Assert.True(data.TargetMonsterId == "targetMonsterId");
            Assert.True(data.SkillId == "skillId");
            Assert.True(data.EffectTime == 1000);
            Assert.True(data.Message == "message.");
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ6")]
        public void UT006()
        {
            BattleMetaData data = new BattleMetaData(
                "targetMonsterId",
                false,
                "stateShortName",
                "message."
                );
            Assert.True(data.TargetMonsterId == "targetMonsterId");
            Assert.False(data.DisableState);
            Assert.True(data.StateName == "stateShortName");
            Assert.True(data.Message == "message.");
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ7")]
        public void UT007()
        {
            BattleMetaData data = new BattleMetaData(
                "taegetMonsterId",
                "skillId",
                100,
                50,
                "message..."
                );
            Assert.True(data.TargetMonsterId == "taegetMonsterId");
            Assert.True(data.SkillId == "skillId");
            Assert.True(data.BeforeHp == 100);
            Assert.True(data.ImpactPoint == 50);
            Assert.True(data.Message == "message...");
            Assert.True(data.EffectTime == 1000);
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ8")]
        public void UT008()
        {
            BattleMetaData data = new BattleMetaData(
                "targetMonsterId",
                "skillId",
                777,
                "stateName",
                false,
                "message.."
                );
            Assert.True(data.TargetMonsterId == "targetMonsterId");
            Assert.True(data.SkillId == "skillId");
            Assert.True(data.EffectTime == 777);
            Assert.True(data.StateName == "stateName");
            Assert.False(data.EnableState);
            Assert.True(data.Message == "message..");
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ9")]
        public void UT009()
        {
            BattleMetaData data = new BattleMetaData(
                "targetMonsterId",
                100,
                90,
                "skillId",
                800,
                "message"
                );
            Assert.True(data.TargetMonsterId == "targetMonsterId");
            Assert.True(data.BeforeHp == 100);
            Assert.True(data.ImpactPoint == 90);
            Assert.True(data.SkillId == "skillId");
            Assert.True(data.EffectTime == 800);
            Assert.True(data.Message == "message");
            Assert.False(data.IsStop);
        }

        [Fact(DisplayName = "コンストラクタ10")]
        public void UT0010()
        {
            BattleMetaData data = new BattleMetaData(
                "targetMonsterId",
                50,
                30,
                "skillId",
                900,
                true,
                "message"
                );
            Assert.True(data.TargetMonsterId == "targetMonsterId");
            Assert.True(data.BeforeHp == 50);
            Assert.True(data.ImpactPoint == 30);
            Assert.True(data.SkillId == "skillId");
            Assert.True(data.EffectTime == 900);
            Assert.True(data.IsDodge);
            Assert.True(data.Message == "message");
            Assert.False(data.IsStop);
        }
    }
}
