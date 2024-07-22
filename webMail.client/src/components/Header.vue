<script lang="ts" setup>
import { computed } from 'vue'
import { useUserStore } from '../modules/Store'
import UserService from '../services/UserService'
import { useRouter } from 'vue-router';

const userStore = useUserStore()
const router = useRouter()

const user = computed(() => userStore.user)
const isAuthorized = computed(() => userStore.isAuthorized)

async function logoutAsync() {
  await UserService.logoutUserAsync()
  userStore.logout()
  router.push({ name: 'Login' })
}
</script>

<template>
  <header class="bg-green-500 py-2 select-none">
    <div class="w-11/12 mx-auto flex justify-between">
      <RouterLink :to="{ name: 'Home' }">
        <h1 class="font-bold text-xl">WebMail</h1>
      </RouterLink>

      <nav>
        <div v-if="isAuthorized">
          <div>Username: {{ user }}</div>
          <button @click="() => logoutAsync()">Выход</button>
        </div>
        <RouterLink v-else :to="{ name: 'Login' }">Вход</RouterLink>
      </nav>
    </div>
  </header>
</template>
