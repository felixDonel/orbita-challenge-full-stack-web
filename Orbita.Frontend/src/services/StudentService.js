import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7044';

export default {
  async getstudents() {
    try {
      const response = await axios.get(`/Student`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },
  async getStudent(id) {
    try {
      const response = await axios.get(`https://localhost:7044/Student/${id}`);
      return response.data;
    } catch (error) {
        throw error;
    }
  },
  async createstudent(Student) {
    try {
      const response = await axios.post(`/Student`, Student);
      return response.data;
    } catch (error) {
      throw error;
    }
  },
  async Deletestudent(ra) {
    try {
      const response = await axios.delete(`/student/${ra}`);
    } catch (error) {
      console.error('Erro na solicitação:', error);
      throw error;
    }
  },async Poststudent(student) {
    try {
      return await axios.put(`/student`, student);
    } catch (error) {
      console.error('Erro na solicitação:', error);
      throw error;
    }
  }
};
