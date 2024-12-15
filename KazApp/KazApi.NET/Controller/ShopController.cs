using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KazApi.Controller.Service;
using KazApi.Repository;
using KazApi.Domain.DTO;

namespace KazApi.Controller
{
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _service;
        private readonly IDatabase _posgre;

        public ShopController(IConfiguration configuration)
        {
            _service = new ShopService(configuration);
            _posgre = new PostgreSQL(configuration);
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        [HttpPost("api/shop/init")]
        public ActionResult<string> Init([FromQuery] string loginId)
        {
            // ショップリストを取得
            IEnumerable<ShopDTO> shops = _service.SelectShops(loginId);
            return JsonConvert.SerializeObject(shops);
        }

        //
        /// <summary>
        /// 初期処理
        /// </summary>
        [HttpPost("api/shop/items")]
        public ActionResult<string> SelectShopItem([FromQuery] string? shopId)
        {
            if (shopId == null) return JsonConvert.SerializeObject(new List<string>());

            // ショップリストを取得
            IEnumerable<ItemDTO> shops = _service.SelectShopItems(shopId);
            return JsonConvert.SerializeObject(shops);
        }

        //[HttpPost("api/shop/purchase")]

    }
}
