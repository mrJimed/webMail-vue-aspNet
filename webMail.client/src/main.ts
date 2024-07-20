import './assets/main.css'

import Router from './modules/Router'

import { createApp } from 'vue'
import App from './App.vue'

const app = createApp(App)
app.use(Router)
app.mount('#app')
