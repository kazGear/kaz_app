import styled from "styled-components";
import { COLORS, KEYS, URLS } from "../../lib/Constants";
import Select from "../common/Select";
import Button from "../common/Button";
import { useCallback, useState } from "react";
import { MonsterReportDTO } from "../../types/BattleReport";
import { useServerWithQuery } from "../../hooks/useHooksOfCommon";
import MonsterTypesListBlock from "./MonsterTypesListBlock";
import OutSideFrame from "../common/OutSideFrame";

const SdivOutSideFrame = styled.div`

`;
const Sh1Title = styled.h1`
    font-size: 16px;
    color: ${COLORS.CAPTION_FONT_COLOR};
    margin-top: 5px;
`;

interface ArgProps {
    setMonsterReport: React.Dispatch<React.SetStateAction<MonsterReportDTO[]>>;
    sortType: string;
}

const BattleReportControllerBlock = ({setMonsterReport, sortType}: ArgProps) => {
    const [monsterTypeId, setMonsterTypeId] = useState("0");
    const [isAscOrder, setIsAscOrder] = useState(true);

    const goToServer = useServerWithQuery();

    /**
     * ソート制御
     */
    const sortHandler = (e: React.ChangeEvent<HTMLSelectElement>) => {
        if (e.target.value === KEYS.ORDER_BY_ASC) {
            setIsAscOrder(true);
        } else {
            setIsAscOrder(false);
        }
    }
    /**
     * モンスタ毎のレポートを取得
     */
    const fetchMonsterReportHandler = useCallback(async () => {
        const monsterReport: MonsterReportDTO[]
            = await goToServer(
                URLS.MONSTER_REPORTS + `?monsterTypeId=${monsterTypeId}
                                       &sortType=${sortType}
                                       &isAscOrder=${isAscOrder}`
            );
        setMonsterReport(monsterReport);
    }, [monsterTypeId, sortType, isAscOrder]);

    return (
        <div style={{margin: "0 0 0 20px"}}>
            <Sh1Title>モンスター戦績</Sh1Title>
            <MonsterTypesListBlock setMonsterTypeId={setMonsterTypeId} />
            <Select title="ソート順" onChange={sortHandler}>
                <option value={KEYS.ORDER_BY_ASC}>昇順</option>
                <option value={KEYS.ORDER_BY_DESC}>降順</option>
            </Select>
            <div style={{textAlign: "end"}}>
                <Button
                    text="検索"
                    onClick={fetchMonsterReportHandler}
                    styleObj={{margin: "0 15px 15px 0"}}
                />
            </div>
        </div>
    );
};

export default BattleReportControllerBlock;