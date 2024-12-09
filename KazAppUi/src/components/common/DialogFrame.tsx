import styled from "styled-components";
import { COLORS } from "../../lib/Constants";

const SdivDialogFrame = styled.div`
    background-color: ${COLORS.DIALOG_FRAME};
    background-size: cover;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 60%;
    min-width: 510px;
    height: 50%;
    border-radius: 50px;
    box-shadow: ${COLORS.DIALOG_SHADOW} 2px 4px;
    z-index: 1000;
`;
const SdivInnerFrame = styled.div`
    background-color: white;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 95%;
    height: 92%;
    border-radius: 50px;
    z-index: 1000;
`;
const SdivMessageArea = styled.div`
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 80%;
    height: 80%;
    z-index: 1000;
`;
const SimgL = styled.img`
    width: 100px;
    height: 100px;
    position: absolute;
    left: 0;
    bottom: 0;
    z-index: 2000;
`;
const SimgR = styled.img`
    width: 150px;
    height: 170px;
    position: absolute;
    right: 0;
    top: 0;
    z-index: 2000;
`;
const SdivFilter = styled.div`
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.8);
    position: absolute;
    top: 0;
    left: 0;
    z-index: 500;
`;

interface DialogFrameProps {
    renderChild: () => React.ReactNode;
    showDialog: boolean;
    showFilter?: boolean;
}

const DialogFrame = (
    {renderChild, showDialog = true, showFilter}: DialogFrameProps
) => {
    return (
        <>
            <SdivDialogFrame style={{display: showDialog ? "block" : "none"}}>
                {/* <SimgL src={imageL} alt="ツタ"></SimgL> */}
                <SdivInnerFrame>
                    <SdivMessageArea>
                        {renderChild()}
                    </SdivMessageArea>
                </SdivInnerFrame>
                {/* <SimgR src={imageR} alt="ツタ"></SimgR> */}
            </SdivDialogFrame>

            <SdivFilter style={{display: showDialog ? "block" : "none"}}/>
        </>
    );
}
export default DialogFrame;