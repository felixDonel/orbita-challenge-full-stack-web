<template>
  <div>
    <NavegationbarComponent title="Alunos" />
    <FormStudentComponent :student="student" :handleSubmit="Putstudent" :readonly="true" />
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
    async Putstudent(formData) {
      await StudentService.Putstudent(formData);
    },
  },
};
</script>
