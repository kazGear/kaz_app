namespace KazApi.Domain.DTO
{
    /// <summary>
    /// コードパラメータ for DB
    /// </summary>
    public class ShopDTO
    {
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public int WinMoneyUntilCanUse { get; set; }
    }

}
