<script setup>
import { ref } from "vue";
import { registrationUserAsync } from "../services/userService.js";
import { useRouter } from "vue-router";

const router = useRouter();

const username = ref("");
const email = ref("");
const password = ref("");
const errorMessage = ref("");

async function onRegistrationAsync(event) {
  event.preventDefault();

  try {
    const user = await registrationUserAsync(
      username.value,
      email.value,
      password.value
    );

    router.push({ name: "Home" });
  } catch (exeption) {
    const {
      response: { data: exeptData },
    } = exeption;
    errorMessage.value = exeptData.message;
  }
}
</script>

<template>
  <div
    class="fixed w-1/3 top-1/4 left-1/2 -translate-x-1/2 border shadow-sm border-black px-5 py-6 rounded-2xl"
  >
    <h3 class="text-center select-none text-2xl border-b border-b-black pb-3">
      Форма регистрации
    </h3>

    <form class="mt-5">
      <div class="flex flex-col gap-2">
        <p
          v-if="errorMessage"
          class="text-center font-bold bg-red-500 py-2 rounded-md select-none cursor-pointer transition hover:bg-red-600"
          @click="() => (errorMessage = '')"
        >
          {{ errorMessage }}
        </p>
        <input
          class="border border-black py-2 px-4 outline-none rounded-md placeholder:italic"
          type="text"
          placeholder="Введите имя пользователя..."
          v-model="username"
        />
        <input
          class="border border-black py-2 px-4 outline-none rounded-md placeholder:italic"
          type="email"
          placeholder="Введите email..."
          v-model="email"
        />
        <input
          class="border border-black py-2 px-4 outline-none rounded-md placeholder:italic"
          type="password"
          placeholder="Введите пароль..."
          autocomplete="on"
          v-model="password"
        />
      </div>

      <input
        class="mt-5 cursor-pointer border py-2 px-4 rounded-md text-white bg-green-600 transition hover:bg-green-700"
        type="button"
        value="Зарегистрироваться"
        @click="onRegistrationAsync"
      />
    </form>
  </div>
</template>