import { Request } from '@/axios/API-services/http-main.service';
import authHeader from './auth-header';

const API_URL = '/test/';

class UserService {
  getPublicContent() {
    return Request.get(API_URL + 'all');
  }

  getAdminBoard() {
    return Request.get(API_URL + 'admin', { headers: authHeader() });
  }
}

export default new UserService();