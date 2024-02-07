<script setup>
import { computed } from "vue";
import { useStore } from "vuex";

import { logoutUserAsync } from "../services/userService.js";

const store = useStore();
const user = computed(() => store.getters.user);

async function onLogoutClick() {
  await logoutUserAsync();
  store.dispatch("logout");
}
</script>

<template>
  <header class="py-5 border-b border-b-slate-200 shadow-sm">
    <div class="flex justify-between w-5/6 mx-auto items-center">
      <router-link to="/">
        <h1 class="font-bold text-2xl italic">WebMail</h1>
      </router-link>

      <div>
        <div class="flex gap-4 items-center" v-if="user">
          <h3
            class="select-none text-lg bg-black text-white px-8 py-2 rounded-full"
          >
            {{ user }}
          </h3>
          <button
            class="border border-black px-3 py-2 rounded-md transition hover:bg-black hover:text-white"
            type="button"
            @click="onLogoutClick"
          >
            Выход
          </button>
        </div>

        <div class="flex gap-4" v-else>
          <router-link to="/registration">
            <button
              type="button"
              class="border border-black px-3 py-2 rounded-md transition hover:bg-black hover:text-white"
            >
              Регистрация
            </button>
          </router-link>
          <router-link to="/authorization">
            <button
              type="button"
              class="border border-black px-3 py-2 rounded-md transition hover:bg-black hover:text-white"
            >
              Вход
            </button>
          </router-link>
        </div>
      </div>
    </div>
  </header>
</template>