const baseUrl = 'https://localhost:7141';

const login = async(formData) => {
    let responseData;
    await fetch(`${baseUrl}/api/Account/login`,{
            method: 'POST',
            headers:{
                Accept: 'application/json',
                'Content-Type':'application/json',
            },
            body: JSON.stringify(formData),
    }).then((response)=> response.json()).then((data)=>responseData=data).catch((error) => responseData=error);
    return responseData;
}

const register = async(formData) => {
    let responseData;
    await fetch(`${baseUrl}/api/Account/register`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
    }).then((response)=> console.log(response))
        .then((response)=> responseData=response.json())
        .catch((error) => responseData = error);
    return responseData;
}


const RegisterLoginService = {
    login,
    register,
}

export default RegisterLoginService;