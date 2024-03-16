import axios from 'axios';

export const convertToRpn = async (expression) => {
  try {
    const response = await axios.post('/api/ConvertToRpn', {
      expression,
    });
    return response.data.result;
  } catch (error) {
    return { error: error.message };
  }
};
