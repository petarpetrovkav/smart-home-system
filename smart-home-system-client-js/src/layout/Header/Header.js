import React, {useRef, useState} from "react";
import {Link} from "react-router-dom";
import './Header.scss'
import logo from './../../assets/images/6dy5Sp-LogoMakr.png';
import cartIcon from './../../assets/images/cart_icon.png';
import loginIcon from './../../assets/images/icons8-login-50.png';
import nav_dropdown from './../../assets/images/nav_dropdown.png'

export default function Header() {

   /* const menuRef = useRef();*/
    const [menu,setMenu] = useState("home");

/*    const dropdown_toggle = (e) =>{
        menuRef.current.classList.toggle('nav-menu-visible');
        e.target.classList.toggle('open');
    }*/

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
                        <Link to='/register-login' onClick={()=>{setMenu("")}}> <img src={loginIcon} alt="login"/>  </Link>
                        <Link to='/card' onClick={()=>{setMenu("")}}> <img src={cartIcon} alt="cart"/> </Link>
                        <div className="nav-cart-count">0</div>
                    </div>
                </div>
            </header>
        </>);
}
