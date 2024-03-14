import { createSlice } from '@reduxjs/toolkit';
import { convertToRpn } from './calculatorAction';

const calculatorSlice = createSlice({
  name: 'calculator',
  initialState: {
    expression: '',
    result: '',
    loading: true,
    error: null,
  },
  reducers: {
    setExpression: (state, action) => {
      state.expression = action.payload;
    },
    showError: (state, action) => {
      state.error = action.payload;
    },
    closeError: (state) => {
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(convertToRpn.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(convertToRpn.fulfilled, (state, action) => {
        if (action.payload.error) {
          state.error = action.payload.error;
        } else {
          state.expression = action.payload.expression;
          state.result = action.payload;
          state.error = null;
        }
        state.loading = false;
      })
      .addCase(convertToRpn.rejected, (state, action) => {
        state.error = action.error.message;
        state.loading = false;
      });
  },
});

export const { setExpression, showError, closeError } = calculatorSlice.actions;

export default calculatorSlice.reducer;
