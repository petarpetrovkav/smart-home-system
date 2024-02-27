import './RegisterLogin.scss'
import {NavLink} from "react-router-dom";
import React, {useState} from "react";
import RegisterLoginService from "../../services/registerlogin";

const [state, setState] = useState("Login");
const[formData, setFormData] = useState({
    username:"",
    password:"",
    country:"",
    email:"",
    confirmPassword:"",
    firstName:"",
    lastName:""
})

const changeHandler = (e) => {
    setFormData({...formData,[e.target.name]:e.target.value})
}

const login = async () => {

}

const signup = async () => {

}

export default function RegisterLogin() {
    return (

            <div id="login">
                <div className="login-signup">
                    <div className="login-signup-container">
                        <h1>Sign Up</h1>
                        <div className="login-signup-fields">
                            <input type="text" placeholder='Your Name'/>
                            <input type="email" placeholder='Email Address'/>
                            <input type="password" placeholder='Password'/>
                        </div>
                        <button>Continue</button>
                        <p className="login-signup-login">Already have an account?<span>Login here</span></p>
                    </div>
                </div>
            </div>
        );
}