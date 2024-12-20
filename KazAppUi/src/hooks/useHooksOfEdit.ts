import { useEffect } from "react";
import { useServerWithQuery } from "./useHooksOfCommon";
import { KEYS, URLS } from "../lib/Constants";
import { EditMonsterDTO } from "../types/Edit";

/**
 * 編集用モンスター情報
 */
export const useFetchEditMonsters = (setEditMonsters: React.Dispatch<React.SetStateAction<EditMonsterDTO[]>>) => {
    const goToServer = useServerWithQuery();
    useEffect(() => {
        const fetchEditMonsters = async () => {
            const loginId: string | null = localStorage.getItem(KEYS.USER_ID);
            const monsters: EditMonsterDTO[] = await goToServer(
                URLS.FETCH_EDIT_MONSTERS + `?loginId=${loginId}`
            );
            setEditMonsters([...monsters]);
        }
        fetchEditMonsters();
    }, []);
}