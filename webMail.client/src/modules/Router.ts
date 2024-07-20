import { createWebHistory, createRouter } from 'vue-router'
import Home from '../pages/Home.vue'
import Login from '../pages/Login.vue'

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/login', name: 'Login', component: Login }
]

export default createRouter({
  history: createWebHistory(),
  routes
})
