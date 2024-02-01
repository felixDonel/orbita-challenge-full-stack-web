<template>
  <div>
    <NavegationbarComponent title="Alunos"/>
    <v-form @submit.prevent="salvarAluno">
      <v-container>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field v-model="aluno.name" label="Nome"  :rules="nameRules" required></v-text-field>
            <v-messages :value="aluno.name" :error-messages="nameErrors"></v-messages>
          </v-col>

          <v-col cols="12" md="12">
            <v-text-field v-model="aluno.email" label="Email" :rules="emailRules" required></v-text-field>
            <v-messages :value="aluno.email" :error-messages="emailErrors"></v-messages>
          </v-col>
          <v-col cols="12" md="12">
            <v-text-field v-model="aluno.cpf" label="CPF" :rules="cpfRules" required></v-text-field>
            <v-messages :value="aluno.cpf" :error-messages="cpfErrors"></v-messages>
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
      aluno: {
        name: '',
        email: '',
        cpf: '',
      },
      showSuccessMessage: false, 
      nameErrors: [],
      emailErrors: [],
      cpfErrors:[],
    };
  },
  components: {
    NavegationbarComponent,
  }
  ,
  computed: {
    nameRules() {
      return [
        value => !!value || 'Nome é obrigatório.',
        value => (value && value.length >= 3) || 'Nome deve ter pelo menos 3 caracteres.',
      ];
    },
    emailRules() {
      return [
        value => !!value || 'E-mail é obrigatório.',
        value => (/.+@.+\..+/.test(value)) || 'E-mail deve ser válido.',
      ];
    },
    cpfRules() {
      return [
        value => !!value || 'CPF é obrigatório.',
        value => (value && value.length === 11) || 'CPF deve ter 11 caracteres.',
      ];
    },
  },
  methods: {
    async salvarAluno() {
      try {
        console.log("teste");
        const response = await StudentService.createstudent({
          ra: 0,
          name: this.aluno.name,
          email: this.aluno.email,
          cpf: this.aluno.cpf,
        });

        this.showSuccessMessage = true;

        this.limparCampos();
      } catch (error) {
        console.error('Erro na solicitação:', error);
      }
    },
    limparCampos() {
      this.aluno.name = '';
      this.aluno.email = '';
      this.aluno.cpf = '';
    },
  },
};
</script>
