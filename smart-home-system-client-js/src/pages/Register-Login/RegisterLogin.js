import './RegisterLogin.scss'
import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import RegisterLoginService from "../../services/registerlogin";
import validateForm from "../../utils/validateForm";

export default function RegisterLogin() {

const [state, setState] = useState(true);
const [formData, setFormData] = useState({ username:"", password:"", country:"", email:"", confirmPassword:"", firstName:"", lastName:"" })
const [errors, setErrors] = useState({ username: "", password:"", country:"", email:"", confirmPassword:"", firstName:"", lastName:""  });
const [success, setSuccess] = useState("");
const navigate = useNavigate();

const changeHandler = (e) => {
    const { name, value } = e.target;
    setFormData({...formData,[name]:value});

    if(state !== true){
        const error = validateForm(name, value, formData.password);
        setFormData({ ...formData, [name]:value});
        setErrors({ ...errors, [name]: error });
    }
}

const resetFields = () => {
    setFormData(prevState => ({
                ...prevState,
                username: "",
                password: "",
                country: "",
                email: "",
                confirmPassword: "",
                firstName: "",
                lastName: ""
    }));
}

const login = async () => {
    const responseData = await RegisterLoginService.login(formData);

   if(responseData.title !== 'Bad Request'){
        console.log(`TOKEN: ${responseData.token} and username: ${responseData.username}`);
        localStorage.setItem("auth-token",responseData.token);
        localStorage.setItem("username",responseData.username);
        navigate("/");
    }
    else{
        setState(false);
        resetFields();
        navigate("/register-login");
    }
}

const signup = async () => {
    if(formData.username !== "" && formData.email !== "" && formData.password !== "" && formData.firstName !== "" && formData.lastName !== "" &&  formData.confirmPassword !== "" &&
        errors.username === "" && errors.email === "" && errors.password === "" && errors.firstName === "" && errors.lastName === "" && errors.confirmPassword === ""){
        const response = await RegisterLoginService.register(formData);
        response === "Username exist!" && setErrors({ ...errors, ["username"]: response });
        response === "Email exist!" && setErrors({ ...errors, ["email"]: response });
        response === "You have successfully registered" && (redirectToLogin(response));
    }
}

const redirectToLogin = (response) =>{
    setSuccess(response);
    resetFields();
    setState(true);
}


    return (

            <div id="login">
                <div className="login-signup">
                    <div className="login-signup-container">
                        <h1>{state}</h1>
                        <div className="login-signup-fields">
                            <input type="text" name='username' id='username' value={formData.username} onChange={changeHandler} placeholder='Your Name'/>
                            {errors.username && <span className="error">{errors.username}</span>}

                            {state === false ?
                                <input type="text" name='firstName' id='firstName' value={formData.firstName} onChange={changeHandler} placeholder='First Name'/> : <></> }
                            {errors.firstName && <span className="error">{errors.firstName}</span>}

                            {state === false ?
                                <input type="text" name='lastName' id='lastName' value={formData.lastName} onChange={changeHandler} placeholder='Last Name'/> : <></> }
                            {errors.lastName && <span className="error">{errors.lastName}</span>}

                            {state === false ? <input type="email" name='email' id='email' value={formData.email} onChange={changeHandler} placeholder='Email Address'/> : <></> }
                            {errors.email && <span className="error">{errors.email}</span>}

                            <input type="password" name='password' id='password' value={formData.password} onChange={changeHandler} placeholder='Password'/>
                            {errors.password && <span className="error">{errors.password}</span>}

                            {state === false ?
                                <input type="password" name='confirmPassword' id='confirmPassword' value={formData.confirmPassword}
                                       onChange={changeHandler} placeholder='Confirm Password'/>  : <></> }
                            {errors.confirmPassword && <span className="error">{errors.confirmPassword}</span>}

                            {state === false ?
                                <input type="text" name='country' value={formData.country} onChange={changeHandler} placeholder='Country'/> : <></> }

                        </div>
                        {success && <span className="success">{success}</span>}
                        <button onClick={()=>{state===true?login():signup()}}>Continue</button>

                        {state===false
                            ? <p className="login-signup-login">Already have an account?<span onClick={()=>{setState(true)}}>Login here</span></p>
                            : <p className="login-signup-login">Create an account?<span onClick={()=>{setState(false)}}>Click here</span></p>
                        }
                    </div>
                </div>
            </div>
        );
}