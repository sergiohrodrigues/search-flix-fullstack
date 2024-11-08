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
  <section v-else class="text-center">
    <h2 class="text-2xl mt-2">Nenhum filme encontrado</h2>
    <Button @click="router.back" class="mt-2">Voltar</Button>
  </section>
</template>

<script setup lang="ts">
import { useRoute, useRouter } from "vue-router";
import { Card, CardContent } from "../components/ui/card";
import { computed, h, onMounted, ref } from "vue";
import ToastAction from "../components/ui/toast/ToastAction.vue";
import { useToast } from "../components/ui/toast";
import { Button } from "../components/ui/button";

const route = useRoute();
const router = useRouter();
const { toast } = useToast();

const films = ref([]);
// const categoriasApi = ref([]);

onMounted(() => {
  fetch("https://localhost:7181/api/Filme/ListarFilmes")
    .then((response) => response.json())
    .then((data) => {
      films.value = data.dados;
    })
    .catch((error) => {
      console.error("Erro ao buscar filmes:", error);
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
  // fetch("https://localhost:7181/api/Filme/buscarCategorias")
  //   .then((response) => response.json())
  //   .then((data) => {
  //     categoriasApi.value = data;
  //   })
  //   .catch((error) => {
  //     console.error("Erro ao buscar filmes:", error);
  //   });
});

// let categorias = computed(() => {
//   return categoriasApi.value.map((item) => item);
// });

// console.log(categorias.value);

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