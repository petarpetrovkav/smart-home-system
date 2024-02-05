import './Home.scss'
import arrow_icon from '../../assets/images/arrow.png';
import NewProduct from "../../components/NewProduct/NewProduct";

export default function Home() {
    return (
        <>
            <div className='home'>
                <div className="root">
                    <div className="home-left">
                        <h2>Hive Thermostat Mini. Hive Got This.</h2>
                        <p>Super-efficient schedules, handy budgeting tools and instant alerts to save you money. The Hive Thermostat Mini has it all – at an even more affordable price.</p>
                        {/*<div>
                            <div className="home-hand-icon">
                                <p>Super-efficient schedules, handy budgeting tools and instant alerts to save you money. The Hive Thermostat Mini has it all – at an even more affordable price.</p>
                            </div>
                        </div>*/}
                        <div className="home-latest-btn">
                            <div>Get yours</div>
                            <img src={arrow_icon} alt=""/>
                        </div>
                    </div>
                    <div className="home-right">
                       {/* <img src={home_image} alt=""/>*/}
                    </div>
                </div>
                <NewProduct/>
            </div>

        </>);
}