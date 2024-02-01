<template>
  <v-form @submit.prevent="handleSubmit">
      <v-container>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field v-model="aluno.name" label="Nome" :rules="nameRules" required></v-text-field>
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
              {{ successMessage }}
            </v-alert>
          </v-col>
        </v-row>
        <v-row>
          <v-col>
            <v-btn type="submit" color="primary">{{ buttonText }}</v-btn>
          </v-col>
        </v-row>
      </v-container>
    </v-form>
  </template>
  
  <script>
export default {
  props: {
    aluno: {
      type: Object,
      default: () => ({
        ra: '',
        name: '',
        email: '',
        cpf: '',
      }),
    },
    handleSubmit: {
      type: Function,
      required: true,
    },
    successMessage: {
      type: String,
      default: 'Aluno cadastrado com sucesso!',
    },
    buttonText: {
      type: String,
      default: 'Salvar',
    },
    readonly: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      showSuccessMessage: false,
      nameErrors: [],
      emailErrors: [],
      cpfErrors: [],
    };
  },
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
          value => (value && /^\d{11}$/.test(value)) || 'CPF deve ter 11 números.',
        ];
      },
    },
    methods: {
    async handleSubmit() {
      try {
        await this.handleSubmit({
          ra: this.aluno.ra,
          name: this.aluno.name,
          email: this.aluno.email,
          cpf: this.aluno.cpf,
        });
        this.showSuccessMessage = true;
      } catch (error) {
        console.error('Erro na solicitação:', error);
      }
    },
  },
};
</script>
  