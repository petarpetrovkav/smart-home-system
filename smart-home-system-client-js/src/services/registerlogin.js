const baseUrl = 'https://localhost:7141';

const login = async() => {
    await fetch('http://localhost:4000/login',{
        method: 'POST',
        headers:{
            Accept: 'application/from-data',
            'Content-Type':'application/json',
        },
        body: JSON.stringify(formData),
    }).then((response)=> response.json()).then((data)=>responseData=data)
}


const RegisterLoginService = {
    login,
}

export default RegisterLoginService;