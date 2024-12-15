import styled from "styled-components";
import { KEYS, URLS } from "../lib/Constants";
import { useEffect, useState } from "react";
import { useServerWithQuery } from "../hooks/useHooksOfCommon";
import { Item } from "../types/Shop";
import SelectShops from "../components/shopPage/SelectShops";
import ShopItemTable from "../components/shopPage/ShopItemTable";
import NowLoading from "../components/common/NowLoading";

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
    const [shopItems, setShopItems] = useState<Item[]>([]);

    /**
     * 店舗アイテム表示
     */
    const selectItems = useServerWithQuery();
    useEffect(() => {
        const fetchShopItems = async () => {
            const items: Item[] = await selectItems(
                URLS.SELECT_SHOP_ITEMS + `?loginId=${localStorage.getItem(KEYS.USER_ID)}&shopId=${selectedShop}`);
            setShopItems(items);
        }
        fetchShopItems();
    }, [selectedShop]);

    return (
        <SshopPageFrame>
            <SdivControllerFrame>
                <SelectShops setSelectedShop={setSelectedShop}/>
            </SdivControllerFrame>
            <SdivItemFrame>
                <ShopItemTable shopItems={shopItems}/>
            </SdivItemFrame>
        </SshopPageFrame>
    );
};

export default ShopPage;
