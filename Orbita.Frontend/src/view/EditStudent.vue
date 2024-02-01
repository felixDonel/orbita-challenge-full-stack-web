<template>
  <div>
    <NavegationbarComponent title="Alunos" />
    <AlunoFormulario :aluno="aluno" :handleSubmit="editarAluno" :readonly="true" />
  </div>
</template>

<script>
import NavegationbarComponent from '../components/NavegationbarComponent.vue';
import AlunoFormulario from '../components/AlunoFormulario.vue';
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
    AlunoFormulario,
  },
  created() {
    this.getStudent();
  },
  methods: {
    async getStudent() {
      try {
        const id = this.$route.params.id;
        this.aluno = await StudentService.getStudent(id);
      } catch (error) {
        console.error('Erro ao buscar Aluno:', error);
      }
    },
    async editarAluno(formData) {
      await StudentService.Putstudent(formData);
    },
  },
};
</script>
