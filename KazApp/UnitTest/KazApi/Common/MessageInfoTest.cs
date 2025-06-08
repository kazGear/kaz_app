using KazApi.Common._Log;
using KazApi.Domain._Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;

namespace UnitTest.KazApi.Common
{
    public class MessageInfoTest
    {
        private readonly IMonster _normalMonster;
        private readonly IMonster _deadMonster;
        private readonly ILog<BattleMetaData> _logger;

        public MessageInfoTest()
        {
            _normalMonster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    []
                );
            _deadMonster = new Monster
                (
                    MockMonsterParams.Dead,
                    MockSkillSets.AbsHitOnly,
                    []
                );

            _logger = new BattleLogger();
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "誰のターンか")]
        public void UT001()
        {
            MessageInfo.WhoseTurn(_normalMonster, _logger);

            var log = _logger.DumpMemory();
            var who = log[1]; // ログの中央

            Assert.True(log.Count == 3);
            Assert.Contains(_normalMonster.MonsterName, who.Message);
        }

        [Fact(DisplayName = "戦闘結果　未決着")]
        public void UT002()
        {
            var monsters = new List<IMonster>()
            {
                _normalMonster,
                _normalMonster
            };

            MessageInfo.BattleResult(monsters, _logger);
            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.True(log.Count == 0);
        }

        [Fact(DisplayName = "戦闘結果　勝者あり")]
        public void UT003()
        {
            var monsters = new List<IMonster>()
            {
                _deadMonster,
                _normalMonster
            };

            MessageInfo.BattleResult(monsters, _logger);
            var log = _logger.DumpMemory();
            var winner = log[2]; // ログの中央

            Assert.True(log.Count == 6);
            Assert.Contains(
                _normalMonster.MonsterName,
                winner.Message
                );
        }

        [Fact(DisplayName = "戦闘結果　全滅")]
        public void UT004()
        {
            var monsters = new List<IMonster>()
            {
                _deadMonster,
                _deadMonster
            };

            MessageInfo.BattleResult(monsters, _logger);
            var log = _logger.DumpMemory();

            Assert.True(log.Count == 2);
        }
    }
}
