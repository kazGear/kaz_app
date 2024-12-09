import styled from "styled-components";

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

const ShopPage = () => {
    return (
        <SshopPageFrame>
            <SdivControllerFrame>
                <label>検索条件</label>
                <br></br>
                <label>商品種別</label>
                <select>
                    <option>モンスター開放権
                    </option>
                    <option>戦闘背景</option>
                </select>
                <br/>

                <label>モンスター種t</label>
                <select>
                    <option>指定なし</option>
                    <option>モンスター種１</option>
                    <option>モンスター種２</option>
                </select>
                <br/>

            </SdivControllerFrame>
            <SdivItemFrame>
                <label>アイテムテーブル</label>
                <table>
                    <tbody>
                        <tr>
                            <td>a</td><td>b</td><td>c</td>
                        </tr>
                    </tbody>
                </table>
            </SdivItemFrame>

        </SshopPageFrame>
    );
};

export default ShopPage;
