import styled from "styled-components";
import monsterImages from "../../../lib/MonsterImages";
import { MonsterDTO } from "../../../types/MonsterBattle";
import BorderTd from "../../common/BorderTd";
import Input from "../../common/Input";
import Select from "../../common/Select";
import { useServerWithQuery } from "../../../hooks/useHooksOfCommon";
import { useLayoutEffect, useState } from "react";
import { CodeDTO } from "../../../types/Common";
import { URLS } from "../../../lib/Constants";

const Simg = styled.img`
    vertical-align: middle;
    width: 50px;
    height: 50px;
    margin: 5px;
`;

interface ArgProps {
    editMonsters: MonsterDTO[];
}

const MonsterTableBody = ({editMonsters}: ArgProps) => {
    const [weekDropDown, setWeekDropDown] = useState<CodeDTO[]>([]);
    const [monsters, setMonsters] = useState<[MonsterDTO[]]>([[]]);
    /**
     * 弱点ドロップダウン
     */
    const goToServer = useServerWithQuery();
    useLayoutEffect(() => {
        const fetchWeekDropDown = async () => {
            const dropDown: CodeDTO[] = await goToServer(
                URLS.FETCH_ELEMENT_CODE
            );
            setWeekDropDown(dropDown);
        }
        fetchWeekDropDown();
    }, []);

    return (
        <tbody>
        {
            editMonsters.map((monster, index) => (
                <tr key={index} onChange={(e) => console.log(e)}>
                    {/* ID */}
                    <BorderTd>{monster.MonsterId}</BorderTd>
                    {/* イメージ */}
                    <BorderTd>
                        <Simg src={monsterImages(monster.MonsterId)}
                             alt="モンスター" />
                    </BorderTd>
                    {/* 名称 */}
                    <BorderTd>{monster.MonsterName}</BorderTd>
                    <BorderTd>
                        <Input styleObj={{width: "120px"}} inputType="text" labelTitle=""/>
                    </BorderTd>
                    {/* HP */}
                    <BorderTd>{monster.Hp}</BorderTd>
                    <BorderTd>
                        <Input styleObj={{width: "40px"}} inputType="text" labelTitle=""/>
                    </BorderTd>
                    {/* 攻撃力 */}
                    <BorderTd>{monster.Attack}</BorderTd>
                    <BorderTd>
                        <Input styleObj={{width: "40px"}} inputType="text" labelTitle=""/>
                    </BorderTd>
                    {/* 速さ */}
                    <BorderTd>{monster.Speed}</BorderTd>
                    <BorderTd>
                        <Input styleObj={{width: "40px"}} inputType="text" labelTitle=""/>
                    </BorderTd>
                    {/* 弱点 */}
                    <BorderTd>{monster.WeekName}</BorderTd>
                    <BorderTd>
                        <Select styleObj={{width: "50px"}} >
                            <option value="0"></option>
                            {
                                weekDropDown.map((opt, index) => (
                                    <option key={index} value={opt.CodeId}>{opt.Name}</option>
                                ))
                            }
                        </Select>
                    </BorderTd>
                    <Input inputType="hidden" labelTitle="" value="false"/>
                </tr>
            ))
        }
        </tbody>
    );
}

export default MonsterTableBody;