<template>
  <section class="p-4" v-if="film.length > 0">
    <div class="text-center">
      <h2 class="text-2xl">{{ film[0].titulo }}</h2>
      <Badge class="mt-2">{{ film[0].categoria }}</Badge>
      <Heart
        color="red"
        :fill="favorite ? 'red' : 'none'"
        class="mt-2 my-0 mx-auto lg:cursor-pointer"
        @click="adicionarItens(film[0].titulo)"
      />
      <p class="mt-2">{{ film[0].descricao }}</p>
    </div>
    <iframe
      src="https://www.youtube.com/embed/U4lz8MN6MQA"
      title="DOOM CROSSING: Eternal Horizons ■ Music Video feat. Natalia Natchan aka PiNKII"
      frameborder="0"
      allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
      referrerpolicy="strict-origin-when-cross-origin"
      allowfullscreen
      class="mt-8 w-full h-[300px] md:my-8 md:mx-auto md:max-w-[1024px] md:h-[400px] lg:h-[500px]"
    ></iframe>
  </section>
  <section v-else class="text-center">
    <h2 class="text-2xl mt-2">Nenhum filme encontrado</h2>
    <Button @click="router.back" class="mt-4">Voltar</Button>
  </section>
</template>

<script setup lang="ts">
import { useRoute, useRouter } from "vue-router";
import Badge from "../components/ui/badge/Badge.vue";
import Button from "../components/ui/button/Button.vue";
import { Heart, Star } from "lucide-vue-next";
import { onMounted, ref } from "vue";
import { toast } from "vue-sonner";

const route = useRoute();
const router = useRouter();

const favorite = ref(false);

const films = ref([]);

onMounted(() => {
  carregarDoSessionStorage();
  fetch("https://localhost:7181/api/Filme/ListarFilmes")
    .then((response) => response.json())
    .then((data) => {
      films.value = data.dados;
    })
    .catch((error) => {
      films.value = [];
      console.error("Erro ao buscar filmes:", error);
    });
});

const film = films.value.filter((film) => film.titulo === route.params.movie);

console.log(film)

function adicionarAoSessionStorage(item: string): void {
  const arrayExistente = JSON.parse(
    sessionStorage.getItem("favorites") || "[]"
  );

  arrayExistente.push(item);

  sessionStorage.setItem("favorites", JSON.stringify(arrayExistente));

  toast.success("Filme adicionado aos favoritos", {
    action: {
      label: "Close",
      onClick: () => console.log("Undo"),
    },
    position: "top-right",
    style: {
      background: "#6ee7b7",
    },
  });
}

function removerSessionStorage(item: string): void {
  const arrayExistente = JSON.parse(
    sessionStorage.getItem("favorites") || "[]"
  );

  let indexArray = arrayExistente.indexOf(item);
  arrayExistente.splice(indexArray, 1);

  sessionStorage.setItem("favorites", JSON.stringify(arrayExistente));
}

const filmsFavorites = ref<string[]>([]);

if (sessionStorage.getItem("favorites")) {
  filmsFavorites.value = JSON.parse(
    sessionStorage.getItem("favorites") || "[]"
  );

  if (filmsFavorites.value.includes(film[0].titulo)) {
    favorite.value = true;
  }
}

function carregarDoSessionStorage(): void {
  filmsFavorites.value = JSON.parse(
    sessionStorage.getItem("favorites") || "[]"
  );
}

function removerLocalStorage(item: string): void {
  const itemARemover = filmsFavorites.value.filter((i) => i == item);
  removerSessionStorage(itemARemover.toString());
  toast.success("Filme removido dos favoritos", {
    action: {
      label: "Close",
      onClick: () => console.log("Undo"),
    },
    position: "top-right",
    style: { background: "#fda4af" },
  });
}

function adicionarItens(item: string): void {
  favorite.value = !favorite.value;
  if (favorite.value) {
    adicionarAoSessionStorage(item);
    carregarDoSessionStorage();
  } else {
    removerLocalStorage(item);
    carregarDoSessionStorage();
  }
}
</script>