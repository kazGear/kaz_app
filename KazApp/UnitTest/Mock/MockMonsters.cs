using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockMonsters
    {
        public static readonly IMonster DamageSkillMonster = new Monster(
            new MonsterDTO()
            {
                MonsterId = "monster001",
                MonsterName = "DamageSkillMonster",
                MonsterType = 1,
                Hp = 100,
                MaxHp = 100,
                Attack = 20,
                DefaultAttack = 20,
                Speed = 18,
                DefaultSpeed = 18,
                Dodge = 10,
                DefaultDodge = 10,
                Week = 1
            },
            new List<ISkill>()
            {
                MockSkills.Damage001,
                MockSkills.Damage001,
                MockSkills.Damage002,
                MockSkills.Damage004,
                MockSkills.NoMove055,
                MockSkills.NoMove055
            },
            new List<IState>() { }
        );

        public static readonly IMonster HealSkillMonster = new Monster(
            new MonsterDTO()
            {
                MonsterId = "monster002",
                MonsterName = "HealSkillMonster",
                MonsterType = 1,
                Hp = 100,
                MaxHp = 100,
                Attack = 20,
                DefaultAttack = 20,
                Speed = 25,
                DefaultSpeed = 25,
                Dodge = 20,
                DefaultDodge = 20,
                Week = 1
            },
            new List<ISkill>()
            {
                MockSkills.Heal039,
                MockSkills.Heal039,
                MockSkills.Heal042,
                MockSkills.Heal043,
                MockSkills.NoMove055,
                MockSkills.NoMove055
            },
            new List<IState>() { }
        );
        
        public static readonly IMonster DeadMonster = new Monster(
            new MonsterDTO()
            {
                MonsterId = "monster003",
                MonsterName = "DeadMonster",
                MonsterType = 1,
                Hp = 0,
                MaxHp = 100,
                Attack = 20,
                DefaultAttack = 20,
                Speed = 25,
                DefaultSpeed = 25,
                Dodge = 20,
                DefaultDodge = 20,
                Week = 1
            },
            new List<ISkill>()
            {
                MockSkills.Damage001,
                MockSkills.Damage002,
                MockSkills.Damage004,
                MockSkills.NoMove055,
                MockSkills.NoMove055,
                MockSkills.NoMove055
            },
            new List<IState>() { }
        );
    }
}
