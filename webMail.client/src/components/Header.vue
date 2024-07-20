<script lang="ts" setup>
import { computed } from 'vue'
import { useUserStore } from '../modules/Store'

const userStore = useUserStore()
const user = computed(() => userStore.user)
const isAuthorized = computed(() => userStore.isAuthorized)
</script>

<template>
  <header class="bg-green-500 py-2 select-none">
    <div class="w-11/12 mx-auto flex justify-between">
      <RouterLink :to="{ name: 'Home' }">
        <h1 class="font-bold text-xl">WebMail</h1>
      </RouterLink>

      <nav>
        <div v-if="isAuthorized" class="mr-5">Username: {{ user }}</div>
        <RouterLink v-else :to="{ name: 'Login' }">Вход</RouterLink>
      </nav>
    </div>
  </header>
</template>
