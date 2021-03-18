import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/home/Home.vue";
import Counter from "@/views/counter/Counter.vue";
import FetchData from "@/views/fetchData/FetchData.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;