import styled from "styled-components";
import { KEYS, URLS } from "../lib/Constants";
import { useEffect, useState } from "react";
import { useServerWithQuery } from "../hooks/useHooksOfCommon";
import { ItemDTO } from "../types/Shop";
import SelectShops from "../components/shopPage/SelectShops";
import ShopItemTable from "../components/shopPage/ShopItemTable";
import { UserDTO } from "../types/UserManage";

const SshopPageFrame = styled.div`
    display: flex;
    height: 90%;
`;
const SdivControllerFrame = styled.div`
    width:25%;
    margin: 20px;
`;
const SdivItemFrame = styled.div`
    width: 75%;
    margin: 20px;
    overflow: overlay;
`;

const ShopPage = () => {
    const [selectedShop, setSelectedShop] = useState<string | undefined>("shop001");
    const [shopItems, setShopItems] = useState<ItemDTO[]>([]);
    const [user, setUser] = useState<UserDTO | null>(null);
    const [myCash, setMyCash] = useState<number | null>(null);

    /**
     * 店舗アイテム表示
     */
    const select = useServerWithQuery();
    useEffect(() => {
        const fetchShopItems = async () => {
            const loginId: string | null = localStorage.getItem(KEYS.USER_ID);

            const items: ItemDTO[] = await select(
                URLS.SELECT_SHOP_ITEMS + `?loginId=${loginId}&shopId=${selectedShop}`);
            const loginUser: UserDTO = await select(
                URLS.USER_INFO + `?loginId=${loginId}`);

            setShopItems(items);
            setUser(loginUser);
            setMyCash(loginUser.Cash);
        }
        fetchShopItems();
    }, [selectedShop]);

    return (
        <SshopPageFrame>
            <SdivControllerFrame>
                <SelectShops setSelectedShop={setSelectedShop}
                             user={user}
                             myCash={myCash}/>
            </SdivControllerFrame>
            <SdivItemFrame>
                <ShopItemTable shopItems={shopItems}
                               user={user}
                               myCash={myCash}
                               setMyCash={setMyCash}/>
            </SdivItemFrame>
        </SshopPageFrame>
    )
};

export default ShopPage;
