import { useLayoutEffect, useState } from "react";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";
import OutSideFrame from "../common/OutSideFrame"
import { MonsterDTO } from "../../types/MonsterBattle";
import { COLORS, KEYS, URLS } from "../../lib/Constants";
import MonsterTableHeader from "./MonsterTableHeader";
import MonsterTableBody from "./MonsterTableBody";
import styled from "styled-components";
import Button from "../common/Button";

const Stable = styled.table`
    margin: auto;
    width: 90%;
`;
const SdivEditHeader = styled.div`
    display: flex;
    position: sticky;
    justify-content: space-between;
    top: 0;
    background: ${COLORS.BASE_BACKGROUND};
`;

const MonsterStatusEdit = () => {
    const [editMonsters, setEditMonsters] = useState<MonsterDTO[]>([]);

    /**
     * モンスター情報
     */
    const goToServer = useServerWithQuery();
    useLayoutEffect(() => {
        const fetchEditMonsters = async () => {
            const loginId: string | null = localStorage.getItem(KEYS.USER_ID);
            const monsters: MonsterDTO[] = await goToServer(
                URLS.FETCH_EDIT_MONSTERS + `?loginId=${loginId}`
            );
            setEditMonsters([...monsters]);
        }
        fetchEditMonsters();
    });

    return (
        <div>
            <SdivEditHeader>
                <h2 style={{marginLeft: "20px"}}>
                    変更したいパラメータを入力してください。
                </h2>
                <Button text="ステータス更新"
                        width={140}
                        onClick={() => {}}
                        styleObj={{margin: "20px"}}/>
            </SdivEditHeader>
            <Stable>
                <MonsterTableHeader />
                <MonsterTableBody editMonsters={editMonsters}/>
            </Stable>

        </div>
    );
}

export default MonsterStatusEdit;