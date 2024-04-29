import './Home.scss'
import arrow_icon from '../../assets/images/arrow.png';
import NewProduct from "../../components/NewProduct/NewProduct";
import home_hero_feb_sale from '../../assets/images/home-hero-feb-sale.png'

export default function Home() {

    return (
        <>
            <div className='home'>
                <div className="root">
                    <div className="home-left">
                        <h2>Get 20% off smart heating heroes. Hive Got This.</h2>
                        <p>Shrink your bills by up to £200 a year¹ with extra savings on Hive Thermostats (only with professional installation) and Hive Radiator Valves. Offer ends 29th Feb.²</p>
                        <div className="home-latest-btn">
                            <div>Shop the sale</div>
                        </div>
                    </div>
                    <div className="home-right">
                        <img src={home_hero_feb_sale} alt=""/>
                    </div>
                </div>
                <NewProduct/>
            </div>

        </>);
}