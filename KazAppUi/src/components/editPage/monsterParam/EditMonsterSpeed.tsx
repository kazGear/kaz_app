import { EditMonsterDTO } from "../../../types/Edit";
import BorderTd from "../../common/BorderTd";
import Input from "../../common/Input";

interface ArgProps {
    monster: EditMonsterDTO;
}

const EditMonsterSpeed = ({monster}: ArgProps) => {
    return (
        <>
            <BorderTd>{monster.Speed}</BorderTd>
            <BorderTd>
                <Input styleObj={{width: "50px"}}
                       inputType="number"
                       labelTitle=""
                       onChange={(e: React.ChangeEvent<HTMLInputElement> | undefined) => {
                            monster.AfterSpeed = parseInt(e!.target.value);
                            monster.IsChanged = true;
                       }}/>
            </BorderTd>
        </>
    );
}

export default EditMonsterSpeed;