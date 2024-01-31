<template>
    <div>
      <NavegationbarComponent title="Alunos"/>
      <v-form @submit.prevent="Poststudent">
        <v-container>
          <v-col cols="12" md="12">
            <v-text-field v-model="student.ra" label="RA" :readonly="true" required></v-text-field>
          </v-col>
          <v-row>
            <v-col cols="12" md="12">
              <v-text-field v-model="student.name" label="Nome" required></v-text-field>
            </v-col>
            <v-col cols="12" md="12">
              <v-text-field v-model="student.email" label="Email" required></v-text-field>
            </v-col>
            <v-col cols="12" md="12">
              <v-text-field v-model="student.cpf" label="CPF" :readonly="true" required></v-text-field>
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
  import axios from 'axios';
  import NavegationbarComponent from '../components/NavegationbarComponent.vue';
  
  export default {
    data() {
      return {
        student: {
          ra: '',
          name: '',
          email: '',
          cpf: '',
        },
      };
    },
    components: {
      NavegationbarComponent,
    },
    created() {
      this.getStudent(); // Chama o método getStudent para preencher os dados
    },
    methods: {
      async getStudent() {
        try {
          // Obtém o ID da rota
          const id = this.$route.params.id;
  
          const response = await axios.get(`https://localhost:7044/Student/${id}`);
          this.student = response.data;
        } catch (error) {
          console.error('Erro ao buscar Aluno:', error);
        }
      },
      async Poststudent() {
        try {
          const response = await axios.put(`https://localhost:7044/student`, {
            ra: this.student.ra,
            name: this.student.name,
            email: this.student.email,
            cpf: this.student.cpf,
          });
  
          console.log('Resposta da solicitação:', response.data);
  
  
        } catch (error) {
          console.error('Erro na solicitação:', error);
        }
      },
    },
  };
  </script>
  