<template>
  <section>
    <h2 class="text-2xl text-center mt-2">Todos os Filmes</h2>
    <div class="flex flex-wrap gap-2 mt-4 p-3">
      <Card v-for="film in filmes" :key="film.id" class="hover:cursor-pointer">
        <CardContent>
          <span class="text-2xl font-semibold">{{ film.name }}</span>
        </CardContent>
      </Card>
    </div>
    <h2 v-if="!filmes.length" class="text-2xl text-center">
      Nenhum filme encontrado
    </h2>
  </section>
</template>

<script setup lang="ts">
import { useRoute } from "vue-router";
import { Card, CardContent } from "../components/ui/card";
import { computed } from "vue";

const route = useRoute();

const films = [
  {
    id: 1,
    name: "filme 1",
  },
  {
    id: 2,
    name: "filme 2",
  },
  {
    id: 3,
    name: "filme 3",
  },
  {
    id: 4,
    name: "filme 4",
  },
  {
    id: 5,
    name: "filme 5",
  },
];

const filmes = computed(() => {
  if (route.params.search) {
    return films.filter((film) =>
      film.name.toUpperCase().includes(route.params.search.toUpperCase())
    );
  } else {
    return films;
  }
});
console.log(filmes.value);
console.log(route.params.search);
</script>

<style scoped>
</style>