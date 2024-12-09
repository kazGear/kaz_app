import styled from "styled-components";
import { BattleReportDTO } from "../../types/BattleReport";
import { COLORS } from "../../lib/Constants";
import monsterImages from "../../lib/MonsterImages";
import React from "react";

const Stable = styled.table`
    width: 100%;
    border-collapse: collapse;
`;
const StdHeader = styled.td`
    border-top: ${COLORS.BORDER_COLOR} 5px double;
    border-left: ${COLORS.BORDER_COLOR} 1px solid;
    border-right: ${COLORS.BORDER_COLOR} 1px solid;
    padding-left: 10px;
    color: ${COLORS.CAPTION_FONT_COLOR};
    height: 25px;
    align-content: start;
    font-weight: bold;
`;
const Std1 = styled.td`
    width: 15%;
    border-left: ${COLORS.BORDER_COLOR} 1px solid;
    padding-left: 20px;
`;
const Std2 = styled.td`
    width: 45%;
`;
const Std3 = styled.td`
    width: 20%;
`;
const Std4 = styled.td`
    width: 20%;
    border-right: ${COLORS.BORDER_COLOR} 1px solid;
    color: ${COLORS.ACCENT_FONT_COLOR2};
    text-align: left;
`;
const Simg = styled.img`
    width: 50px;
    height: 50px;
`;

interface ArgProps {
    battleReport: BattleReportDTO[];
}

const BattleReportBlock = ({battleReport}: ArgProps) => {

    return (
        <Stable>
            <tbody>
            {
                battleReport.map((report, index) => {
                    return (
                        <React.Fragment key={index}>
                        { report.Serial === 1 ? // ヘッダーは１試合に１つ
                            <tr>
                                <StdHeader colSpan={4} >
                                    No. {report.BattleId}
                                    &emsp;&emsp;{report.BattleEndDateStr}
                                    &emsp;{report.BattleEndTimeStr}
                                </StdHeader>
                            </tr>
                            : ""
                        }
                            <tr >
                                <Std1>{report.Serial}</Std1>
                                <Std2>{report.MonsterName}</Std2>
                                <Std3>
                                    <Simg src={monsterImages(report.MonsterId)} alt=""/>
                                </Std3>
                                <Std4>{report.IsWin ? "Winner !!" : ""}</Std4>
                            </tr>
                        </React.Fragment>
                    )
                })
            }
            </tbody>
        </Stable>
    );
}

export default BattleReportBlock;