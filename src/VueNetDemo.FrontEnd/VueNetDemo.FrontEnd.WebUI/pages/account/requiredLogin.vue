<template>
    <div class="w-full container mx-auto md:w-9/12">
         <p>Fine</p>
         <p><button class="p-1 bg-blue-500 text-white" v-on:click="makeCall">Make call to API</button></p>
         <p v-if="states.length === 0">Press 'Make call to API'</p>
         <ul>
             <li v-for="state in states" v-bind:key="state.date">{{state.summary}} - {{state.date}} - {{state.temperatureC}}C - {{state.temperatureF}}F </li>
         </ul>
    </div>
</template>

<script>
  export default {
    name: 'requiredLogin',

    data(){
        return {
            states: []
        }
    },

    methods: {
        async makeCall(){
            let result = await this.$axios.get('/api/WeatherForecast/Get');

            if(result.status == 200){
                this.states = result.data;
            }
        }
    }
  };
</script>

<style></style>
