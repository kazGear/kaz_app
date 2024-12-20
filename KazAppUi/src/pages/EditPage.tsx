import styled from "styled-components";
import EditSelector from "../components/editPage/monsterParam/EditSelector";
import MonsterStatusEdit from "../components/editPage/monsterParam/MonsterStatusEdit";
import { useState } from "react";
import OutSideFrame from "../components/common/OutSideFrame";
import ClearAllStatus from "../components/editPage/monsterParam/ClearAllStatus";
import { EditMonsterDTO } from "../types/Edit";

const SdivEditFrame = styled.div`
    width: 100%;
`;
const styleForController = {
    width: "95%",
    marginBottom: "0",
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center"
}
const styleForEdit = {
    height: "75vh"
}


const EditPage = () => {
    const [editMonsters, setEditMonsters] = useState<EditMonsterDTO[]>([]);
    const [selectEditType, setSelectEditType] = useState(1);

    return (
        <SdivEditFrame>
            <OutSideFrame styleObj={styleForController}>
                {/* 設定種類コントローラ */}
                <EditSelector setSelectEditType={setSelectEditType}/>
                <ClearAllStatus setEditMonsters={setEditMonsters}/>
            </OutSideFrame>
            <OutSideFrame styleObj={styleForEdit}>
                {/* 設定部 */}
                { selectEditType === 1 ? <MonsterStatusEdit editMonsters={editMonsters} setEditMonsters={setEditMonsters} /> : ""}
                { selectEditType === 2 ? <h1>スキル変更（工事中）</h1> : ""}
                { selectEditType === 3 ? <h1>使用モンスター（工事中）</h1> : ""}
            </OutSideFrame>
        </SdivEditFrame>
    );
}

export default EditPage;