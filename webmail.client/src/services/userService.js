import axios from "axios";

export async function registrationUserAsync(username, email, password) {
    const { data: user } = await axios.post('/user/registration', {
        username: username,
        email: email,
        password: password
    });
    return user;
}

export async function authorizationUserAsync(email, password) {
    const { data: user } = await axios.post('/user/authorization', {
        email: email,
        password: password
    });
    return user;
}

export async function logoutUserAsync() {
    await axios.post('/user/logout');
}