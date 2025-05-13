using KazApi.Domain._Const;
using KazApi.Domain._Factory;
using KazApi.Domain._Monster._Skill;
using KazApi.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Factory
{
    public class SkillFactoryTest
    {
        private readonly ITestOutputHelper _output;
        private readonly SkillFactory _factory;
        private readonly StateDTO _stateDto;

        private readonly SkillDTO _invalidSkillDto;
        private readonly SkillDTO _stateSkillDto;
        private readonly SkillDTO _healSkillDto;
        private readonly SkillDTO _rateDamageSkillDto;
        private readonly SkillDTO _deadSkillDto;
        private readonly SkillDTO _noMoveSkillDto;
        private readonly SkillDTO _damageSkillDto;

        public SkillFactoryTest(ITestOutputHelper output)
        {
            _output = output;

            var codeEntiteis = new List<CodeDTO>()
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
            _factory = new SkillFactory(codeEntiteis);
            _stateDto = new StateDTO();

            _invalidSkillDto = new SkillDTO()
            {
                SkillId = "invalidSkill",
                SkillName = "リジェネ",
                SkillType = -1,
                ElementType = -1,
                StateType = -1,
                TargetType = -1,
                Attack = 0,
                Weight = 20,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1,
            };
            _stateSkillDto = new SkillDTO()
            {
                SkillId = "skill043",
                SkillName = "リジェネ",
                SkillType = CSkillType.STATE.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.AUTOHEAL.VALUE,
                TargetType = CTarget.FRIEND_RANDOM.VALUE,
                Attack = 0,
                Weight = 20,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1,
            };
            _healSkillDto = new SkillDTO()
            {
                SkillId = "skill039",
                SkillName = "ケアル",
                SkillType = CSkillType.HEAL.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CTarget.FRIEND_RANDOM.VALUE,
                Attack = 20,
                Weight = 20,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1,
            };
            _rateDamageSkillDto = new SkillDTO()
            {
                SkillId = "skill036",
                SkillName = "グラビガ（必中）",
                SkillType = CSkillType.ATTACK_RATE.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CTarget.ENEMY_RANDOM.VALUE,
                Attack = 50, // ５０％ダメージ
                Weight = 30,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1,
            };
            _deadSkillDto = new SkillDTO()
            {
                SkillId = "skill038",
                SkillName = "デススペル（必中）",
                SkillType = CSkillType.DEAD.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CTarget.ENEMY_RANDOM.VALUE,
                Attack = 0,
                Weight = 40,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1
            };
            _noMoveSkillDto = new SkillDTO()
            {
                SkillId = "skill055",
                SkillName = "ミスをした",
                SkillType = CSkillType.NOT_MOVE.VALUE,
                ElementType = CElement.NONE.VALUE,
                StateType = CStateType.NONE.VALUE,
                TargetType = CStateType.NONE.VALUE,
                Attack = 0,
                Weight = 0,
                DefaultCritical = 0.0,
                Critical = 0.0,
                HitRate = 1,
            };
            _damageSkillDto = new SkillDTO()
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
        }

        [Fact(DisplayName = "スキルセット（各種スキル）を生成")]
        public void UT001()
        {
            IList<SkillDTO> invalidDto = new List<SkillDTO>() { _invalidSkillDto };

            try
            {
                _factory.Create(invalidDto);
                Assert.Fail();
            }
            catch
            { }

            IList<SkillDTO> dtos = new List<SkillDTO>()
            {
                _stateSkillDto, // 0
                _healSkillDto, // 1
                _rateDamageSkillDto, // 2
                _deadSkillDto, // 3
                _noMoveSkillDto, // 4
                _damageSkillDto // 5
            };

            IList<ISkill> skills = (IList<ISkill>)_factory.Create(dtos);

            Assert.True(skills[0] is StateSkill);
            Assert.True(skills[1] is HealSkill);
            Assert.True(skills[2] is RateDamageSkill);
            Assert.True(skills[3] is DeadSkill);
            Assert.True(skills[4] is NoMoveSkill);
            Assert.True(skills[5] is DamageSkill);
        }

    }
}
