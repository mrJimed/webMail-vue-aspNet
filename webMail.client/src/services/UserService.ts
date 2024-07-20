import type UserLoginData from '../schemas/UserLoginData'
import ServerConfig from './ServerConfig'
import type UserRegData from '@/schemas/UserRegData'

async function loginUserAsync(userData: UserLoginData): Promise<string> {
  const { data } = await ServerConfig.serverApi.post('/user/login', userData)
  return data
}

async function registrationUserAsync(userData: UserRegData): Promise<string> {
  const { data } = await ServerConfig.serverApi.post('/user/registration', userData)
  return data
}

async function logoutUserAsync(): Promise<void> {
  await ServerConfig.serverApi.post('/user/logout')
}

export default { loginUserAsync, registrationUserAsync, logoutUserAsync }
