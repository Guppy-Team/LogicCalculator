import { createSlice } from '@reduxjs/toolkit';
import { convertToRpn } from './calculatorAction';

const calculatorSlice = createSlice({
  name: 'calculator',
  initialState: {
    expression: '',
    result: '',
  },
  reducers: {
    setExpression: (state, action) => {
      state.expression = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(convertToRpn.pending, (state) => {
        state.result = 'Loading...';
      })
      .addCase(convertToRpn.fulfilled, (state, action) => {
        state.result = action.payload;
      })
      .addCase(convertToRpn.rejected, (state, action) => {
        state.result = 'Error: ' + action.error.message;
      });
  },
});

export const { setExpression, setResult } = calculatorSlice.actions;

export default calculatorSlice.reducer;
