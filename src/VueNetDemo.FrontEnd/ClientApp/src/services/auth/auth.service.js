import { Request } from '@/axios/API-services/http-main.service';

const API_URL = '/Account/';

class AuthService {
    login(user) {
        return Request
            .post(API_URL + 'Login', {
                username: user.username,
                password: user.password
            })
            .then(response => {
                if (response.data.token) {
                    localStorage.setItem('user', JSON.stringify(response.data));
                }

                return response.data;
            })
            .catch(error => {
                return error.response.data;
            });
    }

    logout() {
        localStorage.removeItem('user');
    }
}

export default new AuthService();