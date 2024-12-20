using KazApi.Domain._Const;
using System.Security.Policy;

namespace KazApi.Repository.sql
{
    /// <summary>
    /// SQL文格納クラス
    /// </summary>
    public static class EditSQL
    {
        public static string FetchDropDown()
        {
            string SQL = @$"
                SELECT value   AS VALUE
                     , name    AS Name
                  FROM m_code
                 WHERE code_id = '{CCodeType.EDIT.VALUE}'
            ";
            return SQL;
        }

        public static string FetchEditMonsters()
        {
            string SQL = @$"
                SELECT monster.monster_id AS MonsterId
                     , monster.monster_name AS MonsterName
                     , monster.monster_type AS MonsterType
                     , monster_type.name AS MonsterTypeName 
                     , monster.hp AS Hp
                     , monster.attack AS Attack
                     , monster.speed AS Speed
                     , monster.week AS Week
                     , week.name AS WeekName
                  FROM m_user AS ""user""
            INNER JOIN t_my_item AS item
                    ON item.login_id = ""user"".login_id
            INNER JOIN m_monster AS monster
                    ON item.item_id = 'monsterType' || lpad(monster.monster_type::text, 3, '0')
            INNER JOIN m_code AS monster_type
                    ON monster_type.code_id = 'code006'
                   AND monster_type.value = monster.monster_type
            INNER JOIN m_code AS week
                    ON week.code_id = 'code001'
                   AND week.value = monster.week
                 WHERE ""user"".login_id = @login_id
              ORDER BY monster.monster_id ASC ;
            ";
            return SQL;
        }

        public static string UpdateMonsterStatus()
        {
            string SQL = @"
                UPDATE m_monster
                   SET monster_name = @monster_name 
                     , hp           = @hp
                     , attack       = @attack
                     , speed        = @speed
                     , week         = @week
                 WHERE monster_id = @monster_id ;
            ";
            return SQL;
        }

        public static string InitAllMonsterStatus()
        {
            string SQL = @"
                TRUNCATE m_monster;
             INSERT INTO m_monster 
             (
                  SELECT * 
                    FROM m_monster_origin
             ) ;
            ";
            return SQL;
        }
    }
}
