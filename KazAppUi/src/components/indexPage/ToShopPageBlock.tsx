import { Link } from "react-router-dom";
import styled from "styled-components";
import { COLORS } from "../../lib/Constants";
import MenuTitle from "../common/MenuTitle";
import OutSideFrame from "../common/OutSideFrame";

const Slink = styled(Link)`
    text-decoration: none;
    color: ${COLORS.MAIN_FONT_COLOR};
`;
const SpDescription = styled.p`
    margin: 10px;
`;

interface ArgProps {
    validToken: boolean;
    classOfAnime: string;
    titleStyle: {}
}

const ToShopPageBlock = ({validToken, classOfAnime, titleStyle}: ArgProps) => {
    return (
        <div>
            <Slink to={validToken ? "/ShopPage" : ""} >
                <MenuTitle title={"ショップ"}
                        className={validToken ? classOfAnime : ""}
                        styleObj={validToken ? {} : titleStyle}/>
            </Slink>

            <OutSideFrame>
                <SpDescription>
                    制作予定・・・ モンスターセット、スキルセットの開放、アイテム ...
                </SpDescription>
            </OutSideFrame>
        </div>
    );
}

export default ToShopPageBlock;