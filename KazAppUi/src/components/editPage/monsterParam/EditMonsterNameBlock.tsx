import { EditMonsterDTO } from "../../../types/Edit";
import BorderTd from "../../common/BorderTd";
import Input from "../../common/Input";

interface ArgProps {
    monster: EditMonsterDTO;
}

const EditMonsterNameBlock = ({monster}: ArgProps) => {
    return (
        <>
            <BorderTd>{monster.MonsterName}</BorderTd>
            <BorderTd>
                <Input styleObj={{width: "120px"}}
                       inputType="text"
                       labelTitle=""
                       onChange={(e: React.ChangeEvent<HTMLInputElement> | undefined) => {
                            monster.AfterName = e!.target.value;
                            monster.IsChanged = true;
                       }}/>
            </BorderTd>
        </>
    );
}

export default EditMonsterNameBlock;