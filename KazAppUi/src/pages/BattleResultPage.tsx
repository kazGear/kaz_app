import styled from "styled-components";
import { useState } from "react";
import { BattleReportDTO, MonsterReportDTO } from "../types/BattleReport";
import MonsterReport from "../components/battleResultPage/MonsterReportBlock";
import { useCheckToken } from "../hooks/useHooksOfCommon";
import BattleReportControllerBlock from "../components/battleResultPage/BattleReportControllerBlock";
import BattleReportBlock from "../components/battleResultPage/BattleReportBlock";
import MonsterReportControllerBlock from "../components/battleResultPage/MonsterReportControllerBlock";
import { COLORS } from "../lib/Constants";

const SdivOutsideFrame = styled.div`
    margin-top: 60px;
    height: 100%;
`;
const SdivOptionFrame = styled.div`
    display: flex;
    justify-content: space-around;
    height: 140px;
    margin: 0 0 20px 0;
`;
const SdivOptionL = styled.div`
    width: 55%;
    height: 100%;
    position: relative;
`;
const SdivOptionR = styled.div`
    width: 35%;
    height: 100%;
    position: relative;
`;
const SdivReportFrame = styled.div`
    display: flex;
    justify-content: space-around;
`;
const SdivReportL = styled.div`
    width: 55%;
    max-height: 430px;
    overflow-y: scroll;
    background: ${COLORS.BASE_BACKGROUND};
`;
const SdivReportR = styled.div`
    width: 35%;
    max-height: 430px;
    overflow-y: scroll;
    background: ${COLORS.BASE_BACKGROUND};
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
                <SdivOptionL>
                    <BattleReportControllerBlock setMonsterReport={setMonsterReport}
                                                 sortType={sortType}/>
                </SdivOptionL>

                {/* 検索条件部 */}
                <SdivOptionR>
                    <MonsterReportControllerBlock setBattleReport={setBattleReport}/>
                </SdivOptionR>
            </SdivOptionFrame>

            <SdivReportFrame>
                {/* レポート部 */}
                <SdivReportL>
                    <MonsterReport monsterReport={monsterReport}
                                   setSortType={setSortType} />
                 </SdivReportL>
                {/* レポート部 */}
                <SdivReportR>
                    <BattleReportBlock battleReport={battleReport} />
                </SdivReportR>
            </SdivReportFrame>
        </SdivOutsideFrame>
    );
}

export default BattleResultPage;