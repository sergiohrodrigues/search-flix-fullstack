<template>
  <section v-if="filmsFavoritesAndFiltered.length > 0">
    <h2 class="text-2xl text-center mt-2">Filmes Favoritos</h2>
    <div class="flex flex-wrap gap-2 mt-4 p-3 md:justify-center">
      <Card
        v-for="film in filmsFavoritesAndFiltered"
        :key="film.id"
        class="hover:cursor-pointer"
      >
        <CardContent
          class="w-[130px] h-[150px] p-0"
          @click="router.push(`/movie/${film.titulo}`)"
        >
          <img
            :src="`/images/film${film.id}.jpg`"
            :alt="film.titulo"
            class="w-full h-full"
          />
        </CardContent>
      </Card>
    </div>
  </section>
  <section v-else>
    <h2 class="text-2xl text-center mt-2">Nenhum filme favoritado</h2>
  </section>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
import { Card, CardContent } from "../components/ui/card";
import { computed, h, onMounted, ref, watch } from "vue";
import IFilme from "../interfaces/Filme";
import ToastAction from "../components/ui/toast/ToastAction.vue";
import { useToast } from "../components/ui/toast";

const router = useRouter();
const { toast } = useToast();

const filmsStorage = JSON.parse(sessionStorage.getItem("favorites") || "[]");

const filmsApi = ref<IFilme[]>([]);

onMounted(() => {
  fetch("https://localhost:7181/api/Filme/ListarFilmes")
    .then((response) => response.json())
    .then((data) => {
      filmsApi.value = data.dados;
    })
    .catch((error) => {
      filmsApi.value = [];
      toast({
        title: "Dados não obtidos",
        description: "Conect-se a API para obter os filmes",
        variant: "destructive",
        action: h(
          ToastAction,
          {
            altText: "Close",
          },
          {
            default: () => "Close",
          }
        ),
      });
    });
});

const filmsFavorites = ref<IFilme[]>([]);

watch(
  filmsApi,
  (newValue) => {
    if (newValue.length > 0) {
      filmsFavorites.value = newValue.filter((film) =>
        filmsStorage.includes(film.titulo)
      );
    }
  },
  { immediate: true }
);

const filmsFavoritesAndFiltered = computed(() => filmsFavorites.value);
</script>