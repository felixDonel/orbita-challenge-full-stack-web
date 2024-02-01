<template>
  <div>
    <NavegationbarComponent title="Alunos"/>
    <FormStudentComponent :aluno="aluno" :handleSubmit="cadastrarAluno" />
  </div>
</template>

<script>
import NavegationbarComponent from '../components/NavegationbarComponent.vue';
import FormStudentComponent from '../components/FormStudentComponent.vue';
import StudentService from '@/services/StudentService';

export default {
  data() {
    return {
      aluno: {
        ra: '',
        name: '',
        email: '',
        cpf: '',
      },
    };
  },
  components: {
    NavegationbarComponent,
    FormStudentComponent,
  },
  methods: {
    async cadastrarAluno(formData) {
      await StudentService.createstudent({cpf: formData.cpf,email: formData.email,name: formData.name});
    },
  },
};
</script>
