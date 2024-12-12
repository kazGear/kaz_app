using CSLib.Lib;
using KazApi.Domain._Const;
using KazApi.Domain.DTO;
using KazApi.Repository;
using KazApi.Repository.sql;
using System.Linq.Expressions;

namespace KazApi.Controller.Service
{
    public class ShopService
    {
        private readonly IDatabase _posgre;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShopService(IConfiguration configuration)
        {
            _posgre = new PostgreSQL(configuration);
        }

        /// <summary>
        /// 店舗リスト取得
        /// </summary>
        public IEnumerable<ShopDTO> SelectShops(string loginId)
        {
            var param = new { login_id = loginId };

            return _posgre.Select<ShopDTO>(ShopSQL.SelectShops(), param);
        }

        /// <summary>
        /// 店舗リスト取得
        /// </summary>
        public IEnumerable<ItemDTO> SelectShopItems(string shopId)
        {
            var param = new { shop_id = shopId };

            return _posgre.Select<ItemDTO>(ShopSQL.SelectItems(), param);
        }
    }
}
