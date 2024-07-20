import type SendMessageData from '../schemas/SendMessageData'
import ServerConfig from './ServerConfig'

async function sendMessageAsync(sendMessageData: SendMessageData): Promise<void> {
  await ServerConfig.serverApi.post('/mail/send', sendMessageData)
}

export default { sendMessageAsync }
