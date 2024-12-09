import TestPageLinks from "../components/common/TestPageLinks";

const MyPage = () => {

    return (
        <>
            <div>mypage.</div>

            <div style={{ display: "flex" }}>
                <div>myIcon</div>
                <ul>
                    <li style={{ listStyle: "none" }}>content1</li>
                    <li style={{ listStyle: "none" }}>content2</li>
                    <li style={{ listStyle: "none" }}>content3</li>
                </ul>
            </div>

            <div>
                <div>status.</div>

                <table>
                    <tbody>
                        <tr>
                            <td>所持金</td>
                            <td>800</td>
                        </tr>
                        <tr>
                            <td>Atk</td>
                            <td>10</td>
                            <td>Def</td>
                            <td>8</td>
                        </tr>
                        <tr>
                            <td>武器</td>
                            <td>5</td>
                            <td>防具</td>
                            <td>8</td>
                        </tr>
                        <tr>
                            <td>total Atk</td>
                            <td>15</td>
                            <td>total Ðef</td>
                            <td>16</td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div>
                <div>Equipments.</div>

                <table>
                    <tbody>
                        <tr>
                            <td>weapon name</td>
                            <td>bronze sword</td>
                            <td><button>装備</button></td>
                            <td><button>外す</button></td>
                        </tr>
                        <tr>
                            <td>armor name</td>
                            <td>wood Shield</td>
                            <td><button>装備</button></td>
                            <td><button>外す</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div>
                <div>skills.</div>

                <table>
                    <tbody>
                        <tr>
                            <td>ほのお</td>
                            <td><button>装備</button></td>
                            <td><button>外す</button></td>
                        </tr>
                        <tr>
                            <td>いかずち</td>
                            <td><button>装備</button></td>
                            <td><button>外す</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <TestPageLinks />
        </>
    );
};

export default MyPage;
