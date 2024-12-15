import styled from "styled-components";
import Button from "../common/Button";
import { PREFIX } from "../../lib/Constants";
import { Item } from "../../types/Shop";
import OutSideFrame from "../common/OutSideFrame";

const Stable = styled.table`
    margin: auto;
    width: 80%;
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
                        <td style={{borderTop: "none"}}>
                            <span style={{marginLeft: "20px"}}>イメージ</span>
                        </td>
                        <td style={{borderTop: "none"}}>タイトル</td>
                        <td style={{borderTop: "none"}}>備考</td>
                        <td style={{borderTop: "none"}}>価格</td>
                    </tr>
                </thead>
                <tbody>
                {
                    shopItems.map((item, index) => {
                        return (
                            <tr key={index} style={{height: "60px"}}>
                                <td>
                                    <span style={{marginLeft: "20px", display: "inline-block"}}>
                                        <Simg src={PREFIX.BASE64 + item.ItemImage} alt="書品"/>
                                    </span>
                                </td>
                                <td>{item.ItemName}</td>
                                <td>{item.Remarks}</td>
                                <td>{item.ItemPrice} Gil</td>
                                <td><Button text="購入" onClick={()=>{}}/></td>
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