import React, { ChangeEventHandler } from "react";
import styled from "styled-components";
import { COLORS, SIZE } from "../../lib/Constants";

const SdivFrame = styled.div`
    margin: 10px;
`;

const Sselect = styled.select`
    width: 150px;
    margin: 0 10px 0 10px;
    height: ${SIZE.INPUT_HEIGHT};
    border: 1px solid ${COLORS.BORDER_COLOR};
    box-shadow: ${COLORS.DIALOG_SHADOW} 1px 1px;
    color: ${COLORS.MAIN_FONT_COLOR};
`;

interface ArgProps {
    title?: string;
    children: |React.ReactNode[] | React.ReactNode;
    onChange?: ChangeEventHandler<HTMLSelectElement>;
}

const Select = ({title, children, onChange}: ArgProps) => {
    return (
        <SdivFrame>
            <label>{title}</label>
            <Sselect onChange={onChange}>
                {children}
            </Sselect>
        </SdivFrame>
    );
}

export default Select;