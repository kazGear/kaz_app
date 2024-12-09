import { useLayoutEffect } from "react";
import { KEYS, URLS } from "../lib/Constants";

export const useCheckLogin = (
    setValidToken: React.Dispatch<React.SetStateAction<boolean>>
) => {
    useLayoutEffect(() => {
        const checkToken = async () => {
            const token = localStorage.getItem(KEYS.TOKEN);

            // ログイントークンの期限を確認
            const option = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json', },
            }
            const res = await fetch(`${URLS.CHECK_LOGIN_TOKEN}?token=${token}`, option);

            // 期限切れ
            if (res.ok) {
                setValidToken(true);
            } else {
                setValidToken(false);
            }
        }
        checkToken();
    }, []);
}