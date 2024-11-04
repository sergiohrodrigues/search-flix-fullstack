<template>
  <main>
    <section>
      <img
        src="../assets/images/background.jpg"
        alt="Filmes lançamentos"
        class="max-h-[400px] w-full object-center object-center"
      />
    </section>

    <section class="p-4 flex items-center gap-2">
      <div class="relative w-full max-w-sm items-center w-[200px]">
        <Input
          id="search"
          type="text"
          placeholder="Pesquise um filme"
          class="pl-10"
          v-model="searchFilm"
        />
        <span
          class="absolute start-0 inset-y-0 flex items-center justify-center px-2"
        >
          <Search class="size-6 text-muted-foreground" />
        </span>
      </div>
      <Button @click="buscarFilme">Pesquisar</Button>
    </section>

    <section class="text-center mt-4 mb-2">
      <h2 class="text-2xl">Filmes Populares</h2>
      <Carousel
        class="relative max-w-sm my-0 mx-auto w-[72%] md:w-full"
        :opts="{
          align: 'start',
        }"
      >
        <CarouselContent class="-ml-1">
          <CarouselItem
            v-for="(_, index) in 5"
            :key="index"
            class="pl-1 lg:basis-1/3"
          >
            <div class="p-1">
              <Card @click="$router.push(`/1`)" class="hover:cursor-pointer">
                <CardContent
                  class="flex aspect-square items-center justify-center p-6"
                >
                  <span class="text-2xl font-semibold">{{ index + 1 }}</span>
                </CardContent>
              </Card>
            </div>
          </CarouselItem>
        </CarouselContent>
        <CarouselPrevious />
        <CarouselNext />
      </Carousel>
    </section>
  </main>
</template>

<script setup lang="ts">
import { Card, CardContent } from "@/components/ui/card";
import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from "@/components/ui/carousel";
import { Input } from "@/components/ui/input";
import { Search } from "lucide-vue-next";
import Button from "../components/ui/button/Button.vue";
import { ref } from "vue";
import { useRouter } from "vue-router";

const searchFilm = ref("");
const router = useRouter();

const buscarFilme = () => {
  router.push(`/filmes/${searchFilm.value}`);
  searchFilm.value = "";
};
</script>