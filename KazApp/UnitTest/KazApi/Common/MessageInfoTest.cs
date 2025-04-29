using KazApi.Common._Log;
using KazApi.Domain._Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;

namespace UnitTest.KazApi.Common
{
    public class MessageInfoTest
    {
        public MessageInfoTest()
        {

        }

        [Fact(DisplayName = "誰のターンか")]
        public void UT001()
        {
            var monster = MockMonsters.DamageSkillMonster;
            MessageInfo.WhoseTurn(monster);

            var logger = new BattleLogger();
            var log = logger.DumpMemory();
            var who = log[1]; // ログの中央

            Assert.True(log.Count == 3);
            Assert.Contains(monster.MonsterName, who.Message);
        }

        [Fact(DisplayName = "戦闘結果　未決着")]
        public void UT002()
        {
            var monsters = new List<IMonster>()
            {
                MockMonsters.HealSkillMonster,
                MockMonsters.DamageSkillMonster
            };

            MessageInfo.BattleResult(monsters);
            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.True(log.Count == 0);
        }

        [Fact(DisplayName = "戦闘結果　勝者あり")]
        public void UT003()
        {
            var monsters = new List<IMonster>()
            {
                MockMonsters.DeadMonster,
                MockMonsters.DamageSkillMonster
            };

            MessageInfo.BattleResult(monsters);
            var logger = new BattleLogger();
            var log = logger.DumpMemory();
            var winner = log[2]; // ログの中央

            Assert.True(log.Count == 6);
            Assert.Contains(
                MockMonsters.DamageSkillMonster.MonsterName,
                winner.Message
                );
        }

        [Fact(DisplayName = "戦闘結果　全滅")]
        public void UT004()
        {
            var monsters = new List<IMonster>()
            {
                MockMonsters.DeadMonster,
                MockMonsters.DeadMonster
            };

            MessageInfo.BattleResult(monsters);
            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.True(log.Count == 2);
        }
    }
}
