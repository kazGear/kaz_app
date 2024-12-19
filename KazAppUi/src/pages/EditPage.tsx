import styled from "styled-components";
import EditSelector from "../components/editPage/monsterParam/EditSelector";
import MonsterStatusEdit from "../components/editPage/monsterParam/MonsterStatusEdit";
import { useState } from "react";
import OutSideFrame from "../components/common/OutSideFrame";

const SdivEditFrame = styled.div`

`;
const styleForController = {
    width: "25%",
    marginBottom: "0"
}
const styleForEdit = {
    height: "75vh"
}


const EditPage = () => {
    const [selectEditType, setSelectEditType] = useState(1);

    return (
        <SdivEditFrame>
            <OutSideFrame styleObj={styleForController}>
                {/* 設定種類コントローラ */}
                <EditSelector setSelectEditType={setSelectEditType}/>
            </OutSideFrame>
            <OutSideFrame styleObj={styleForEdit}>
                {/* 設定部 */}
                { selectEditType === 1 ? <MonsterStatusEdit/> : ""}
                { selectEditType === 2 ? <h1>スキル変更（工事中）</h1> : ""}
                { selectEditType === 3 ? <h1>使用モンスター（工事中）</h1> : ""}
            </OutSideFrame>
        </SdivEditFrame>
    );
}

export default EditPage;