import { useCallback, useLayoutEffect, useState } from "react";
import { useServerWithJson, useServerWithQuery } from "../../../hooks/useHooksOfCommon";
import { COLORS, KEYS, URLS } from "../../../lib/Constants";
import MonsterTableHeader from "./MonsterTableHeader";
import MonsterTableBody from "./MonsterTableBody";
import styled from "styled-components";
import Button from "../../common/Button";
import { EditMonsterDTO } from "../../../types/Edit";
import EditStatusFinishedDialog from "./EditStatusFinishedDialog";

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

interface ArgProps {
    editMonsters: EditMonsterDTO[];
    setEditMonsters: React.Dispatch<React.SetStateAction<EditMonsterDTO[]>>;
}

const MonsterStatusEdit = ({editMonsters, setEditMonsters}: ArgProps) => {

    const [showDialog, setShowDialog] = useState(false);

    /**
     * 編集用モンスター情報
     */
    const goToServer = useServerWithQuery();
    useLayoutEffect(() => {
        const fetchEditMonsters = async () => {
            const loginId: string | null = localStorage.getItem(KEYS.USER_ID);
            const monsters: EditMonsterDTO[] = await goToServer(
                URLS.FETCH_EDIT_MONSTERS + `?loginId=${loginId}`
            );
            setEditMonsters([...monsters]);
        }
        fetchEditMonsters();
    }, []);
    /**
     * 更新実行
     */
    const goToServerWithJson = useServerWithJson();
    const updateStatusHandler = useCallback(() => {
        goToServerWithJson(
            editMonsters, URLS.UPDATE_MONSTER_STATUS
        );
        setEditMonsters([...editMonsters]);
        setShowDialog(true);
    }, [editMonsters]);

    return (
        <div>
            <SdivEditHeader>
                <h2 style={{marginLeft: "20px"}}>
                    変更したいパラメータを入力してください。
                </h2>
                <Button text="ステータス更新"
                        width={140}
                        onClick={updateStatusHandler}
                        styleObj={{margin: "20px"}}/>
            </SdivEditHeader>
            {/* ステータス編集部 */}
            <Stable>
                <MonsterTableHeader />
                <MonsterTableBody editMonsters={editMonsters}/>
            </Stable>
            {/* 完了ダイアログ */}
            <EditStatusFinishedDialog isShow={showDialog} setShowDialog={setShowDialog} setEditMonsters={setEditMonsters}/>
        </div>
    );
}

export default MonsterStatusEdit;