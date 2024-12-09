import styled from "styled-components";
import { useState } from "react";
import { COLORS } from "../lib/Constants";
import { useCheckLogin } from "../hooks/useHooksOfIndex";
import ToLoginPageBlock from "../components/indexPage/ToLoginPageBlock";
import ToUserPageBlock from "../components/indexPage/ToUserPageBlock";
import ToBattlePageBlock from "../components/indexPage/ToBattlePageBlock";
import ToBattleResultPageBlock from "../components/indexPage/ToBattleResultPageBlock";
import ToShopPageBlock from "../components/indexPage/ToShopPageBlock";
import ToEditPageBlock from "../components/indexPage/ToEditPageBlock";

const SdivLinkFrame = styled.div`
    width: 90%;
    margin: 60px auto;
`;
const SdivContentsFrame = styled.div`
    width: 50%;
    margin: 0 20px 0 20px;
`;

const fontColor: string = COLORS.MAIN_FONT_COLOR;
const backColor: string = COLORS.MENU_DISABLED;
const classOfAnime: string = "noneAnimation";
const titleStyle: {} = {
    color: fontColor,
    background: backColor,
}

const IndexPage = () => {
    const [validToken, setValidToken] = useState(false);

    useCheckLogin(setValidToken);

    return (
        <>
            <SdivLinkFrame>
                <div style={{display: "flex"}}>
                    <SdivContentsFrame>
                        <ToLoginPageBlock />
                    </SdivContentsFrame>

                    <SdivContentsFrame>
                        <ToUserPageBlock validToken={validToken}
                                         classOfAnime={classOfAnime}
                                         titleStyle={titleStyle} />
                    </SdivContentsFrame>
                </div>

                <div style={{display: "flex"}}>
                    <SdivContentsFrame>
                        <ToBattlePageBlock validToken={validToken}
                                           classOfAnime={classOfAnime}
                                           titleStyle={titleStyle}/>
                    </SdivContentsFrame>

                    <SdivContentsFrame>
                        <ToBattleResultPageBlock validToken={validToken}
                                                 classOfAnime={classOfAnime}
                                                 titleStyle={titleStyle}/>
                    </SdivContentsFrame>
                </div>

                <div style={{display: "flex"}}>
                    <SdivContentsFrame>
                        <ToShopPageBlock validToken={validToken}
                                         classOfAnime={classOfAnime}
                                         titleStyle={titleStyle}/>
                    </SdivContentsFrame>

                    <SdivContentsFrame>
                       <ToEditPageBlock validToken={validToken}
                                        classOfAnime={classOfAnime}
                                         titleStyle={titleStyle}/>
                    </SdivContentsFrame>
                </div>

                <p style={{color: `${COLORS.ACCENT_FONT_COLOR2}`}}>※スマホ非対応、Chrome, edge推奨。</p>
            </SdivLinkFrame>
        </>
    );
};

export default IndexPage;
