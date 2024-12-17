import styled from "styled-components";
import Button from "../common/Button";
import { COLORS, KEYS, PREFIX, URLS } from "../../lib/Constants";
import { ItemDTO } from "../../types/Shop";
import OutSideFrame from "../common/OutSideFrame";
import BorderTd from "../common/BorderTd";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";
import React, { useState } from "react";
import { UserDTO } from "../../types/UserManage";
import { isTemplateExpression } from "typescript";

const Stable = styled.table`
    margin: auto;
    width: 95%;
    border-collapse: collapse;
    margin-bottom: 20px;
`;
const Simg = styled.img`
    width: 50px;
    height: 50px;
    border-radius: 100%;
    vertical-align: middle;
`;
const SspanStrong = styled.span`
    font-weight: bold;
    color: ${COLORS.ACCENT_FONT_PINK}
`;

interface ArgProps {
    shopItems: ItemDTO[];
    user: UserDTO | null;
    myCash: number | null;
    setMyCash: React.Dispatch<React.SetStateAction<number | null>>;
    setPurchaseItem: React.Dispatch<React.SetStateAction<string>>;
    setShowPurchaseDialog: React.Dispatch<React.SetStateAction<boolean>>;
}

const ShopItemTable = ({
    shopItems,
    user,
    myCash,
    setMyCash,
    setPurchaseItem,
    setShowPurchaseDialog
}: ArgProps) => {
    /**
     * 購入処理
     */
    const goToServer = useServerWithQuery();
    const purchase = async (itemRow: ItemDTO) => {
        const loginId: string | null = localStorage.getItem(KEYS.USER_ID);

        await goToServer(
            URLS.PURCHASE_ITEM + `?loginId=${loginId}&itemId=${itemRow.ItemId}`
        );
        const user: UserDTO = await goToServer(
            URLS.USER_INFO + `?loginId=${loginId}`
        );
        setMyCash(user.Cash);
        setPurchaseItem(itemRow.ItemName);
        setShowPurchaseDialog(true);
    }

    return (
        <OutSideFrame>
            <p style={{margin: "20px"}}>取り扱い商品</p>

            <Stable>
                <thead>
                    <tr>
                        <td style={{border: "none", minWidth: "70px"}}>
                            <span style={{marginLeft: "10px"}}>イメージ</span>
                        </td>
                        <td style={{border: "none", minWidth: "120px"}}>商品名</td>
                        <td style={{border: "none"}}>備考</td>
                        <td style={{border: "none"}}>価格</td>
                        <td style={{border: "none", width: "100px"}}> </td>
                    </tr>
                </thead>
                <tbody>
                {
                    shopItems.map((item, index) => {
                        return (
                            <tr key={index} style={{height: "60px"}}>
                                {/* アイテムイメージ */}
                                <BorderTd>
                                    <span style={{marginLeft: "10px", display: "inline-block"}}>
                                        <Simg src={PREFIX.BASE64 + item.ItemImage} alt="書品"/>
                                    </span>
                                </BorderTd>
                                {/* 商品名 */}
                                <BorderTd>{item.ItemName}</BorderTd>
                                {/* 商品備考 */}
                                <BorderTd>{
                                    item.Remarks.split("\n").map((line, index) => (
                                        <React.Fragment key={index}>
                                            {line}<br/>
                                        </React.Fragment>
                                    ))
                                }
                                </BorderTd>
                                {/* 価格表示 */}
                                <BorderTd>{
                                    myCash! < item.ItemPrice ? <SspanStrong>{item.ItemPrice}</SspanStrong>
                                                             : item.ItemPrice
                                } Gil
                                </BorderTd>
                                {/* 購入ボタン */}
                                <BorderTd>
                                    {
                                        item.IsPurchased ? <Button text="購入済"
                                                                   onClick={() => {}}
                                                                   disabled={true}
                                                                   styleObj={{width: "80px"}}/>
                                                         : <Button text={
                                                                        myCash! < item.ItemPrice ? "資金不足"
                                                                                                    : "購入"
                                                                    }
                                                                   onClick={() => purchase(item)}
                                                                   styleObj={{width: "80px"}}
                                                                   disabled={myCash! < item.ItemPrice}/>
                                    }
                                    <input type="hidden" value={item.ItemId}/>
                                </BorderTd>
                            </tr>
                        )
                    })
                }
                </tbody>
            </Stable>
        </OutSideFrame>
    );
}

export default ShopItemTable;