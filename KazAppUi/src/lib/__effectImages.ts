import effect1 from "../images/effects/effect1.gif";
import effect2 from "../images/effects/effect2.gif";
import effect3 from "../images/effects/effect3.gif";
import effect4 from "../images/effects/effect4.gif";
import effect5 from "../images/effects/effect5.gif";
import effect6 from "../images/effects/effect6.gif";
import effect7 from "../images/effects/effect7.gif";
import effect8 from "../images/effects/effect8.gif";
import effect9 from "../images/effects/effect9.gif";
import effect10 from "../images/effects/effect10.gif";
import effect11 from "../images/effects/effect11.gif";
import effect12 from "../images/effects/effect12.gif";
import effect13 from "../images/effects/effect13.gif";
import effect14 from "../images/effects/effect14.gif";
import effect15 from "../images/effects/effect15.gif";
import effect16 from "../images/effects/effect16.gif";
import effect17 from "../images/effects/effect17.gif";
import effect18 from "../images/effects/effect18.gif";
import effect19 from "../images/effects/effect19.gif";
import effect20 from "../images/effects/effect20.gif";
import effect21 from "../images/effects/effect21.gif";
import effect22 from "../images/effects/effect22.gif";
import effect23 from "../images/effects/effect23.gif";
import effect24 from "../images/effects/effect24.gif";
import effect25 from "../images/effects/effect25.gif";
import effect26 from "../images/effects/effect26.gif";
import effect27 from "../images/effects/effect27.gif";
import effect28 from "../images/effects/effect28.gif";
import effect29 from "../images/effects/effect29.gif";
import effect30 from "../images/effects/effect30.gif";
import effect31 from "../images/effects/effect31.gif";
import effect32 from "../images/effects/effect32.gif";
import effect33 from "../images/effects/effect33.gif";
import effect34 from "../images/effects/effect34.gif";
import effect35 from "../images/effects/effect35.gif";
import effect36 from "../images/effects/effect36.gif";
import effect37 from "../images/effects/effect37.gif";
import effect38 from "../images/effects/effect38.gif";
import effect39 from "../images/effects/effect39.gif";
import effect40 from "../images/effects/effect40.gif";
import effect41 from "../images/effects/effect41.gif";
import effect42 from "../images/effects/effect42.gif";
import effect43 from "../images/effects/effect43.gif";
import effect44 from "../images/effects/effect44.gif";
import effect45 from "../images/effects/effect45.gif";
import effect46 from "../images/effects/effect46.gif";
import effect47 from "../images/effects/effect47.gif";
import effect48 from "../images/effects/effect48.gif";
import effect49 from "../images/effects/effect49.gif";
import effect58 from "../images/effects/effect58.gif";
import effect59 from "../images/effects/effect59.gif";
import effect60 from "../images/effects/effect60.gif";
import effect61 from "../images/effects/effect61.gif";
import effect62 from "../images/effects/effect62.gif";
import effect63 from "../images/effects/effect63.gif";
import effect64 from "../images/effects/effect64.gif";
import effect65 from "../images/effects/effect65.gif";
import effect66 from "../images/effects/effect66.gif";
import effect67 from "../images/effects/effect67.gif";
import effect68 from "../images/effects/effect68.gif";
import effect69 from "../images/effects/effect69.gif";

interface EffectDict {
    [key: string]: string | null;
}
const effectImages = (effectId: string): string => {
    const effectImages: EffectDict = {};

    effectImages["skill000"] = null; // index: 0 (エフェクトなし)
    effectImages["skill001"] = effect1;
    effectImages["skill002"] = effect2;
    effectImages["skill003"] = effect3;
    effectImages["skill004"] = effect4;
    effectImages["skill005"] = effect5;
    effectImages["skill006"] = effect6;
    effectImages["skill007"] = effect7;
    effectImages["skill008"] = effect8;
    effectImages["skill009"] = effect9;
    effectImages["skill010"] = effect10;
    effectImages["skill011"] = effect11;
    effectImages["skill012"] = effect12;
    effectImages["skill013"] = effect13;
    effectImages["skill014"] = effect14;
    effectImages["skill015"] = effect15;
    effectImages["skill016"] = effect16;
    effectImages["skill017"] = effect17;
    effectImages["skill018"] = effect18;
    effectImages["skill019"] = effect19;
    effectImages["skill020"] = effect20;
    effectImages["skill021"] = effect21;
    effectImages["skill022"] = effect22;
    effectImages["skill023"] = effect23;
    effectImages["skill024"] = effect24;
    effectImages["skill025"] = effect25;
    effectImages["skill026"] = effect26;
    effectImages["skill027"] = effect27;
    effectImages["skill028"] = effect28;
    effectImages["skill029"] = effect29;
    effectImages["skill030"] = effect30;
    effectImages["skill031"] = effect31;
    effectImages["skill032"] = effect32;
    effectImages["skill033"] = effect33;
    effectImages["skill034"] = effect34;
    effectImages["skill035"] = effect35;
    effectImages["skill036"] = effect36;
    effectImages["skill037"] = effect37;
    effectImages["skill038"] = effect38;
    effectImages["skill039"] = effect39;
    effectImages["skill040"] = effect40;
    effectImages["skill041"] = effect41;
    effectImages["skill042"] = effect42;
    effectImages["skill043"] = effect43;
    effectImages["skill044"] = effect44;
    effectImages["skill045"] = effect45;
    effectImages["skill046"] = effect46;
    effectImages["skill047"] = effect47;
    effectImages["skill048"] = effect48;
    effectImages["skill049"] = effect49;
    effectImages["skill050"] = null;
    effectImages["skill051"] = null;
    effectImages["skill052"] = null;
    effectImages["skill053"] = null;
    effectImages["skill054"] = null;
    effectImages["skill055"] = null;
    effectImages["skill056"] = null;
    effectImages["skill057"] = null;
    effectImages["skill058"] = effect58;
    effectImages["skill059"] = effect59;
    effectImages["skill060"] = effect60;
    effectImages["skill061"] = effect61;
    effectImages["skill062"] = effect62;
    effectImages["skill063"] = effect63;
    effectImages["skill064"] = effect64;
    effectImages["skill065"] = effect65;
    effectImages["skill066"] = effect66;
    effectImages["skill067"] = effect67;
    effectImages["skill068"] = effect68;
    effectImages["skill069"] = effect69;

    return effectImages[effectId] ?? "";
}

export default effectImages;