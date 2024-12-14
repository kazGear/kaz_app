import styled from "styled-components";
import { useState } from "react";
import { BattleReportDTO, MonsterReportDTO } from "../types/BattleReport";
import MonsterReport from "../components/battleResultPage/MonsterReportBlock";
import { useCheckToken } from "../hooks/useHooksOfCommon";
import BattleReportControllerBlock from "../components/battleResultPage/BattleReportControllerBlock";
import BattleReportBlock from "../components/battleResultPage/BattleReportBlock";
import MonsterReportControllerBlock from "../components/battleResultPage/MonsterReportControllerBlock";
import OutSideFrame from "../components/common/OutSideFrame";
import NowLoading from "../components/common/NowLoading";

const SdivOutsideFrame = styled.div`
    margin-top: 20px;
    height: 100%;
`;
const SdivOptionFrame = styled.div`
    display: flex;
    justify-content: space-around;
    height: 22%;
    margin: 0 0 20px 0;
`;
const SdivReportFrame = styled.div`
    display: flex;
    justify-content: space-around;
    margin-top: 20px;
    height: 60%;
`;

const BattleResultPage = () => {
    const [monsterReport, setMonsterReport] = useState<MonsterReportDTO[]>([]);
    const [battleReport, setBattleReport] = useState<BattleReportDTO[]>([]);
    const [sortType, setSortType] = useState("0");

    useCheckToken();

    return (
        <SdivOutsideFrame>
            <SdivOptionFrame>
                {/* 検索条件部 */}

                <OutSideFrame styleObj={{width: "55%"}}>
                    <BattleReportControllerBlock setMonsterReport={setMonsterReport}
                                                    sortType={sortType}/>
                </OutSideFrame>

                {/* 検索条件部 */}
                <OutSideFrame styleObj={{width: "35%"}}>
                    <MonsterReportControllerBlock setBattleReport={setBattleReport}/>
                </OutSideFrame>
            </SdivOptionFrame>

            <SdivReportFrame>
                {/* レポート部 */}
                <OutSideFrame styleObj={{width: "55%"}}>
                    <MonsterReport monsterReport={monsterReport}
                                   setSortType={setSortType} />
                 </OutSideFrame>
                {/* レポート部 */}
                <OutSideFrame styleObj={{width: "35%"}}>
                    <BattleReportBlock battleReport={battleReport} />
                </OutSideFrame>
            </SdivReportFrame>
        </SdivOutsideFrame>
    );
}

export default BattleResultPage;