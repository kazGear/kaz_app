import { ReactNode } from "react";
import { MetaDataDTO, MonsterDTO } from "../../types/MonsterBattle";
import DialogFrame from "../common/DialogFrame";
import BattleResultContentsBlock from "./BattleResultContentsBlock";
import { ShopDTO } from "../../types/Shop";

interface ArgProps {
    log:  MetaDataDTO | null;
    betMonster: MonsterDTO | null;
    betGil: number;
    showResultDialog: boolean;
    newShops: ShopDTO[];
}

const BattleResultBlock = ({
    log, betMonster, betGil, showResultDialog, newShops
 }: ArgProps) => {

    const contents = (): ReactNode => {
        return <BattleResultContentsBlock
                    log={log}
                    betMonster={betMonster}
                    betGil={betGil}
                    newShops={newShops} />
    }

    return (
        <DialogFrame
            renderChild={contents}
            showDialog={showResultDialog}
            showFilter={true} />
    );
}

export default BattleResultBlock;