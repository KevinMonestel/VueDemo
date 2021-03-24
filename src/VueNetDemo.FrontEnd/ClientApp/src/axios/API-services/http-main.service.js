import axios from 'axios';

export const Request = axios.create();

Request.interceptors.request.use(
  (config) => {
    let token = localStorage.getItem('user');

    if (token) {
      config.headers['Authorization'] = `Bearer ${ JSON.parse(localStorage.getItem('user')).token }`;
    }

    config.baseURL = `http://localhost:38944/api/`;

    return config;
  }, 

  (error) => {
    return Promise.reject(error);
  }
);