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
    }
}
