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
        public IEnumerable<MonsterDTO> FetchEditMonsters(string loginId)
        {
            var param = new { login_id = loginId };
            return _posgre.Select<MonsterDTO>(EditSQL.FetchEditMonsters(), param);
        }
    }
}
