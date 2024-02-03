import axios from "axios";

export async function registrationUserAsync(username, email, password) {
    const { data: user } = await axios.post('/user/registration', {
        username: username,
        email: email,
        password: password
    });
    return user;
}