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
    margin: 0 0 0 40px;
`;

interface ArgProps {
    validToken: boolean;
    classOfAnime: string;
    titleStyle: {}
}

const ToEditPageBlock = ({validToken, classOfAnime, titleStyle}: ArgProps) => {
    return (
        <div>
            <Slink to={validToken ? "/" : ""} >
                <MenuTitle title={"各種設定（ 工事中 ）"}
                        className={validToken ? classOfAnime : ""}
                        styleObj={validToken ? {} : titleStyle}/>
            </Slink>

            <OutSideFrame>
                <SpDescription>
                    制作予定・・・ モンスターデータ編集、モンスター所持スキル編集、スキル編集、ユーザー編集・・・
                </SpDescription>
            </OutSideFrame>
        </div>
    );
}

export default ToEditPageBlock;