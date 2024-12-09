import { useEffect, useRef, useState } from "react";
import monsterImages from "../../lib/MonsterImages";
import styled from "styled-components";
import effectImages from "../../lib/effectImages"
import { DAMAGE_VIEW } from "../../lib/Constants";
import { isEmpty } from "../../lib/CommonLogic";
import { MetaDataDTO, MonsterDTO } from "../../types/MonsterBattle";


const SdivMonsterImgFrame = styled.div`
    margin: 10px 0 5px 0;
`;
const SdivMonsterImg = styled.div`
    position: relative;
`;

const SimgMonster = styled.img`
    position: relative;
    width: 130px;
    height: 130px;
    border-radius: 100%;
`;
interface SimgEffectProp { display: string; }
const SimgEffect = styled.img<SimgEffectProp>`
    display: ${props => props.display};
    position: absolute;
    left: 0;
    width: 100%;
    height: 100%;
`;

interface ArgProps {
    monster: MonsterDTO;
    shortLog: MetaDataDTO[];
}

const MonsterImgBlock = ({monster, shortLog}: ArgProps) => {
    const imgRef = useRef<HTMLImageElement>(null);
    const [effectImage, setEffectImage] = useState("");
    const [showEffect, setShowEffect] = useState(false);
    const [showFlash, setShowFlash] = useState(false);
    const monsterImage = monsterImages(monster.MonsterId);

    // ダメージ表現
    useEffect(() => {
        for (const log of shortLog) {
            if (   log.TargetMonsterId === monster.MonsterId
                && !isEmpty(log.SkillId)
            ) {
                setEffectImage(effectImages(log.SkillId ?? ""));
                setShowEffect(true);
                setTimeout(() => setShowEffect(false), DAMAGE_VIEW.EFFECT_END);
                setTimeout(() => setShowFlash(true), DAMAGE_VIEW.EFFECT_END);
                setTimeout(() => setShowFlash(false), DAMAGE_VIEW.DAMAGE_END);
            }
        }
    }, [shortLog]);

    return (
        <SdivMonsterImgFrame>
            <SdivMonsterImg>
                <SimgMonster
                    id={"monsterImage" + monster.MonsterId}
                    src={monsterImage}
                    alt="Loding ..."
                    ref={imgRef}
                    style={{animation: showFlash ? "0.8s flash" : ""}}
                    />
                <SimgEffect
                    src={effectImage}
                    alt="Loding ..."
                    display={showEffect ? "inline" : "none"}
                    />
            </SdivMonsterImg>
        </SdivMonsterImgFrame>
    );
}

export default MonsterImgBlock;