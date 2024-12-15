namespace KazApi.Domain.DTO
{
    /// <summary>
    /// コードパラメータ for DB
    /// </summary>
    public class ItemDTO
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Remarks { get; set; }
        public string ItemImage { get; set; }
        public bool IsPurchased { get; set; }
    }
}
