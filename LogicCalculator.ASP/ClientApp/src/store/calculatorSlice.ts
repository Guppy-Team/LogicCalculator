import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { convertToRpn, ConvertToRpnResponse } from './calculatorAction';

interface CalculatorState {
  expression: string;
  result: string;
  loading: boolean;
  error: string | null;
}

const initialState: CalculatorState = {
  expression: '',
  result: '',
  loading: true,
  error: null,
};

const calculatorSlice = createSlice({
  name: 'calculator',
  initialState,
  reducers: {
    setExpression: (state, action: PayloadAction<string>) => {
      state.expression = action.payload;
    },
    showError: (state, action: PayloadAction<string>) => {
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
      .addCase(convertToRpn.fulfilled, (state, action: PayloadAction<ConvertToRpnResponse>) => {
        if (action.payload.error) {
          state.error = action.payload.error;
        } else {
          state.expression = action.payload.expression;
          state.result = action.payload.result;
          state.error = null;
        }
        state.loading = false;
      })
      .addCase(convertToRpn.rejected, (state, action) => {
        state.error = action.error.message || 'An error occurred.';
        state.loading = false;
      });
  },
});

export const { setExpression, showError, closeError } = calculatorSlice.actions;

export default calculatorSlice.reducer;