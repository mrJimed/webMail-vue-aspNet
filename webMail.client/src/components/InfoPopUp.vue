<script lang="ts" setup>
const isVisible = defineModel<boolean>('isVisible')
const props = defineProps({
  subject: String,
  text: String
})

setTimeout(closePopUp, 5000)

function closePopUp() {
  isVisible.value = false
}
</script>

<template>
  <div
    class="bg-blue-200 rounded-md fixed right-5 bottom-5 min-w-60 max-w-80 p-3 select-none shadow-md border border-black"
  >
    <div class="flex justify-between">
      <h4 class="font-bold text-lg">{{ subject }}</h4>
      <button @click="closePopUp">
        <i class="fa-solid fa-xmark"></i>
      </button>
    </div>
    <p>{{ text }}</p>
  </div>
</template>
