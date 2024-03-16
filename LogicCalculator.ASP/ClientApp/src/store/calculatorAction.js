import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const convertToRpn = createAsyncThunk(
  'calculator/convertToRpn',
  async (expression) => {
    const response = await axios.post('/api/ConvertToRpn', { expression });
    return response.data.result;
  },
);
