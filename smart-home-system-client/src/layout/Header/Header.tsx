import {useContext, useState} from "react";
import {Link, NavLink} from "react-router-dom";
import UserContext from "../../context/UserContext";
import './Header.scss'
import logo from './../../assets/images/6dy5Sp-LogoMakr.png';
import cartIcon from './../../assets/images/cart_icon.png';
import loginIcon from './../../assets/images/icons8-login-50.png';

export default function Header() {

    const [menu,setMenu] = useState("home");

    return (
        <>
            <header>
                <div className='navbar'>
                    <div className='nav-logo'>
                        <img src={logo} alt={logo}/>
                    </div>
                    <ul className='nav-menu'>
                        <li onClick={()=>{setMenu("home")}}><Link to='/' style={{ textDecoration: "none"}}> Home </Link> {menu==="home"?<hr/>:<></>} </li>
                        <li onClick={()=>{setMenu("products")}}><Link to='/products' style={{ textDecoration: "none"}}> Product </Link> {menu==="products"?<hr/>:<></>} </li>
                        <li onClick={()=>{setMenu("order")}}><Link to='/order' style={{ textDecoration: "none"}}> Order  </Link>{menu==="order"?<hr/>:<></>}</li>
                    </ul>
                    <div className='nav-login-cart'>
                        <Link to='/login'> <img src={loginIcon} alt="login"/>  </Link>
                        <Link to='/card'> <img src={cartIcon} alt="login"/> </Link>
                        <div className="nav-cart-count">0</div>
                    </div>
                </div>
            </header>
        </>);
}
