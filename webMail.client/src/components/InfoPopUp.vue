<script lang="ts" setup>
import InfoPopUpType from '@/enums/InfoPopUpType'

const isVisible = defineModel<boolean>('isVisible')
const props = defineProps({
  subject: String,
  text: String,
  popUpType: Number
})

setTimeout(closePopUp, 5000)

function closePopUp() {
  isVisible.value = false
}

function popUpStyle() {
  switch (props.popUpType) {
    case InfoPopUpType.Success:
      return 'bg-green-300'
    case InfoPopUpType.Error:
      return 'bg-red-300'
  }
}
</script>

<template>
  <div
    class="rounded-md fixed right-5 bottom-5 min-w-60 max-w-80 p-3 select-none shadow-md border border-black"
    :class="popUpStyle()"
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
