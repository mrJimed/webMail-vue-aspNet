import axios from 'axios'
import type SendMessageData from '../schemas/SendMessageData'
import ServerConfig from './ServerConfig'

async function sendMessageAsync(sendMessageData: SendMessageData): Promise<void> {
  const SERVER_URL = `${ServerConfig.getServerUrl()}/mail/send`
  await axios.post(SERVER_URL, sendMessageData)
}

export default { sendMessageAsync }
