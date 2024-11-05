import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router';
import LayoutPadrao from '../layout/LayoutPadrao.vue';
import Home from '../pages/Home.vue';
import Movies from '../pages/Movies.vue';
import Favorites from '../pages/Favorites.vue';
import DescriptionMovie from '../pages/DescriptionMovie.vue';

const rotas: RouteRecordRaw[] = [
  {
    path: '/',
    component: LayoutPadrao,
    children: [
      { path: '', name: 'home', component: Home },
      { path: 'movies', name: 'movies', component: Movies },
      { path: 'movies/:search', name: 'movieSearch', component: Movies },
      { path: 'favorites', name: 'favorites', component: Favorites },
      { path: 'movie/:movie', name: 'descriptionMovie', component: DescriptionMovie }
    ],
  },
];

const roteador = createRouter({
  history: createWebHashHistory(),
  routes: rotas,
});

export default roteador;
