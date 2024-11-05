<template>
  <section>
    <h2 class="text-2xl text-center mt-2">Todos os Filmes</h2>
    <div class="flex flex-wrap gap-2 mt-4 p-3 md:justify-center">
      <Card v-for="film in filmes" :key="film.id" class="hover:cursor-pointer">
        <CardContent
          class="w-[130px] h-[150px] p-0"
          @click="router.push(`/movie/${film.titulo}`)"
        >
          <img src="" :alt="film.titulo" class="w-full h-full" />
          <!-- <span class="text-2xl font-semibold">{{ film.titulo }}</span> -->
        </CardContent>
      </Card>
    </div>
    <h2 v-if="!filmes.length" class="text-2xl text-center">
      Nenhum filme encontrado
    </h2>
  </section>
</template>

<script setup lang="ts">
import { useRoute, useRouter } from "vue-router";
import { Card, CardContent } from "../components/ui/card";
import { computed } from "vue";
import films from "../filmes.json";

const route = useRoute();
const router = useRouter();

const filmes = computed(() => {
  if (route.params.search) {
    return films.filter((film) =>
      film.titulo.toUpperCase().includes(route.params.search.toUpperCase())
    );
  } else {
    return films;
  }
});
</script>

<style scoped>
</style>