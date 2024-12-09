import './App.css';
import IndexPage from './pages/IndexPage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import BattlePage from './pages/BattlePage';
import ShopPage from './pages/ShopPage';
import MyPage from './pages/MyPage';
import MyCartPage from './pages/MyCartPage';
import LoginPage from "./pages/LoginPage";
import AppHeader from './components/common/AppHeader';
import BattleResultPage from './pages/BattleResultPage';
import UserPage from "./pages/UserPage";

function App() {
    return (
        <BrowserRouter>
            <AppHeader title="KazApp" />
            <Routes>
                <Route path={"/"} element={<IndexPage />} />
                <Route path={"/IndexPage"} element={<IndexPage />} />
                <Route path={"/LoginPage"} element={<LoginPage />} />
                <Route path={"/myCartPage"} element={<MyCartPage />} />
                <Route path={"/myPage"} element={<MyPage />} />
                <Route path={"/ShopPage"} element={<ShopPage />} />
                <Route path={"/BattlePage"} element={<BattlePage />} />
                <Route path={"/BattleResultPage"} element={<BattleResultPage />} />
                <Route path={"/UserPage"} element={<UserPage />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
