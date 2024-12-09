import styled from "styled-components";
import Button from "./Button";
import { useNavigate } from "react-router-dom";
import { COLORS, KEYS, PREFIX, URLS } from "../../lib/Constants";
import { useEffect, useLayoutEffect, useState } from "react";
import { isEmpty } from "../../lib/CommonLogic";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";
import { useCheckLogin } from "../../hooks/useHooksOfIndex";
import { UserDTO } from "../../types/UserManage";

const Simg = styled.img`
    width: 40px;
    height: 40px;
    margin-right: 10px;
    border-radius: 100%;
`;
const Sheader = styled.header`
    width: 100%;
    height: 50px;
    max-height: 50px;
    box-shadow: 0px 0px 10px 0px #000000;
    text-align: left;
    display: flex;
    align-items: center;
    justify-content: space-between;
    position: fixed;
    top: 0;
    background-color: white;
    z-index: 2000;
`;
const SdivButtonFrame = styled.div`
    display: flex;
    margin-right: auto;
    margin-left: 10px;
`;
const Sh1 = styled.h1`
    margin: 20px;
    color: ${COLORS.ACCENT_FONT_COLOR2};
`;

const Sspan = styled.span`
    transform: translateY(3px);
    margin-right: 10px;
`;

interface ArgProps { title: string; }

const AppHeader = ({title}: ArgProps) => {
    const [loginId, setLoginId] = useState<string | null>("");
    const [loginUser, setLoginUser] = useState<UserDTO | null>();
    const [userImage, setUserImage] = useState<string>("");
    const [validToken, setValidToken] = useState(false);

    const navigate = useNavigate();
    const currentUrl: string = window.location.href;
    const isRootPage: boolean = currentUrl.endsWith("/"); // 最初のページ
    const isRootPage2: boolean = currentUrl.endsWith("/IndexPage");

    useCheckLogin(setValidToken);

    // ユーザー名取得のため
    useLayoutEffect(() => {
        const id: string | null = localStorage.getItem(KEYS.USER_ID);
        setLoginId(id);
    }, [loginId]);

    // 表示名取得
    const select = useServerWithQuery();
    useEffect(() => {
        const selectName = async () => {
            const user: UserDTO | null = await select(`${URLS.SELECT_LOGIN_USER}?loginId=${loginId}`);
            setLoginUser(user);
            if (user) setUserImage(PREFIX.BASE64 + user.UserImage);
        }
        selectName();
    }, [loginId, loginUser]);

    return (
        <Sheader>
            <Sh1>{title}</Sh1>
            <SdivButtonFrame style={{
                display: isRootPage || isRootPage2 ? "none" : ""
                }}>
                <Button text="モンスター闘技場"
                        width={125}
                        onClick={() => navigate("/BattlePage")}
                        disabled={validToken ? false : true}/>
                <Button text="闘技場戦績"
                        width={90}
                        onClick={() => navigate("/BattleResultPage")}
                        disabled={validToken ? false : true}/>
                <Button text="ユーザーページ"
                        width={120}
                        onClick={() => navigate("/UserPage")}
                        disabled={validToken ? false : true}/>
                <Button text="ログイン"
                        width={80}
                        onClick={() => navigate("/LoginPage")}
                        disabled={validToken ? false : true}/>
                <Button text="ショップ"
                        width={80}
                        onClick={() => navigate("/ShopPage")}
                        disabled={validToken ? false : true}/>
            </SdivButtonFrame>
            <div style={{display: "flex", alignItems: "center"}}>
                {
                    !isEmpty(loginUser) && loginUser!.UserImage!.length > 50 ? <Simg src={userImage} alt="" /> : ""
                }
                {
                    !isEmpty(loginUser) ? <Sspan>ようこそ{loginUser?.DispName}さん</Sspan> : ""
                }
                <Button text="メニューへ" onClick={() => navigate("/")} styleObj={{
                    marginRight: "20px",
                    position: "relative",
                    zIndex: 5000
                }}
                />
            </div>
        </Sheader>
    );
};

export default AppHeader;
