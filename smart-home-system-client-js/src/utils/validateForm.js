const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,20}$/;
const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
const usernamePattern = /^[a-zA-Z0-9._-]{3,}$/;

export default function validateForm(name,value, password) {
    console.log(name, value, password);
    switch (name) {
        case "password":
            return passwordPattern.test(value) ? '' : 'Password requirements: 8-20 characters, 1 number, 1 letter, 1 symbol';
        case "email":
            return emailPattern.test(value) ? '' : 'Email is required';
        case "username":
            return usernamePattern.test(value) ? '' : 'UserName is required';
        case "firstName":
            return usernamePattern.test(value) ? '' : 'FirstName is required';
        case "lastName":
            return usernamePattern.test(value) ? '' : 'LastName is required';
        case "confirmPassword":
            return password === value ? '' : 'Password does not match';
        default:
            break;
    }
}

