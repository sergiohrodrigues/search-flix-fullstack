<script setup lang="ts">
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