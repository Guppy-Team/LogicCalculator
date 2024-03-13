import { createSlice } from '@reduxjs/toolkit';

const expressionSlice = createSlice({
  name: 'expression',
  initialState: {
    expression: '',
  },
  reducers: {
    setExpression: (state, action) => {
      state.expression = action.payload;
    },
  },
});

export const { setExpression } = expressionSlice.actions;

export default expressionSlice.reducer;
