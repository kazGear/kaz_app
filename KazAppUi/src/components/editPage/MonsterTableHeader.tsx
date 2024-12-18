import Strong from "../common/Strong";

const MonsterTableHeader = () => {
    const prefix = " ⇒ ";

    return (
        <thead>
            <tr>
                <td><Strong>ID</Strong></td>
                <td><Strong>イメージ</Strong></td>
                <td><Strong>モンスター名</Strong></td>
                <td style={{paddingLeft: "10px"}}>{prefix}変更後</td>
                <td><Strong>HP</Strong></td>
                <td style={{paddingLeft: "10px"}}>{prefix}変更後</td>
                <td><Strong>攻撃力</Strong></td>
                <td style={{paddingLeft: "10px"}}>{prefix}変更後</td>
                <td><Strong>速さ</Strong></td>
                <td style={{paddingLeft: "10px"}}>{prefix}変更後</td>
                <td><Strong>弱点</Strong></td>
                <td style={{paddingLeft: "20px"}}>{prefix}変更後</td>
            </tr>
        </thead>
    );
}

export default MonsterTableHeader;