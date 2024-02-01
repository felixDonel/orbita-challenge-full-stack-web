<template>
  <div>
    <NavegationbarComponent title="Alunos"/>
    <FormStudentComponent :student="student" :handleSubmit="createstudent" />
  </div>
</template>

<script>
import NavegationbarComponent from '../components/NavegationbarComponent.vue';
import FormStudentComponent from '../components/FormStudentComponent.vue';
import StudentService from '@/services/StudentService';

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
    FormStudentComponent,
  },
  methods: {
    async createstudent(formData) {
      await StudentService.createstudent({cpf: formData.cpf,email: formData.email,name: formData.name});
    },
  },
};
</script>
