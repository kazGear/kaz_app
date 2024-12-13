import { useLayoutEffect, useState } from "react";
import OutSideFrame from "../common/OutSideFrame";
import Select from "../common/Select";
import { Shop } from "../../types/Shop";
import { KEYS, URLS } from "../../lib/Constants";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";

interface ArgProps {
    setSelectedShop: React.Dispatch<React.SetStateAction<string | undefined>>;
}

const SelectShops = ({setSelectedShop}: ArgProps) => {
    const [shopsOfSelectBox, setShopsOfSelectBox] = useState<Shop[]>([]);
    const select = useServerWithQuery();

    /**
     * 店舗の選択肢を取得
     */
    useLayoutEffect(() => {
        const selectShops = async () => {
            const loginId = localStorage.getItem(KEYS.USER_ID);
            const shops: Shop[] = await select(URLS.SHOP_INIT + `?loginId=${loginId}`);
            setShopsOfSelectBox(shops);
        }
        selectShops();
    }, []);
    /**
     * ショップ選択時
     */
    const changeShopHandler = (e: React.ChangeEvent<HTMLSelectElement> | undefined) => {
        setSelectedShop(e?.target.value);
    }

    return (
        <OutSideFrame >
            <Select title="店舗" onChange={changeShopHandler}>
                {
                    shopsOfSelectBox.map((shop, index) => (
                        <option value={shop.ShopId} key={index}>{shop.ShopName}</option>
                    ))
                }
            </Select>
        </OutSideFrame>
    );
}

export default SelectShops;