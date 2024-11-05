<template>
  <section v-if="filmsFavorites.length > 0">
    <h2 class="text-2xl text-center mt-2">Filmes Favoritos</h2>
    <div class="flex flex-wrap gap-2 mt-4 p-3 md:justify-center">
      <Card
        v-for="film in filmsFavorites"
        :key="film.id"
        class="hover:cursor-pointer"
      >
        <CardContent
          class="w-[130px] h-[150px] p-0"
          @click="router.push(`/movie/${film.titulo}`)"
        >
          <img src="" :alt="film.titulo" class="w-full h-full" />
          <!-- <span class="text-2xl font-semibold">{{ film.titulo }}</span> -->
        </CardContent>
      </Card>
    </div>
  </section>
  <section v-else>
    <h2>Nenhum filme favoritado</h2>
  </section>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
import films from "../filmes.json";
import { Card, CardContent } from "../components/ui/card";

const router = useRouter();

const filmsStorage = JSON.parse(sessionStorage.getItem("favorites") || "[]");

const filmsFavorites = filmsStorage.map((item) => {
  return films.find((film) => film.titulo == item);
});
</script>