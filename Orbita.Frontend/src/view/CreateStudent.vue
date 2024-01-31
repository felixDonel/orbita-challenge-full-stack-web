<template>
    <div>
      <NavegationbarComponent title="Alunos"/>
      <v-form @submit.prevent="salvarAluno">
        <v-container>
          <v-row>
            <v-col cols="12" md="12">
              <v-text-field v-model="aluno.nome" label="Nome" required></v-text-field>
            </v-col>
            <v-col cols="12" md="12">
              <v-text-field v-model="aluno.email" label="Email" required></v-text-field>
            </v-col>
            <v-col cols="12" md="12">
              <v-text-field v-model="aluno.cpf" label="CPF" required></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-btn type="submit" color="primary">Salvar</v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
    </div>
  </template>
  
  <script>
  import StudentService from '@/services/StudentService';
  import NavegationbarComponent from '../components/NavegationbarComponent.vue';
  
  export default {
    data() {
      return {
        aluno: {
          nome: '',
          email: '',
          cpf: ''
        }
      };
    },
    components: {
      NavegationbarComponent,
    },
    methods: {
      async salvarAluno() {
        try {
  
          const response = await StudentService.createstudent({
            ra: 0,
            name: this.aluno.nome,
            email: this.aluno.email,
            cpf: this.aluno.cpf,
          });
          this.limparCampos();
        } catch (error) {
          console.error('Erro na solicitação:', error);
        }
      },
      limparCampos() {
        this.aluno.nome = '';
        this.aluno.email = '';
        this.aluno.cpf = '';
      },
    }
  };
  </script>
  