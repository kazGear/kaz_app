using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockMonsterParams
    {
        public static readonly MonsterDTO Normal = new ()
        {
            MonsterId = "monster001",
            MonsterName = "NormalParamMonster",
            MonsterType = 1,
            Hp = 100,
            MaxHp = 100,
            Attack = 20,
            DefaultAttack = 20,
            Speed = 15,
            DefaultSpeed = 15,
            Dodge = 0.1,
            DefaultDodge = 0.1,
            Week = 0
        };

        public static readonly MonsterDTO NoDodge = new()
        {
            MonsterId = "monster002",
            MonsterName = "NoDodgeMonster",
            MonsterType = 1,
            Hp = 100,
            MaxHp = 100,
            Attack = 20,
            DefaultAttack = 20,
            Speed = 15,
            DefaultSpeed = 15,
            Dodge = 0.0,
            DefaultDodge = 0.0,
            Week = 0
        };

        public static readonly MonsterDTO Dead = new()
        {
            MonsterId = "monster003",
            MonsterName = "DeadMonster",
            MonsterType = 1,
            Hp = 0,
            MaxHp = 100,
            Attack = 20,
            DefaultAttack = 20,
            Speed = 15,
            DefaultSpeed = 15,
            Dodge = 0.1,
            DefaultDodge = 0.1,
            Week = 0
        };

        public static readonly MonsterDTO WeekFire = new()
        {
            MonsterId = "monster004",
            MonsterName = "WeekFireMonster",
            MonsterType = 1,
            Hp = 100,
            MaxHp = 100,
            Attack = 20,
            DefaultAttack = 20,
            Speed = 15,
            DefaultSpeed = 15,
            Dodge = 0.0,
            DefaultDodge = 0.0,
            Week = 1
        };

        public static readonly MonsterDTO DyingHp = new()
        {
            MonsterId = "monster054",
            MonsterName = "DyingMonster",
            MonsterType = 1,
            Hp = 1,
            MaxHp = 100,
            Attack = 20,
            DefaultAttack = 20,
            Speed = 15,
            DefaultSpeed = 15,
            Dodge = 0.0,
            DefaultDodge = 0.0,
            Week = 1
        };
    }
}
