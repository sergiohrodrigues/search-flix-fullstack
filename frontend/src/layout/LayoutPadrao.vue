<template>
  <div>
    <Menu style="height: 7vh" />
    <router-view style="min-height: 89vh"></router-view>
    <!-- <Rodape style="height: 4vh" /> -->
  </div>
</template>

<script setup lang="ts">
import Menu from "../components/Menu.vue";
import Rodape from "../components/Rodape.vue";
</script>