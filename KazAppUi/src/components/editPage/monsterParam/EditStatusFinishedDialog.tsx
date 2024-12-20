import { useServerWithQuery } from "../../../hooks/useHooksOfCommon";
import { COLORS, KEYS, URLS } from "../../../lib/Constants";
import { EditMonsterDTO } from "../../../types/Edit";
import Button from "../../common/Button";
import DialogFrame from "../../common/DialogFrame";

interface ArgProps {
    isShow: boolean;
    setShowDialog: React.Dispatch<React.SetStateAction<boolean>>;
    setEditMonsters: React.Dispatch<React.SetStateAction<EditMonsterDTO[]>>;
}

const EditStatusFinishedDialog = ({
    isShow, setShowDialog, setEditMonsters}: ArgProps
) => {
    /**
     * 更新後のステータスを反映
     */
    const goToServer = useServerWithQuery();
    const fetchEditedMonsters = () => {
        const func = async () => {
            const loginId: string | null = localStorage.getItem(KEYS.USER_ID);
            const monsters: EditMonsterDTO[] = await goToServer(
                URLS.FETCH_EDIT_MONSTERS + `?loginId=${loginId}`
            );
            setEditMonsters([...monsters]);
        }
        func();
    }

    return (
        <DialogFrame showDialog={isShow}>
            <h1 style={{color: COLORS.MAIN_FONT_COLOR}}>
                ステータス更新が完了しました。
            </h1>
            <div style={{textAlign: "end"}}>
                <Button text="閉じる" onClick={() => {
                    fetchEditedMonsters();
                    setShowDialog(false);
                }}/>
            </div>
        </DialogFrame>
    );
}

export default EditStatusFinishedDialog;