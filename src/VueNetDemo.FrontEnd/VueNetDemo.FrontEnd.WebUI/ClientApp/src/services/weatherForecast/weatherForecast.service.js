import axios from 'axios';

class WeatherForecastService {
    async getWeatherForecasts() {
        let response = null;

        response = await axios.get('/weatherforecast/Get');

        return response.data;
    }
}

export default new WeatherForecastService();