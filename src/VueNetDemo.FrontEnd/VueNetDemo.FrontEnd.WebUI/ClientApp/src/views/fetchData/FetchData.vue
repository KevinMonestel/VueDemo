<template>
    <h1 id="tableLabel">Weather forecast</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!forecasts"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="forecasts">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="forecast of forecasts" v-bind:key="forecast">
                <td>{{ forecast.date }}</td>
                <td>{{ forecast.temperatureC }}</td>
                <td>{{ forecast.temperatureF }}</td>
                <td>{{ forecast.summary }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import WeatherForecastService from '@/services/weatherForecastService'

    export default {
        name: "FetchData",
        data() {
            return {
                forecasts: []
            }
        },
        methods: {
            async getWeatherForecasts() {
                let data = await WeatherForecastService.getWeatherForecasts();
                this.forecasts = data;  
            }
        },
        mounted() {
            this.getWeatherForecasts();
        }
    }
</script>