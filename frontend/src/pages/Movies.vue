<template>
  <section v-if="filmes.length > 0">
    <div class="flex flex-wrap gap-2 mt-4 p-3 md:justify-center">
      <Card v-for="film in filmes" :key="film.id" class="hover:cursor-pointer">
        <CardContent
          class="w-[130px] h-[150px] p-0"
          @click="router.push(`/movie/${film.titulo}`)"
        >
          <img
            :src="`/images/film${film.id}.jpg`"
            :alt="film.titulo"
            class="w-full h-full"
          />
          <!-- <span class="text-2xl font-semibold">{{ film.titulo }}</span> -->
        </CardContent>
      </Card>
    </div>
  </section>
  <h2 class="text-2xl text-center mt-2" v-else>Nenhum filme encontrado</h2>
</template>

<script setup lang="ts">
import { useRoute, useRouter } from "vue-router";
import { Card, CardContent } from "../components/ui/card";
import { computed, onMounted, ref } from "vue";

const route = useRoute();
const router = useRouter();

const films = ref([]);
const categoriasApi = ref([]);

onMounted(() => {
  fetch("https://localhost:7181/api/Filme/ListarFilmes")
    .then((response) => response.json())
    .then((data) => {
      films.value = data.dados;
    })
    .catch((error) => {
      console.error("Erro ao buscar filmes:", error);
    });
  fetch("https://localhost:7181/api/Filme/buscarCategorias")
    .then((response) => response.json())
    .then((data) => {
      categoriasApi.value = data;
    })
    .catch((error) => {
      console.error("Erro ao buscar filmes:", error);
    });
});

let categorias = computed(() => {
  return categoriasApi.value.map((item) => item);
});

console.log(categorias.value);

const filmes = computed(() => {
  if (route.params.search) {
    return films.value.filter((film) =>
      film.titulo
        .normalize("NFD") // Separa caracteres de base e diacríticos
        .replace(/[\u0300-\u036f]/g, "") // Remove diacríticos
        .toLowerCase() // Converte para minúsculas
        .includes(
          route.params.search
            .normalize("NFD") // Separa caracteres de base e diacríticos
            .replace(/[\u0300-\u036f]/g, "") // Remove diacríticos
            .toLowerCase() // Converte para minúsculas)
        )
    );
  } else {
    return films.value;
  }
});
</script>