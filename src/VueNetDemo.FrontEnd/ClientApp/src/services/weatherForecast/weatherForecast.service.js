import { Request } from '@/axios/API-services/http-main.service';

class WeatherForecastService {
    async getWeatherForecasts() {
        let response = null;

        response = await Request.get('/weatherforecast/Get');

        return response.data;
    }
}

export default new WeatherForecastService();