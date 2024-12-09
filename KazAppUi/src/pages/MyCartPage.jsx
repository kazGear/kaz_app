import TestPageLinks from "../components/common/TestPageLinks";

const MyCartPage = () => {
    return (
        <>
            <div>myCart page.</div>

            <div style={{ display: "flex" }}>
                <div>myIcon</div>
                <ul>
                    <li style={{ listStyle: "none" }}>content1</li>
                    <li style={{ listStyle: "none" }}>content2</li>
                    <li style={{ listStyle: "none" }}>content3</li>
                </ul>
            </div>

            <div>
                 <table>
                    <tr>
                        <td>content1</td>
                        <td>content2</td>
                        <td>content3</td>
                    </tr>
                </table>
            </div>

            <div>
                <div>cart items.</div>
                <table>
                    <tr>
                        <td>item1 content1</td>
                        <td>item1 content2</td>
                        <td>item1 content3</td>
                    </tr>
                    <tr>
                        <td>item2 content1</td>
                        <td>item2 content2</td>
                        <td>item2 content3</td>
                    </tr>
                    <tr>
                        <td>item3 content1</td>
                        <td>item3 content2</td>
                        <td>item3 content3</td>
                    </tr>
                </table>
            </div>

            <TestPageLinks />
        </>
    );
};

export default MyCartPage;
