import styled from "styled-components";
import Button from "../common/Button";
import { KEYS, PREFIX, URLS } from "../../lib/Constants";
import { Item } from "../../types/Shop";
import OutSideFrame from "../common/OutSideFrame";
import BorderTd from "../common/BorderTd";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";
import { useLayoutEffect, useState } from "react";

const Stable = styled.table`
    margin: auto;
    width: 90%;
    border-collapse: collapse;
    margin-bottom: 20px;
`;
const Simg = styled.img`
    width: 50px;
    height: 50px;
    border-radius: 100%;
    vertical-align: middle;
`;

interface ArgProps {
    shopItems: Item[];
}

const ShopItemTable = ({shopItems}: ArgProps) => {

    return (
        <OutSideFrame>
            <p style={{margin: "20px"}}>取り扱い商品</p>

            <Stable>
                <thead>
                    <tr>
                        <td style={{border: "none"}}>
                            <span style={{marginLeft: "20px"}}>イメージ</span>
                        </td>
                        <td style={{border: "none"}}>タイトル</td>
                        <td style={{border: "none"}}>備考</td>
                        <td style={{border: "none"}}>価格</td>
                    </tr>
                </thead>
                <tbody>
                {
                    shopItems.map((item, index) => {
                        return (
                            <tr key={index} style={{height: "60px"}}>
                                <BorderTd>
                                    <span style={{marginLeft: "20px", display: "inline-block"}}>
                                        <Simg src={PREFIX.BASE64 + item.ItemImage} alt="書品"/>
                                    </span>
                                </BorderTd>
                                <BorderTd>{item.ItemName}</BorderTd>
                                <BorderTd>{item.Remarks}</BorderTd>
                                <BorderTd>{item.ItemPrice} Gil</BorderTd>
                                <BorderTd>
                                    {
                                        item.IsPurchased ? <Button text="購入済" onClick={()=>{}} disabled={true}/>
                                                         : <Button text="購入" onClick={()=>{}}/>
                                    }
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