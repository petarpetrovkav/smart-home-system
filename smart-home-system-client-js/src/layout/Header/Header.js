import React, {useContext, useRef, useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import './Header.scss'
import logo from './../../assets/images/6dy5Sp-LogoMakr.png';
import cartIcon from './../../assets/images/cart_icon.png';
import {ShopContext} from "../../context/ShopContext";

export default function Header() {
    const navigate = useNavigate();
    const [menu,setMenu] = useState("home");
    const {getTotalCartItems} = useContext(ShopContext);

    const logout = () =>{
        localStorage.removeItem('auth-token');
        localStorage.removeItem('username');
        navigate("/");
    }

    return (
        <>
            <header>
                <div className='navbar'>
                    <div className='nav-logo'>
                        <img src={logo} alt={logo}/>
                    </div>
                 {/*   <img onClick={dropdown_toggle} className="nav-drop-down" src={nav_dropdown} alt=""/>*/}
                    <ul className="nav-menu">          {/* ref={menuRef}*/}
                        <li onClick={()=>{setMenu("home")}}>
                            <Link to='/' className="link"> Home </Link> {menu==="home"?<hr/>:<></>}
                        </li>
                        <li onClick={()=>{setMenu("products")}}>
                            <Link to='/products' className="link"> Product </Link> {menu==="products"?<hr/>:<></>}
                        </li>
                        <li onClick={()=>{setMenu("order")}}>
                            <Link to='/order' className="link"> Order  </Link>{menu==="order"?<hr/>:<></>}
                        </li>
                    </ul>
                    <div className='nav-login-cart'>
                        {
                            localStorage.getItem('auth-token') ? <button onClick={logout}>Logout</button>
                                : <Link to='/register-login'> <button>Login</button> </Link>
                        }
                  {/*      <Link to='/register-login' onClick={()=>{setMenu("")}}> <img src={loginIcon} alt="login"/>  </Link>*/}
                        <Link to='/card' onClick={()=>{setMenu("")}}> <img src={cartIcon} alt="cart"/> </Link>
                        <div className="nav-cart-count">{getTotalCartItems()}</div>
                    </div>
                </div>
            </header>
        </>);
}
