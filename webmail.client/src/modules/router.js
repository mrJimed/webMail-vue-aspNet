import Home from '../pages/Home.vue'
import Registration from '../pages/Registration.vue'
import Authorization from '../pages/Authorization.vue'

import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/registration', name: 'Registration', component: Registration },
    { path: '/authorization', name: 'Authorization', component: Authorization }
];

export default createRouter({
    history: createWebHistory(),
    routes
});