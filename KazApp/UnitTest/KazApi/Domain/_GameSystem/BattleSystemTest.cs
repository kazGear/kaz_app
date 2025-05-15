using KazApi.Domain._Const;
using KazApi.Domain._Factory;
using KazApi.Domain._GameSystem;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._GameSystem
{
    public class BattleSystemTest
    {
        private readonly ITestOutputHelper _output;
        private IEnumerable<IMonster> _monsters;

        public BattleSystemTest(ITestOutputHelper output)
        {
            _output = output;
            _monsters = new List<IMonster>()
            {
                new Monster(
                    MockMonsterParams.Normal,
                    MockSkillSets.HealOnly,
                    []
                    ),
                new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.NoMoveOnly,
                    []
                    ),
              new Monster(
                    MockMonsterParams.Dead,
                    MockSkillSets.AbsHitOnly,
                    []
                    )
            };
        }

        [Fact(DisplayName = "モンスターを選択する")]
        public void UT001()
        {
            int monster001 = 0;
            int monster002 = 0;
            int monsterDead = 0;

            for (int i = 0; i < 100; i++)
            {
                var monster = BattleSystem.SelectOneEnemy(_monsters);

                if (monster.MonsterId == "monster001")
                    monster001++;
                else if (monster.MonsterId == "monster002")
                    monster002++;
                else
                    monsterDead++; // 選択されないはず
            }
            
            Assert.True(monster001 > 0);
            Assert.True(monster002 > 0);
            Assert.True(monsterDead == 0);
        }

        [Fact(DisplayName = "戦闘モンスターを選出")]
        public void UT002_1()
        {
            IEnumerable<IMonster> monsters = new List<IMonster>()
            {
                _monsters.ElementAt(0),
                _monsters.ElementAt(1),
            };

            var selectedMonsters = BattleSystem.MonsterSelector(monsters, 2);

            Assert.True(selectedMonsters.Count() == 2);
        }

        [Fact(DisplayName = "戦闘モンスターを選出（不足）")]
        public void UT002_2()
        {
            IEnumerable<IMonster> monsters = new List<IMonster>()
            {
                _monsters.ElementAt(0),
            };

            try
            {
                var selectedMonsters = BattleSystem.MonsterSelector(monsters, 1);
                Assert.Fail();
            }
            catch { }
        }

        [Fact(DisplayName = "行動順を決定する")]
        public void UT003()
        {
            Assert.True(_monsters.ElementAt(0).MonsterId == "monster001");
            Assert.True(_monsters.ElementAt(2).MonsterId == "monster003"); // 除外されるはず

            var orderedMonsters = BattleSystem.ActionOrder(_monsters);

            Assert.True(orderedMonsters.ElementAt(0).MonsterId == "monster002");
            Assert.True(orderedMonsters.ElementAt(1).MonsterId == "monster001");
        }

        [Fact(DisplayName = "状態の解除判定")]
        public void UT004()
        {
            int enableCount = 0;
            int disableCount = 0;

            for (int i = 0; i < 1000; i++)
            {
                var state = MockStatus.DEADLY_POISON;
                bool result = BattleSystem.StateIsDisabled(state);

                if (result) disableCount++;
                else enableCount++;
            }

            Assert.True(disableCount > 400);
            Assert.True(enableCount > 400);
        }

        [Fact(DisplayName = "掛け金レート：モンスター数で倍率変動")]
        public void UT005()
        {
            var twoMonsters = new List<MonsterDTO>()
            {
                MockMonsterParams.Normal, MockMonsterParams.NoDodge
            };
            var threeMonsters = new List<MonsterDTO>()
            {
                MockMonsterParams.Normal, MockMonsterParams.NoDodge, MockMonsterParams.Dead
            };

            BattleSystem.CalcBetRate(twoMonsters);
            var twoMonstersRate = twoMonsters[0].BetRate;
            BattleSystem.CalcBetRate(threeMonsters);
            var threeMonstersRate = threeMonsters[0].BetRate;

            Assert.True(twoMonstersRate < threeMonstersRate);
        }
    }
}
