import styled from "styled-components";
import nowLoading from "../../images/background/nowLoading2.gif";

interface StyleProps {
    size?: string;
}

const Simg = styled.img<StyleProps>`
    width: ${(props) => props.size ?? "100px"};
    height: ${(props) => props.size ?? "100px"};
    border-radius: 100%;
`;

interface ArgProps {
    alt: string;
    size?: string;
}

const NowLoading = ({alt, size}: ArgProps) => {
    return <Simg src={nowLoading}
                 alt={alt}
                 size={size}/>;
}

export default NowLoading;