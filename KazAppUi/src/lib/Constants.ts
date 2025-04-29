const ACCENT_COLOR: string = "#0aff84";
const ACCENT_COLOR2: string = "#F05F8D";
const ALERT_COLOR: string = "red";
export const COLORS = {
    MAIN_FONT_COLOR: "gray",
    ACCENT_FONT_GREEN: `${ACCENT_COLOR}`,
    ACCENT_FONT_PINK: `${ACCENT_COLOR2}`,
    LOSER_FONT_COLOR: "#EC008C",
    ALERT_MESSAGE_COLOR: `${ALERT_COLOR}`,
    CAPTION_FONT_COLOR: "#33cc99",
    BUTTON_FORN_COLOR: "gray",

    BORDER_COLOR: "darkgray",
    LINE_COLOR: "blue",

    SHADOW_COLOR: "dimgrey",
    DIALOG_SHADOW: "gray",
    MENU_SHADOW: "gray",

    BUTTON_COLOR: `${ACCENT_COLOR}`,
    BUTTON_DISABLED: 0.3,

    THEME_COLOR: "#7fffd4",
    BASE_BACKGROUND: "white",

    MENU_DISABLED: "darkgray",

    DIALOG_FRAME: `${ACCENT_COLOR}`,
} as const;

export const SIZE = {
    INPUT_HEIGHT: "22px"
} as const;

export const STATE_TYPE = {
    NORMAL: 0,
    POISON: 1,
    SLEEP: 2,
    CHARM: 3,
    SLOW: 4,
    POWER_UP: 5,
    DODGE_UP: 6,
    CRITICAL_UP: 7,
    AUTO_HEAL: 8
} as const;

export const STATE_NAME = {
    NORMAL: "正常",
    LOSER: "戦闘不能",
    POISON: "毒",
    SLEEP: "睡眠",
    CHARM: "魅了",
    SLOW: "スロー",
    POWER_UP: "攻撃力UP",
    DODGE_UP: "回避力UP",
    CRITICAL_UP: "クリティカルUP",
    AUTO_HEAL: "自動回復"
} as const;

export const DAMAGE_VIEW = {
    DODGE_START: 0,
    DODGE_END: 1500,
    DAMAGE_END: 2500,
} as const;

// 環境でドメインが変化
const DOMAIN = {
    LOCAL_HOST_API: `http://localhost:5000`,
    XSERVER_API: `https://kazapp-trial.com`,
}
////////////////////////////////////////////////////////////////
// ドメインを決定。デプロイ前に確認 ///////////////////////////////
////////////////////////////////////////////////////////////////
const ENVIRONMENT = DOMAIN.LOCAL_HOST_API;
// const ENVIRONMENT = DOMAIN.XSERVER_API;
export const URLS = {
    // 基本情報取得
    USER_INFO: `${ENVIRONMENT}/api/user/userInfo`,
    MONSTERS_INFO: `${ENVIRONMENT}/api/battle/monstersInfo`,
    ITEM_INFO: `${ENVIRONMENT}/api/shop/itemInfo`,
    FETCH_ELEMENT_CODE: `${ENVIRONMENT}/api/common/FetchElementCode`,
    // ユーザ関係
    REGIST_USER_INIT: `${ENVIRONMENT}/api/user/init`,
    SELECT_LOGIN_USER: `${ENVIRONMENT}/api/user/loginUser`,
    RECORD_USER_RESULT: `${ENVIRONMENT}/api/user/recordUserResults`,
    REGIST_USER: `${ENVIRONMENT}/api/user/userRegist`,
    RESTART_AS_PLAYER: `${ENVIRONMENT}/api/user/restartAsPlayer`,
    GET_MONSTER_COUNT: `${ENVIRONMENT}/api/user/getMonsterCount`,
    // バトル、モンスター関係
    INIT_MONSTERS: `${ENVIRONMENT}/api/battle/init`,
    BET_RATE: `${ENVIRONMENT}/api/battle/betRate`,
    BATTLE_NEXT_TURN: `${ENVIRONMENT}/api/battle/nextTurn`,
    RECORD_BATTLE_RESULT: `${ENVIRONMENT}/api/battle/recordResults`,
    // レポート関係
    INIT_BATTLE_REPORT: `${ENVIRONMENT}/api/battleReport/init`,
    MONSTER_REPORTS: `${ENVIRONMENT}/api/battleReport/monsterReport`,
    BATTLE_REPORTS: `${ENVIRONMENT}/api/battleReport/battleReport`,
    // 認証系
    LOGIN_USER: `${ENVIRONMENT}/api/auth/login`,
    CHECK_LOGIN_TOKEN: `${ENVIRONMENT}/api/auth/checkToken`,
    // ショップ系
    SHOP_INIT: `${ENVIRONMENT}/api/shop/init`,
    SELECT_SHOP_ITEMS: `${ENVIRONMENT}/api/shop/items`,
    PURCHASE_ITEM: `${ENVIRONMENT}/api/shop/purchase`,
    // 設定系
    EDIT_INIT: `${ENVIRONMENT}/api/edit/init`,
    FETCH_EDIT_MONSTERS: `${ENVIRONMENT}/api/edit/fetchMonsters`,
    UPDATE_MONSTER_STATUS: `${ENVIRONMENT}/api/edit/updateMonsterStatus`,
    INIT_ALL_MONSTERS_STATUS: `${ENVIRONMENT}/api/edit/initAllMonsterStatus`,
    INIT_ALL_MONSTERS_SKILLS: `${ENVIRONMENT}/api/edit/initAllMonsterSkills`,
    FETCH_EDIT_SKILLS: `${ENVIRONMENT}/api/edit/FecthEditSkills`,
    FETCH_ALL_SKILLS: `${ENVIRONMENT}/api/edit/fecthAllSkills`,
    CHANGE_MONSTER_SKILLS: `${ENVIRONMENT}/api/edit/UpdateMonsterSkills`,
    // その他
    UPLOAD_IMAGE: `${ENVIRONMENT}/api/common/imgUpload`
} as const;

export const KEYS = {
    TOKEN: "token",
    USER_ID: "userId",
    USER_ROLE: "userRole",
    ORDER_BY_ASC: "ASC",
    ORDER_BY_DESC: "DESC"
} as const;

export const PREFIX = {
    BASE64: "data:image/jpeg;base64,"
} as const;

export const DECO = {
    BLOCK_LINE: "■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋",
    BLOCK_LINE_R: "＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■＋■"
}

export const EDIT_TYPE = {
    MONSTER_STATUS: 1,
    MONSTER_SKILL: 2,
    USE_MONSTER: 3
}

export const USER_ROLE = {
    NORMAL: 1,
    EXCELLENT: 2,
    DUCK: 3,
    BE_CAREFUL: 4,
    BLACK_LIST: 5,
    ADMIN: 90,
    SUPER_ADMIN: 91
}