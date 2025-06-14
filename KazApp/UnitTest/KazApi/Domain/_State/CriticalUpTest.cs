﻿using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class CriticalUpTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;

        public CriticalUpTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.CRITICALUP]
                );
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "効果(critical: 10% >>> xx)")]
        public void UT001()
        {
            _monster.StateImpact(_logger);

            foreach (var skill in _monster.CurrentSkills())
                Assert.True(skill.Critical == 0.40);
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT003()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster, _logger);

            var log = _logger.DumpMemory();

            Assert.Contains("クリティカル率が元に", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT004()
        {
            IState state = MockStatus.CRITICALUP;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
