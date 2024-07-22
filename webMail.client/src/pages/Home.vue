<script lang="ts" setup>
import type SendMessageData from '../schemas/SendMessageData'
import InfoPopUp from '../components/InfoPopUp.vue'
import MailService from '../services/MailService'
import { reactive, ref } from 'vue'
import InfoPopUpType from '../enums/InfoPopUpType'

// info pop up data
const isInfoPopUpVisible = ref(false)
const infoPopUpSubject = ref('')
const infoPopUpText = ref('')
const infoPopUpType = ref(0)

// message data
const messageData: SendMessageData = reactive({
  subject: '',
  text: '',
  toEmail: ''
})

function getErrorMessage(data: any): string {
  if (data.errors !== undefined && data.errors !== null) {
    const errors = data.errors
    return Object.getOwnPropertyNames(errors)
      .map((errorKey, index) => `${index + 1}) ${errors[errorKey].join(' ')}`)
      .join(' ')
  }
  return data
}

async function sendMessageAsync(): Promise<void> {
  try {
    await MailService.sendMessageAsync(messageData)
    showPopUp('Успешно', 'Сообщение отправлено', InfoPopUpType.Success)
  } catch (e) {
    console.log(e)
    const {
      response: { data }
    } = e
    showPopUp('Ошибка', getErrorMessage(data), InfoPopUpType.Error)
  }
}

function showPopUp(subject: string, text: string, popUpType: number) {
  infoPopUpSubject.value = subject
  infoPopUpText.value = text
  infoPopUpType.value = popUpType
  isInfoPopUpVisible.value = true
}
</script>

<template>
  <form class="flex flex-col border border-slate-300" @submit.prevent="sendMessageAsync">
    <div class="flex flex-col">
      <label for="toEmail">Email адресата:</label>
      <input
        id="toEmail"
        type="email"
        placeholder="Введите email адресата."
        v-model="messageData.toEmail"
      />
    </div>

    <div class="flex flex-col">
      <label for="subject">Тема письма:</label>
      <input
        id="subject"
        type="text"
        placeholder="Введите тему письма."
        v-model="messageData.subject"
      />
    </div>

    <div class="flex flex-col">
      <label for="text">Текст сообщения:</label>
      <textarea
        id="text"
        type="text"
        placeholder="Введите текст письма."
        v-model="messageData.text"
      ></textarea>
    </div>

    <input type="submit" value="Отправить" />
  </form>

  <InfoPopUp
    v-if="isInfoPopUpVisible"
    v-model:isVisible="isInfoPopUpVisible"
    :subject="infoPopUpSubject"
    :text="infoPopUpText"
    :popUpType="infoPopUpType"
  ></InfoPopUp>
</template>
