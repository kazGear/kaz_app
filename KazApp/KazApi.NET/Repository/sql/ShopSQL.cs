using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KazApi.Repository.sql
{
    /// <summary>
    /// SQL文格納クラス
    /// </summary>
    public static class ShopSQL
    {
        public static string SelectShops()
        {
            string SQL = @"
                SELECT s.shop_id   AS ShopId
                     , s.shop_name AS ShopName
                  FROM m_user AS u
            INNER JOIN m_available_stores AS ""as""
                    ON ""as"".login_id = u.login_id
            INNER JOIN m_shop AS s
                    ON s.shop_id = ""as"".shop_id
                 WHERE u.login_id = @login_id ;
            ";
            return SQL;
        }

        public static string SelectItems()
        {
            string SQL = @"
                SELECT i.item_id AS ItemId
                     , i.item_name AS ItemName
                     , i.item_price AS ItemPrice
                     , i.remarks AS Remarks
                     , i.item_image AS ItemImage
                  FROM m_shop AS s
            INNER JOIN m_shop_item AS si
                    ON si.shop_id = s.shop_id
            INNER JOIN m_item AS i
                    ON i.item_id = si.item_id
                 WHERE s.shop_id = @shop_id ;
            ";
            return SQL;
        }
    }
}
