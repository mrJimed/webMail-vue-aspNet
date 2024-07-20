import './assets/main.css'

import Router from './modules/Router'

import { createApp } from 'vue'
import App from './App.vue'
import { createPinia } from 'pinia'

const app = createApp(App)
app.use(Router)
app.use(createPinia())
app.mount('#app')
