import { defineStore } from 'pinia'
import { computed, ref, type ComputedRef, type Ref } from 'vue'

export const useUserStore = defineStore('user', () => {
  const user: Ref<string | null> = ref(sessionStorage.getItem('user'))

  const isAuthorized: ComputedRef<boolean> = computed(() => user.value !== null)

  function login(username: string) {
    user.value = username
    sessionStorage.setItem('user', username)
  }

  function logout() {
    user.value = null
    sessionStorage.removeItem('user')
  }

  return { user, logout, login, isAuthorized }
})
