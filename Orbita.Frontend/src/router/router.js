import { createRouter, createWebHistory } from 'vue-router';
import ListStudent from '@/view/ListStudent.vue';

const routes = [
  { path: '/', component: ListStudent },
  // ...outras rotas
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;