<script setup lang="ts">
import { ref, watch } from "vue";
import { Button } from "./ui/button";
import {
  Sheet,
  SheetClose,
  SheetContent,
  SheetDescription,
  SheetFooter,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "./ui/sheet";
import { Menu } from "lucide-vue-next";

const user = ref(sessionStorage.getItem("user") || null);

watch(sessionStorage, (newValue, oldValue) => {
  if (sessionStorage.getItem("user")) {
    user.value = newValue.getItem("user");
  }
});
</script>

<template>
  <Sheet>
    <SheetTrigger as-child class="md:hidden">
      <Button variant="outline">
        <Menu />
      </Button>
    </SheetTrigger>
    <SheetContent>
      <SheetHeader>
        <SheetTitle>Menu</SheetTitle>
      </SheetHeader>
      <SheetDescription>
        <SheetClose as-child>
          <ul
            style="
              display: flex;
              flex-direction: column;
              align-items: center;
              justify-content: center;
              gap: 3rem;
              font-size: 1.5rem;
              height: 70vh;
            "
          >
            <router-link to="/">Início</router-link>
            <router-link to="/movies">Todos os filmes</router-link>
            <router-link to="/favorites">Favoritos</router-link>
            <router-link to="/login" v-if="!user">Entrar</router-link>
            <router-link to="" v-else>Minha conta</router-link>
          </ul>
        </SheetClose>
      </SheetDescription>
      <!-- <SheetFooter>
        <SheetClose as-child>
          <Button type="submit"> Save changes </Button>
        </SheetClose>
      </SheetFooter> -->
    </SheetContent>
  </Sheet>
</template>