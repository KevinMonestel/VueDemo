import 'bootstrap/dist/css/bootstrap.css';
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import Vuex from 'vuex';
import store from './store';

createApp(App).
    use(router).
    use(Vuex).
    use(store).
    mount('#app');