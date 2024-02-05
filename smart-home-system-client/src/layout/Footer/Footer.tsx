import './Footer.scss'
import footer_logo from '../../assets/images/6dy5Sp-LogoMakr.png';


export default function Footer() {
    return (
        <>
            <footer>
                <div className="footer">
                    <div className="footer-logo">
                        <img src={footer_logo} alt="logo"/>
                    </div>
               {/*     <ul className="footer-links">        ul.footer-links>li*5
                        <li>Home</li>
                        <li>Product</li>
                        <li>Order</li>
                    </ul>*/}
                    <div className="footer-copyright">
                        <hr/>
                        <p>Copyright @ 2024</p>
                    </div>
                </div>
           </footer>

        </>);
}
