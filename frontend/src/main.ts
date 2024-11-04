import { createApp } from 'vue'
import './assets/index.css'
import App from './App.vue'
import roteador from './router'

createApp(App).use(roteador).mount('#app')
