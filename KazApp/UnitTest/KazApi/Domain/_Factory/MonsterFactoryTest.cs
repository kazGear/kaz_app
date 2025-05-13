using KazApi.Domain._Const;
using KazApi.Domain._Factory;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using KazApi.Domain.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Factory
{
    public class MonsterFactoryTest
    {
        private readonly ITestOutputHelper _output;
        private readonly MonsterFactory _factory;

        private IEnumerable<MonsterDTO> _monstersDTO;
        private IEnumerable<MonsterSkillDTO> _monsterSkillsDTO;
        private IEnumerable<SkillDTO> _skillsDTO;
        private IEnumerable<CodeDTO> _codeDTO;
        private SkillDTO _matchSkill;
        private SkillDTO _unmatchSkill;

        public MonsterFactoryTest(ITestOutputHelper output)
        {
            _output = output;
            _factory = new MonsterFactory();
            _codeDTO = new List<CodeDTO>()
            {
                new CodeDTO() { Value = CStateType.NONE.VALUE },
                new CodeDTO() { Value = CStateType.POISON.VALUE },
                new CodeDTO() { Value = CStateType.SLEEP.VALUE },
                new CodeDTO() { Value = CStateType.CHARM.VALUE },
                new CodeDTO() { Value = CStateType.SLOW.VALUE },
                new CodeDTO() { Value = CStateType.POWERUP.VALUE },
                new CodeDTO() { Value = CStateType.DODGEUP.VALUE },
                new CodeDTO() { Value = CStateType.CRITICALUP.VALUE },
                new CodeDTO() { Value = CStateType.AUTOHEAL.VALUE },
                new CodeDTO() { Value = CStateType.DEADLY_POISON.VALUE }
            };
            _monstersDTO = new List<MonsterDTO>() { MockMonsterParams.NoDodge };
            _monsterSkillsDTO = new List<MonsterSkillDTO>()
            {
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster001", SkillId = "skill001" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
                new() { MonsterId = "monster002", SkillId = "skill005" },
            };
            _matchSkill = new SkillDTO()
            {
                SkillId = "skill001",
                SkillName = "打撃（必中）",
                SkillType = CSkillType.BLOW.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CTarget.ENEMY_RANDOM.VALUE,
                Attack = 10,
                Weight = 10,
                DefaultCritical = 0.1,
                Critical = 0.1,
                HitRate = 1.0,
            };
            _unmatchSkill = new SkillDTO()
            {
                SkillId = "skill005",
                SkillName = "回し蹴り（必中全体）",
                SkillType = CSkillType.BLOW.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CTarget.ENEMY_ALL.VALUE,
                Attack = 10,
                Weight = 10,
                DefaultCritical = 0.1,
                Critical = 0.1,
                HitRate = 1.0,
            };
            _skillsDTO = new List<SkillDTO>() { _matchSkill, _unmatchSkill };
        }

        [Fact(DisplayName = "モンスターとスキルのマッピング")]
        public void UT001()
        {
            var monsters = _factory.MappingToMonsterDTO(
                _monstersDTO, _skillsDTO, _monsterSkillsDTO
            );

            foreach (var monster in monsters)
            {
                if (monster.MonsterId != "monster001") continue;
                foreach (var skill in monster.Skills)
                {
                    Assert.True(skill.SkillId == "skill001");
                }
            }
        }

        [Fact(DisplayName = "戦闘用モンスタ－構築")]
        public void UT002()
        {
            foreach (var monsterDTO in _monstersDTO)
            {
                monsterDTO.Skills = new List<SkillDTO>()
                { 
                    _matchSkill, // 何でも良い
                    _matchSkill,
                    _matchSkill,
                    _matchSkill,
                    _matchSkill,
                    _matchSkill
                };
            }

            var monsters = _factory.CreateBattleMonsters(_monstersDTO, _codeDTO);

            Assert.True(monsters.Count() > 0);
            foreach (var monster in monsters)
            {
                Assert.True(monster.CurrentSkills().Count() > 0);
                Assert.True(monster.CurrentStatus().Count() == 0);
            }
        }
    }
}
