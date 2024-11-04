import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router';
import LayoutPadrao from '../layout/LayoutPadrao.vue';
import Home from '../pages/Home.vue';
import Filmes from '../pages/Filmes.vue';
import Favorites from '../pages/Favorites.vue';

const rotas: RouteRecordRaw[] = [
  {
    path: '/',
    component: LayoutPadrao,
    children: [
      { path: '', name: '', component: Home },
      { path: 'movies', name: '', component: Filmes },
      { path: 'movies/:search', name: '', component: Filmes },
      { path: 'favorites', name: '', component: Favorites }
    ],
  },
];

const roteador = createRouter({
  history: createWebHashHistory(),
  routes: rotas,
});

export default roteador;
