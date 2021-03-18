import axios from 'axios';

class AccountService {
    async LoginUser(Login) {
        let response = null;

        response = await axios.post('/Account/Login', Login);

        return response.data;
    }
}

export default new AccountService();