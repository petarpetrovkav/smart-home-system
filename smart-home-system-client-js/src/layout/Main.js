import { Outlet } from "react-router-dom";
import Header from "./Header/Header";
import Footer from "./Footer/Footer";

export default function Main() {
    return (
        <>
            <Header/>
            <Outlet/>
            <Footer/>
        </>
     );
}