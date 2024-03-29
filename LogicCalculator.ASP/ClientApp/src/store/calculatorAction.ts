import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export interface ConvertToRpnResponse {
  expression: string;
  result: string;
  error?: string;
}

export const convertToRpn = createAsyncThunk<ConvertToRpnResponse, string>(
  'calculator/convertToRpn',
  async (expression) => {
    const response = await axios.post('/api/ConvertToRpn', { expression });
    return response.data;
  },
);