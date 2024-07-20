import axios from 'axios'

axios.defaults.withCredentials = true

const serverApi = axios.create({
  baseURL: 'https://localhost:7196',
  withCredentials: true
})

export default { serverApi }
