<template>
    <v-container>
      <NavegationbarComponent title="Alunos" />
  
      <v-data-table
        :headers="headers"
        :items="students"
        :search="search"
        :sort-by="['RA']"
      >
        <template v-slot:top>
          <v-toolbar flat>
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Pesquisar"
              single-line
              hide-details
            ></v-text-field>
            <v-btn color="primary" dark @click="redirectCadastroAluno">
              Novo Aluno
            </v-btn>
          </v-toolbar>
        </template>
        <template v-slot:item.actions="{ item }">
          <v-icon size="small" class="me-2" @click="editAluno(item)">
            mdi-pencil
          </v-icon>
          <v-icon size="small" @click="confirmDeleteAluno(item)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
    </v-container>
  </template>
  
  <script>
  import axios from 'axios';
  
  import NavegationbarComponent from '../components/NavegationbarComponent.vue';
  
  export default {
    data() {
      return {
        search: '',
        headers: [
          { text: 'RA', value: 'ra' },
          { text: 'Nome', value: 'name' },
          { text: 'Email', value: 'email' },
          { text: 'Cpf', value: 'cpf' },
          { text: 'Ações', value: 'actions', sortable: false },
        ],
        students: [],
      };
    },
    components: {
      NavegationbarComponent,
    },
    created() {
      this.getstudents();
    },
  
    methods: {
      async getstudents() {
        try {
          const response = await axios.get('https://localhost:7018/Student');
          this.students = response.data;
        } catch (error) {
          console.error('Erro ao buscar alunos:', error);
        }
      },
  
      editAluno(item) {
        this.$router.push(`/editar-aluno/${item.ra}`);
      },
  
      redirectCadastroAluno() {
        this.$router.push('/cadastro-aluno');
      },
  
      async confirmDeleteAluno(aluno) {
        try {
          const response = await axios.delete(`https://localhost:7018/student/${aluno.ra}`);
          console.log('Resposta da solicitação:', response.data);
          // Atualize a lista de alunos após excluir
          this.getstudents();
        } catch (error) {
          console.error('Erro na solicitação:', error);
        }
      },
    },
  };
  </script>
  