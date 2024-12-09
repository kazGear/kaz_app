import styled from "styled-components";
import OutSideFrame from "../components/common/OutSideFrame";
import Select from "../components/common/Select";
import { COLORS, KEYS, URLS } from "../lib/Constants";
import { useLayoutEffect, useState } from "react";
import { useServerWithQuery } from "../hooks/useHooksOfCommon";
import { Shop } from "../types/Shop";

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
    const [saleItems, setaleItems] = useState(null);

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

    return (
        <SshopPageFrame>
            <SdivControllerFrame>
                <OutSideFrame styleObj={{height: "60px", margin: "20px"}}>
                    <Select title="店舗">
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
                    <tbody>
                        <tr>
                            <Std>aaaaa</Std>
                            <Std>bbbbbbb</Std>
                            <Std>ccccccc</Std>
                        </tr>
                        <tr>
                            <Std>eeeeeeeeeeee</Std>
                            <Std>ffffffffffff</Std>
                            <Std>gggggg</Std>
                        </tr>
                        <tr>
                            <Std>eeeeeeeeeeee</Std>
                            <Std>ffffffffffff</Std>
                            <Std>gggggg</Std>
                        </tr>
                    </tbody>
                </Stable>
            </SdivItemFrame>

        </SshopPageFrame>
    );
};

export default ShopPage;
