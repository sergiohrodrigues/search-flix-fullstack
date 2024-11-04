<template>
  <header class="p-4 flex items-center justify-between gap-2 md:justify-around">
    <span>Search Flix</span>
    <MenuMobile />
    <MenuDesktop />
  </header>
</template>

<script setup lang="ts">
import MenuDesktop from "./MenuDesktop.vue";
import MenuMobile from "./MenuMobile.vue";
</script>

<style scoped>
</style>