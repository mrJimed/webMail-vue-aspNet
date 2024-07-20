<script lang="ts" setup>
import { reactive, ref } from 'vue'
import type UserRegData from '../schemas/UserRegData'
import UserService from '../services/UserService'
import InfoPopUp from '../components/InfoPopUp.vue'
import InfoPopUpType from '../enums/InfoPopUpType'
import { useUserStore } from '../modules/Store'

const userStore = useUserStore()

// info pop up data
const isInfoPopUpVisible = ref(false)
const infoPopUpSubject = ref('')
const infoPopUpText = ref('')
const infoPopUpType = ref(InfoPopUpType.Error)

// reg data
const userRegData: UserRegData = reactive({
  email: '',
  password: '',
  username: ''
})

async function registrationAsync() {
  try {
    const user = await UserService.registrationUserAsync(userRegData)
    userStore.login(user)
  } catch (e) {
    console.log(e)
    showPopUp('Ошибка', 'Во время регистрации произошла ошибка')
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
    <h2 class="text-center font-bold text-2xl mb-5 select-none">Форма регистрации</h2>
    <form @submit.prevent="() => registrationAsync()">
      <div class="flex flex-col mb-2">
        <label for="email" class="select-none mb-1 font-bold">Имя пользователя:</label>
        <input
          id="email"
          class="px-2 py-1 rounded-md outline-none"
          type="email"
          placeholder="Введите имя пользователя..."
          v-model="userRegData.username"
        />
      </div>

      <div class="flex flex-col mb-2">
        <label for="email" class="select-none mb-1 font-bold">Email:</label>
        <input
          id="email"
          class="px-2 py-1 rounded-md outline-none"
          type="email"
          placeholder="Введите email..."
          v-model="userRegData.email"
        />
      </div>

      <div class="flex flex-col mb-6">
        <label for="password" class="select-none mb-1 font-bold">Пароль:</label>
        <input
          id="password"
          class="px-2 py-1 rounded-md outline-none"
          type="password"
          placeholder="Введите пароль..."
          v-model="userRegData.password"
        />
      </div>

      <input
        class="cursor-pointer bg-black text-white rounded-md px-2 py-1"
        type="submit"
        value="Зарегистрироваться"
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
