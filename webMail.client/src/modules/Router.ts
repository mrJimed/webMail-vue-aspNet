import { createWebHistory, createRouter, type RouteLocation } from 'vue-router'
import Home from '../pages/Home.vue'
import Login from '../pages/Login.vue'
import Registration from '../pages/Registration.vue'
import NotFound from '../pages/NotFound.vue'
import { useUserStore } from './Store'

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/login', name: 'Login', component: Login },
  { path: '/registration', name: 'Registration', component: Registration },
  { path: '/404', name: 'NotFound', component: NotFound },
  { path: '/:catchAll(.*)', redirect: { name: 'NotFound' } }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach(async (to: RouteLocation) => {
  const userStore = useUserStore()
  const loginRegArr = ['Login', 'Registration']
  const toName = to.name === null || to.name === undefined ? '' : to.name.toString()

  if (!userStore.isAuthorized && !loginRegArr.includes(toName)) {
    return { name: 'Login' }
  } else if (userStore.isAuthorized && loginRegArr.includes(toName)) {
    return { name: 'NotFound' }
  }
})

export default router
