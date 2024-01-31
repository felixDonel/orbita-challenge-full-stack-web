import { createRouter, createWebHistory } from 'vue-router';
import ListStudent from '@/view/ListStudent.vue';
import EditStudent from '@/view/EditStudent.vue';
import CreateStudent from '@/view/CreateStudent.vue';

const routes = [
  { path: '/', component: ListStudent },
  { path: '/Aluno/Editar/:id', component: EditStudent },
  { path: '/Aluno/Cadastrar', component: CreateStudent },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;