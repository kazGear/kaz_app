import styled from "styled-components";
import { MonsterReportDTO } from "../../types/BattleReport";
import { COLORS } from "../../lib/Constants";
import monsterImages from "../../lib/MonsterImages";

const Stable = styled.table`
    width: 100%;
    border-collapse: collapse;
    position: relative;
`;
const StHead = styled.thead`
    height: 35px;
    max-height: 35px;
    color: ${COLORS.CAPTION_FONT_COLOR};
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
    position: sticky;
    top: 0;
    transform: translateY(-1px); // 上にスクロールしたものが見えてしまうので蓋をする
    font-weight: bold;
    background-color: white;
`;
const Std1 = styled.td`
    width: 40%;
    height: 35px;
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
    padding-left: 20px;
    `;
const Std2 = styled.td`
    width: 12%;
    height: 35px;
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
    text-align: left;
`;
const Std3 = styled.td`
    width: 16%;
    height: 35px;
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
`;
const Std4 = styled.td`
    width: 16%;
    height: 35px;
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
`;
const Std5 = styled.td`
    width: 16%;
    height: 35px;
    border-top: ${COLORS.BORDER_COLOR} 1px solid;
    border-bottom: ${COLORS.BORDER_COLOR} 1px solid;
`;
const Simg = styled.img`
    width: 30px;
    height: 30px;
    vertical-align: middle;
`;
const Sradio = styled.input`
    margin-left: 6px;
`;

interface ArgProps {
    monsterReport: MonsterReportDTO[];
    setSortType:  React.Dispatch<React.SetStateAction<string>>;
}

const MonsterReportBlock = ({monsterReport, setSortType}: ArgProps) => {
    // ソート項目
    const sortHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSortType(e.target.value);
    }

   return (
        <div>
            <Stable>
                <StHead>
                    <tr>
                        <Std1><label>モンスター名<Sradio type="radio" name="sortType" value="1" onChange={sortHandler}/></label></Std1>
                        <Std2></Std2>
                        <Std3><label>勝利数<Sradio type="radio" name="sortType" value="2" onChange={sortHandler}/></label></Std3>
                        <Std4><label>対戦数<Sradio type="radio" name="sortType" value="3" onChange={sortHandler}/></label></Std4>
                        <Std5><label>勝率<Sradio type="radio" name="sortType" value="4" onChange={sortHandler}/></label></Std5>
                    </tr>
                </StHead>
                <tbody>
                {
                    monsterReport.map((report) => {
                        return (
                            <tr key={report.MonsterId}>
                                <Std1>{report.MonsterName}</Std1>
                                <Std2>
                                    <Simg src={monsterImages(report.MonsterId)} alt=""/>
                                </Std2>
                                <Std3>{report.Wins} 勝</Std3>
                                <Std4>{report.BattleCount} 戦</Std4>
                                <Std5>{report.WinRate}</Std5>
                            </tr>
                        )
                    })
                }
                </tbody>
            </Stable>
        </div>
    );
}

export default MonsterReportBlock;