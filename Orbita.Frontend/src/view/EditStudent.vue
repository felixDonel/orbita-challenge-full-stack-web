<template>
  <div>
    <NavegationbarComponent title="Alunos" />
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
        <v-row v-if="showSuccessMessage">
          <v-col>
            <v-alert type="success" dismissible @input="showSuccessMessage = false">
              Aluno cadastrado com sucesso!
            </v-alert>
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
      student: {
        ra: '',
        name: '',
        email: '',
        cpf: '',
      },
      showSuccessMessage: false
    };
  },
  components: {
    NavegationbarComponent,
  },
  created() {
    this.getStudent();
  },
  methods: {
    async getStudent() {
      try {
        const id = this.$route.params.id;
        this.student = await StudentService.getStudent(id);
      } catch (error) {
        console.error('Erro ao buscar Aluno:', error);
      }
    },
    async Poststudent() {
      try {
        const response = await StudentService.Poststudent({
          ra: this.student.ra,
          name: this.student.name,
          email: this.student.email,
          cpf: this.student.cpf,
        });

        this.showSuccessMessage = true;
      } catch (error) {
        console.error('Erro na solicitação:', error);
      }
    },
  },
};
</script>
