<script setup lang="ts">
import { onMounted, ref } from "vue";
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuList,
  NavigationMenuTrigger,
  navigationMenuTriggerStyle,
} from "../components/ui/navigation-menu";
import { Button } from "./ui/button";

const user = ref<string | null>(null);

onMounted(() => {
  if (sessionStorage.getItem("user")) {
    user.value = sessionStorage.getItem("user");
  }
});
</script>

<template>
  <NavigationMenu class="hidden md:flex">
    <NavigationMenuList>
      <NavigationMenuItem>
        <RouterLink
          to="/"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Início
        </RouterLink>
      </NavigationMenuItem>
      <NavigationMenuItem>
        <RouterLink
          to="/movies"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Todos os Filmes
        </RouterLink>
      </NavigationMenuItem>
      <NavigationMenuItem>
        <RouterLink
          to="/favorites"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Favoritos
        </RouterLink>
      </NavigationMenuItem>

      <div>
        <NavigationMenuItem v-if="!user">
          <RouterLink
            to="/login"
            :class="navigationMenuTriggerStyle()"
            class="hover:cursor-pointer"
          >
            Entrar
          </RouterLink>
        </NavigationMenuItem>
        <NavigationMenuItem v-else>
          <RouterLink
            to="/login"
            :class="navigationMenuTriggerStyle()"
            class="hover:cursor-pointer"
          >
            Sair
          </RouterLink>
        </NavigationMenuItem>
      </div>
    </NavigationMenuList>
  </NavigationMenu>
</template>