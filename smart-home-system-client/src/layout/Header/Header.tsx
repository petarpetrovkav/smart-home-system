import {useContext} from "react";
import {Link, NavLink} from "react-router-dom";
import UserContext from "../../context/UserContext";
import './Header.scss'
import logo from './../../assets/images/smart-home.png';
import search from './../../assets/images/search.svg';
import shoppingCart from './../../assets/images/shopping-cart.svg';
import loginIcon from './../../assets/images/userLogin.svg';

export default function Header() {
    return (
        <>
            <header>
                <div className="logo">
                    <img src={logo} alt="logo"/>
                </div>

                <nav>
                    <NavLink to='/products' className="nav-link">Products</NavLink>
                    <NavLink to='/contact-us' className="nav-link">Contact</NavLink>
                    <NavLink to='/order' className="nav-link">Order</NavLink>
                </nav>

                <div className="menu-icons">
                    <NavLink to='/search'><img id="search" src={search} alt="search"/></NavLink>
                    <NavLink to='/login'><img id="login" src={loginIcon} alt="login"/></NavLink>
                    <NavLink to='/card'><img id="shoppingCart" src={shoppingCart} alt="cart"/></NavLink>
                </div>
            </header>

        </>);
}
