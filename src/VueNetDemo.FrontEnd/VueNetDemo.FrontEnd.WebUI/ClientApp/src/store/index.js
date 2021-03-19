import { auth } from './auth.module';
import { createStore } from 'vuex'

// Create a new store instance.
const store = createStore({
    modules: {
        auth
    }
})
export default store;