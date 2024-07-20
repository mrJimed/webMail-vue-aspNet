import axios from 'axios'
import type UserLoginData from '../schemas/UserLoginData'
import ServerConfig from './ServerConfig'

async function loginUserAsync(userData: UserLoginData): Promise<string> {
  const SERVER_URL = `${ServerConfig.getServerUrl()}/user/login`
  const { data } = await axios.post(SERVER_URL, userData)
  return data
}

export default { loginUserAsync }
