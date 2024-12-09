export interface Shop {
    ShopId: string;
    ShopName: string;
    WinMoneyUntilCanUse: number;
};

export interface Item {
    ItemId: string;
    ItemName: string;
    ItemPrice: number;
    Remarks: string;
    ItemImage: string;
};