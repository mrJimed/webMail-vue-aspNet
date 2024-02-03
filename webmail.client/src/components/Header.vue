<template>
  <header class="py-5 border-b border-b-slate-200 shadow-sm">
    <div class="flex justify-between w-5/6 mx-auto items-center">
      <router-link to="/">
        <h1 class="font-bold text-2xl italic">WebMail</h1>
      </router-link>

      <div class="flex gap-4">
        <router-link to="/registration">
          <button
            type="button"
            class="border border-black px-3 py-2 rounded-md transition hover:bg-black hover:text-white"
          >
            Регистрация
          </button>
        </router-link>

        <button
          type="button"
          class="border border-black px-3 py-2 rounded-md transition hover:bg-black hover:text-white"
        >
          Вход
        </button>
      </div>
    </div>
  </header>
</template>