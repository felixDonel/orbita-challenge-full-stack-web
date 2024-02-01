<template>
  <v-form @submit.prevent="handleSubmit">
      <v-container>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field v-model="student.name" label="Nome" :rules="nameRules" required></v-text-field>
            <v-messages :value="student.name" :error-messages="nameErrors"></v-messages>
          </v-col>
          <v-col cols="12" md="12">
            <v-text-field v-model="student.email" label="Email" :rules="emailRules" required></v-text-field>
            <v-messages :value="student.email" :error-messages="emailErrors"></v-messages>
          </v-col>
          <v-col cols="12" md="12">
            <v-text-field v-model="student.cpf" label="CPF" :rules="cpfRules" :readonly="readonly" required></v-text-field>
            <v-messages :value="student.cpf" :error-messages="cpfErrors" ></v-messages>
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
    student: {
      type: Object,
      default: () => ({
        ra: '',
        name: '',
        email: '',
        cpf: '',
      }),
      readonly: {
      type: Boolean,
      default: false,
    },
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
  