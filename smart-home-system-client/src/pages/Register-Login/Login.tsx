import './RegisterLogin.scss'
import {NavLink} from "react-router-dom";

export default function Login() {
    return (
        <>
            <div className="login">
                <header>
                    <span>Log into your account</span>
                </header>
                <form>
                    <div>
                        <label htmlFor="username">Username:</label>
                        <input name="username" type="text"/>
                    </div>
                    <div>
                        <label htmlFor="password">Password:</label>
                        <input name="password" type="password"/>
                    </div>
                    <NavLink to='/register'>Create account</NavLink>
                    <div>
                        <input type="submit" value="Log In"/>
                    </div>
                </form>
            </div>
        </>);
}