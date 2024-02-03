import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'

import Home from './pages/Home.vue'
import Registration from './pages/Registration.vue'
import App from './App.vue'

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/registration', name: 'Registration', component: Registration }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount('#app');
