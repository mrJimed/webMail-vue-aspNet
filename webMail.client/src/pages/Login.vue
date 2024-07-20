<script lang="ts" setup>
import type UserLoginData from '../schemas/UserLoginData'
import UserService from '../services/UserService'
import InfoPopUp from '../components/InfoPopUp.vue'
import { reactive, ref } from 'vue'
import InfoPopUpType from '../enums/InfoPopUpType'

// info pop up data
const isInfoPopUpVisible = ref(false)
const infoPopUpSubject = ref('')
const infoPopUpText = ref('')
const infoPopUpType = ref(InfoPopUpType.Error)

// login data
const userLoginData: UserLoginData = reactive({
  email: '',
  password: ''
})

async function loginAsync() {
  try {
    await UserService.loginUserAsync(userLoginData)
  } catch (e) {
    console.log(e)
    showPopUp('Ошибка', 'Во время авторизации произошла ошибка')
  }
}

function showPopUp(subject: string, text: string) {
  infoPopUpSubject.value = subject
  infoPopUpText.value = text
  isInfoPopUpVisible.value = true
}
</script>

<template>
  <div class="bg-green-200 rounded-md p-6 w-1/4 absolute top-40 left-1/2 -translate-x-1/2">
    <h2 class="text-center font-bold text-2xl mb-5 select-none">Форма авторизации</h2>
    <form @submit.prevent="() => loginAsync()">
      <div class="flex flex-col mb-2">
        <label for="email" class="select-none mb-1 font-bold">Ваш email:</label>
        <input
          id="email"
          class="px-2 py-1 rounded-md outline-none"
          type="email"
          placeholder="Введите ваш email..."
          v-model="userLoginData.email"
        />
      </div>

      <div class="flex flex-col mb-6">
        <label for="password" class="select-none mb-1 font-bold">Ваш пароль:</label>
        <input
          id="password"
          class="px-2 py-1 rounded-md outline-none"
          type="password"
          placeholder="Введите ваш пароль..."
          v-model="userLoginData.password"
        />
      </div>

      <input
        class="cursor-pointer bg-black text-white rounded-md px-2 py-1"
        type="submit"
        value="Войти"
      />
    </form>
  </div>

  <InfoPopUp
    v-if="isInfoPopUpVisible"
    v-model:isVisible="isInfoPopUpVisible"
    :subject="infoPopUpSubject"
    :text="infoPopUpText"
    :popUpType="infoPopUpType"
  ></InfoPopUp>
</template>
