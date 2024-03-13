import { createSlice } from '@reduxjs/toolkit';

const resultSlice = createSlice({
  name: 'result',
  initialState: {
    result: '',
  },
  reducers: {
    setResult: (state, action) => action.payload,
  },
});

export const { setResult } = resultSlice.actions;

export default resultSlice.reducer;
