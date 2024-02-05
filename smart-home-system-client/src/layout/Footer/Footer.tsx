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
                    <div className="footer-copyright">
                        <hr/>
                        <p>Copyright @ 2024</p>
                    </div>
                </div>
           </footer>

        </>);
}
