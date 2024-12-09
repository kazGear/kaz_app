import { ReactNode } from "react";
import { MetaDataDTO, MonsterDTO } from "../../types/MonsterBattle";
import DialogFrame from "../common/DialogFrame";
import BattleResultContentsBlock from "./BattleResultContentsBlock";

interface ArgProps {
    log:  MetaDataDTO | null;
    betMonster: MonsterDTO | null;
    betGil: number;
    showResultDialog: boolean;
}

const BattleResultBlock = ({
    log, betMonster, betGil, showResultDialog
 }: ArgProps) => {

    const contents = (): ReactNode => {
        return <BattleResultContentsBlock
                    log={log}
                    betMonster={betMonster}
                    betGil={betGil} />
    }

    return (
        <DialogFrame
            renderChild={contents}
            showDialog={showResultDialog}
            showFilter={true} />
    );
}

export default BattleResultBlock;