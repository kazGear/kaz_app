
using KazApi.Domain.DTO;
using KazApi.Repository;
using KazApi.Repository.sql;

namespace KazApi.Controller.Service
{
    public class EditService
    {
        private readonly IDatabase _posgre;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditService(IConfiguration configuration)
        {
            _posgre = new PostgreSQL(configuration);
        }

        public IEnumerable<CodeDTO> FetchDropDown()
            => _posgre.Select<CodeDTO>(EditSQL.FetchDropDown());

        /// <summary>
        /// 編集用モンスターデータ
        /// </summary>
        public IEnumerable<EditMonsterDTO> FetchEditMonsters(string loginId)
        {
            var param = new { login_id = loginId };
            return _posgre.Select<EditMonsterDTO>(EditSQL.FetchEditMonsters(), param);
        }

        /// <summary>
        /// モンスターのステータスを設定する
        /// </summary>
        internal void UpdateMonsterStatus(IEnumerable<EditMonsterDTO> changeMonsters)
        {
            foreach (EditMonsterDTO monster in changeMonsters)
            {
                var param = new
                {
                    monster_id   = monster.MonsterId,
                    monster_name = monster.AfterName,
                    hp           = monster.AfterHp,
                    attack       = monster.AfterAttack,
                    speed        = monster.AfterSpeed,
                    week         = monster.AfterWeek
                };
                _posgre.Execute(EditSQL.UpdateMonsterStatus(), param);
            }
        }
    }
}
