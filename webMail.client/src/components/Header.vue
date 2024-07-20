<template>
  <header class="bg-green-500 py-2 select-none">
    <div class="w-11/12 mx-auto flex justify-between">
      <RouterLink :to="{ name: 'Home' }">
        <h1 class="font-bold text-xl">WebMail</h1>
      </RouterLink>

      <nav>
        <RouterLink :to="{ name: 'Login' }">Вход</RouterLink>
      </nav>
    </div>
  </header>
</template>
