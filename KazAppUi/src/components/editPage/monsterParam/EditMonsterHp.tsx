import { EditMonsterDTO } from "../../../types/Edit";
import BorderTd from "../../common/BorderTd";
import Input from "../../common/Input";

interface ArgProps {
    monster: EditMonsterDTO;
}

const EditMonsterHp = ({monster}: ArgProps) => {
    return (
        <>
            <BorderTd>{monster.Hp}</BorderTd>
            <BorderTd>
                <Input styleObj={{width: "50px"}}
                       inputType="number"
                       labelTitle=""
                       onChange={(e: React.ChangeEvent<HTMLInputElement> | undefined) => {
                            monster.AfterHp = parseInt(e!.target.value);
                            monster.IsChanged = true;
                       }}/>
            </BorderTd>
        </>
    );
}

export default EditMonsterHp;