import styled from "styled-components";
import OutSideFrame from "../components/common/OutSideFrame";
import Select from "../components/common/Select";
import { COLORS, KEYS, PREFIX, URLS } from "../lib/Constants";
import { useEffect, useLayoutEffect, useState } from "react";
import { useServerWithQuery } from "../hooks/useHooksOfCommon";
import { Item, Shop } from "../types/Shop";
import Button from "../components/common/Button";

const SshopPageFrame = styled.div`
    margin-top: 80px;
    display: flex;
`;
const SdivControllerFrame = styled.div`
    width:25%;
    background-color: antiquewhite;
`;
const SdivItemFrame = styled.div`
    width: 75%;
    background-color: aquamarine;
`;
const Stable = styled.table`
    margin: auto;
    width: 80%;
    border-collapse: collapse;
`;
const Std = styled.td`
    border-top: 1px solid ${COLORS.BORDER_COLOR};
    border-bottom: 1px solid ${COLORS.BORDER_COLOR};
`;

const ShopPage = () => {
    const [shopsOfSelectBox, setShopsOfSelectBox] = useState<Shop[]>([]);
    const [selectedShop, setSelectedShop] = useState<string | undefined>("shop001");
    const [shopItems, setShopItems] = useState<Item[]>([]);

    /**
     * 初期処理
     */
    const select = useServerWithQuery();
    useLayoutEffect(() => {
        const selectShops = async () => {
            const loginId = localStorage.getItem(KEYS.USER_ID);
            const shops: Shop[] = await select(URLS.SHOP_INIT + `?loginId=${loginId}`);
            setShopsOfSelectBox(shops);
        }
        selectShops();
    }, []);
    /**
     * 店舗選択時
     */
    const changeShopHandler = (e: React.ChangeEvent<HTMLSelectElement> | undefined) => {
        setSelectedShop(e?.target.value);
    }
    /**
     * 店舗アイテム表示
     */
    const selectItems = useServerWithQuery();
    useEffect(() => {
        const fetchShopItems = async () => {
            const items: Item[] = await selectItems(URLS.SELECT_SHOP_ITEMS + `?shopId=${selectedShop}`);
            setShopItems(items);
        }
        fetchShopItems();
    }, [selectedShop]);

    return (
        <SshopPageFrame>
            <SdivControllerFrame>
                <OutSideFrame styleObj={{height: "60px", margin: "20px"}}>
                    <Select title="店舗" onChange={changeShopHandler}>
                        {
                            shopsOfSelectBox.map((shop, index) => (
                                <option value={shop.ShopId} key={index}>{shop.ShopName}</option>
                            ))
                        }
                    </Select>
                </OutSideFrame>
            </SdivControllerFrame>
            <SdivItemFrame>
                <p style={{margin: "20px"}}>取り扱い商品</p>
                <Stable>
                    <thead>
                        <tr>
                            <td>イメージ</td>
                            <td>タイトル</td>
                            <td>備考</td>
                            <td>価格</td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            shopItems.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td><img src={PREFIX.BASE64 + item.ItemImage} alt="書品" style={{width: "50px", height: "50px", borderRadius: "100%"}}/></td>
                                        <td >{item.ItemName}</td>
                                        <td >{item.Remarks}</td>
                                        <td>{item.ItemPrice} Gil</td>
                                        <td><Button text="購入" onClick={()=>{}}/></td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </Stable>
            </SdivItemFrame>
        </SshopPageFrame>
    );
};

export default ShopPage;
