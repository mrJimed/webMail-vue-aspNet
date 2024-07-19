<script lang="ts" setup>
import type SendMessageData from '../schemas/SendMessageData'
import InfoPopUp from '../components/InfoPopUp.vue'
import MailService from '../services/MailService'
import { reactive, ref } from 'vue'

// info pop up data
const isInfoPopUpVisible = ref(false)
const infoPopUpSubject = ref('')
const infoPopUpText = ref('')

// message data
const messageData: SendMessageData = reactive({
  subject: '',
  text: '',
  toEmail: ''
})

async function sendMessageAsync(): Promise<void> {
  try {
    await MailService.sendMessageAsync(messageData)
  } catch (e) {
    console.log(e)
    showPopUp('Ошибка','При отправке сообщения произошла ошибка')
  }
}

function showPopUp(subject: string, text: string) {
  infoPopUpSubject.value = subject
  infoPopUpText.value = text
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
      <label for="toEmail">Тема письма:</label>
      <input type="text" placeholder="Введите тему письма." v-model="messageData.subject" />
    </div>

    <div class="flex flex-col">
      <label for="toEmail">Текст сообщения:</label>
      <textarea
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
  ></InfoPopUp>
</template>