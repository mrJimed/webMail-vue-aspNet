<script setup>
import Header from "./components/Header.vue";
</script>

<template>
    <Header></Header>
    
    <div class="mt-10">
        <router-view></router-view>
    </div>
</template>