import styled from "styled-components";
import { COLORS } from "../../lib/Constants";


const Sdiv = styled.div`
    border: solid 1px ${COLORS.BORDER_COLOR};
    box-shadow: 4px 4px ${COLORS.SHADOW_COLOR};
    overflow: overlay;
    background: ${COLORS.BASE_BACKGROUND};
    border-radius: 10px 0 10px 0
`;

interface ArgProps {
    children: React.ReactNode;
    styleObj?: React.CSSProperties;
}

const OutSideFrame = ({children, styleObj}: ArgProps) => {
    return (
        <Sdiv style={styleObj}>
            {children}
        </Sdiv>
    );
}

export default OutSideFrame;