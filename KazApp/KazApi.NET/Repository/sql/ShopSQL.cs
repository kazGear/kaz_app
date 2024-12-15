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

        public static string ExistsUsableShop()
        {
            string SQL = $@"
                -- 開放可能な店舗リスト
                SELECT s.shop_id    AS ShopId
                     , s.shop_name  AS ShopName
                  FROM m_shop AS s
                 WHERE EXISTS 
                     (
                        SELECT * 
                          FROM m_user AS u
                         WHERE u.wins_get_cash >= s.win_money_until_can_use
                           AND u.login_id = @login_id
                     )
            EXCEPT ALL 
                -- 既に開放済みな店舗は除外する
                SELECT a.shop_id
                     , s.shop_name
                  FROM m_available_stores AS a 
            INNER JOIN m_shop AS s
                    ON s.shop_id = a.shop_id
                 WHERE a.login_id = @login_id
                 ORDER BY ShopId ASC ;
            ";
            return SQL;
        }

        public static string InsertUsableStore()
        {
            string SQL = @$"
                INSERT INTO m_available_stores VALUES 
                (
                    @login_id
                  , @shop_id
                );
            ";
            return SQL;
        }
    }
}
