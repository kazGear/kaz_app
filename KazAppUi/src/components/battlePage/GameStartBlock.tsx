import { ReactNode } from "react";
import DialogFrame from "../common/DialogFrame";
import BattleStartContentsBlock from "./BattleStartContentsBlock";


interface ArgProps {
    battleStartHandler: (e: any) => Promise<void>;
    selectMonstersCountHandler: (e: any) => void;
    showResultDialog : boolean
}

const GameStartBlock = ({
    battleStartHandler, selectMonstersCountHandler, showResultDialog
 }: ArgProps) => {

    const contents = (): ReactNode => {
        return <BattleStartContentsBlock
                    battleStartHandler={battleStartHandler}
                    selectMonstersCountHandler={selectMonstersCountHandler}
                    />
    }

    return (
        <DialogFrame
            renderChild={contents}
            showDialog={showResultDialog} />
    );
}

export default GameStartBlock;