import {Link, NavLink} from "react-router-dom";
import './Footer.scss'
import footer_logo from '../../assets/images/logo_big.png';
import pintester_icon from '../../assets/images/pintester_icon.png';
import whatsapp_icon from '../../assets/images/whatsapp_icon.png';
import instagram_icon from '../../assets/images/instagram_icon.png';


export default function Footer() {
    return (
        <>
            <footer>
                <div className="footer">
                    <div className="footer-logo">
                        <img src={footer_logo} alt="logo"/>
                        <p>SHOPPER</p>
                    </div>
                    <ul className="footer-links">        {/*ul.footer-links>li*5*/}
                        <li>Company</li>
                        <li>Company</li>
                        <li>Company</li>
                        <li>Company</li>
                        <li>Company</li>
                    </ul>
                    <div className="footer-social-icon">
                        <div className="footer-icons-container">
                            <img src={instagram_icon} alt=""/>
                        </div>
                        <div className="footer-icons-container">
                            <img src={pintester_icon} alt=""/>
                        </div>
                        <div className="footer-icons-container">
                            <img src={whatsapp_icon} alt=""/>
                        </div>
                    </div>
                    <div className="footer-copyright">
                        <hr/>
                        <p>Copyright @ 2024</p>
                    </div>
                </div>
           </footer>

        </>);
}
