<script lang="ts" setup>
import type UserLoginData from '../schemas/UserLoginData'
import UserService from '../services/UserService'
import InfoPopUp from '../components/InfoPopUp.vue'
import { reactive, ref } from 'vue'
import InfoPopUpType from '../enums/InfoPopUpType'
import { useUserStore } from '../modules/Store'
import { useRouter } from 'vue-router'

const userStore = useUserStore()
const router = useRouter()

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

function getErrorMessage(data: any): string {
  if (data.errors !== undefined && data.errors !== null) {
    const errors = data.errors
    return Object.getOwnPropertyNames(errors)
      .map((errorKey, index) => `${index + 1}) ${errors[errorKey].join(' ')}`)
      .join(' ')
  }
  return data
}

async function loginAsync() {
  try {
    const user = await UserService.loginUserAsync(userLoginData)
    userStore.login(user)
    router.push({ name: 'Home' })
  } catch (e) {
    console.log(e)
    const {
      response: { data }
    } = e
    showPopUp('Ошибка', getErrorMessage(data))
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

      <div class="flex items-center justify-between">
        <input
          class="cursor-pointer bg-black text-white rounded-md px-2 py-1"
          type="submit"
          value="Войти"
        />

        <RouterLink :to="{ name: 'Registration' }" class="underline">Нет аккаунта?</RouterLink>
      </div>
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
