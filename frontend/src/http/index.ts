import axios, { AxiosInstance } from 'axios';

const http: AxiosInstance = axios.create({
    baseURL: 'https://localhost:7181/api/',
    headers: {'Content-type': 'application/json'}
  });

http.interceptors.request.use(
    function (config) {
      // Do something before request is sent

      // const token = sessionStorage.getItem('token');

      // if (token) {
      //   const tokenCriptografado = useCriptografia().descriptografar(token);
      //   config.headers.Authorization = `Bearer ${tokenCriptografado}`;
      // }

      return config;
    },
    function (error) {
      // Do something with request error
      return Promise.reject(error);
    }
)

export default http;