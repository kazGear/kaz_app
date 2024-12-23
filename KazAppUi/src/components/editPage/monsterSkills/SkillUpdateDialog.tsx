import { COLORS } from "../../../lib/Constants";
import Button from "../../common/Button";
import DialogFrame from "../../common/DialogFrame";

interface ArgProps {
    showDialog: boolean;
    setShowUpdateDialog: React.Dispatch<React.SetStateAction<boolean>>;
}

const SkillUpdateDialog = ({
    showDialog, setShowUpdateDialog}: ArgProps
) => {
    return (
        <DialogFrame showDialog={showDialog}>
            <h1 style={{color: COLORS.MAIN_FONT_COLOR}}>
                スキル更新が完了しました。
            </h1>
            <div style={{textAlign: "end"}}>
                <Button text="閉じる"
                        onClick={() => setShowUpdateDialog(false)}
                        />
            </div>
        </DialogFrame>
    );
}

export default SkillUpdateDialog;