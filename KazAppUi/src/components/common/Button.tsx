import styled from "styled-components";
import { COLORS, SIZE } from "../../lib/Constants";
import { MouseEventHandler } from "react";

interface SbuttonProps {
    opacity: number;
    width: string;
}

const Sbutton = styled.button<SbuttonProps>`
    background: ${COLORS.BUTTON_COLOR};
    color: ${COLORS.BUTTON_FORN_COLOR};
    font-weight: 900;
    border: none;
    box-shadow: ${COLORS.SHADOW_COLOR} 2px 2px;
    width: ${props => props.width};
    height: ${SIZE.INPUT_HEIGHT};
    margin: 0 5px 0 5px;
    border-radius: 10px;
    opacity: ${props => props.opacity};

    &:hover {
        cursor: pointer;
        color: ${COLORS.ACCENT_FONT_COLOR2};
    }

    &:active {
        transform: translate(2px, 2px);
        box-shadow: none;
    }
`;

interface ButtonProps {
    id?: string;
    text: string;
    width?: number;
    onClick: MouseEventHandler<HTMLButtonElement>;
    disabled?: boolean;
    styleObj?: React.CSSProperties;
}

const Button = (
    {id, text, width, onClick, disabled = false, styleObj}: ButtonProps
) => {
    const range: string = width ? width + "px" : "100px"
    const opacity = disabled ? COLORS.BUTTON_DISABLED : 1.0;

    return (
        <Sbutton
            id={id}
            type="button"
            width={range}
            onClick={onClick}
            opacity={opacity}
            disabled={disabled}
            style={styleObj}
        >
            {text}
        </Sbutton>
    );
}

export default Button;